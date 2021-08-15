using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class M00ks1Controller : MonoBehaviour
{
	//public float moveRight = 0;
	//public float moveUp = 0;
	public GameConstants gameConstants;
	public float speed;
	public Vector3 previousLocation;
	public Vector2 moveDirection;
	public Vector2 faceDirection = new Vector2(0,0);
	public int playerNo;
	private bool paused = false;

	// ability use case
	private Rigidbody2D m00ksBody;
	private Collider2D m00ksCollider;
	private Animator m00ksAnimator;
	private SpriteRenderer m00ksSprite;
	private Vector2 dir;
	private float reverseDuration;
	private Quaternion angle = new Quaternion(0,0,0,0);

	// player input
	private PlayerConfiguration playerConfig;
	private InputMaster controls;
	private PlayerInput input;
	private MeleeHolder melee;
	private DashHolder dash;
	private Ability1Holder ability1;
	private Ability2Holder ability2;
	private bool isActions;

	void Awake()
	{
		controls = new InputMaster();	
		melee = GetComponent<MeleeHolder>();
		dash = GetComponent<DashHolder>();
		ability1 = GetComponent<Ability1Holder>();
		ability2 = GetComponent<Ability2Holder>();
		m00ksSprite = GetComponent<SpriteRenderer>();
		isActions=false;
	}

    // Start is called before the first frame update
    void Start()
    {
		m00ksBody = GetComponent<Rigidbody2D>();
		m00ksCollider = GetComponent<Collider2D>();
		m00ksAnimator = GetComponent<Animator>();

		previousLocation = transform.position;
		reverseDuration = gameConstants.reverseDuration;
		speed = gameConstants.M00ksMoveSpeed;
		//faceDirection = new Vector2(moveRight, moveUp);
		//moveDirection = faceDirection;
	}

    // Update is called once per frame
    void Update()
    {	
		// DELETE THIS LINE AFTER TESTING
		//moveDirection = new Vector2(moveRight, moveUp);
		m00ksSprite.flipX = (faceDirection.x < 0);
		m00ksAnimator.SetFloat("Speed", Mathf.Abs(m00ksBody.velocity.magnitude));
		m00ksAnimator.SetBool("SwingUp", faceDirection.y > 0.5);
		m00ksAnimator.SetBool("SwingDown", faceDirection.y < -0.5);
		m00ksAnimator.SetBool("SwingFront", (faceDirection.y <= 0.5 && faceDirection.y >= -0.5));
		
	}

	
	void FixedUpdate()
	{	if(playerConfig.Input.actions.enabled){
			Move();
		}else{
			m00ksBody.velocity = Vector2.zero;
		}
		StartCoroutine(WhatWasI());
	}

	public void InitializePlayer(PlayerConfiguration pc, Sprite s){
		playerConfig = pc;
		playerConfig.Input.onActionTriggered += Input_onActionTriggered;
		pc.playerPrefab = this.gameObject;
		m00ksSprite.sprite = s;
	}

	public void StopActions(){
		isActions = false;
	}
	public void StartActions(){
		isActions = true;
	}

	private void Input_onActionTriggered(CallbackContext obj){
		//Debug.Log("ACTION!!!");
		if (isActions){
			if (obj.action.name == controls.Player.Move.name)
			{
				OnMove(obj);
			}
			else if (obj.action.name == controls.Player.Pause.name)
			{
				if (!paused)
				{
					PauseController.Instance.PauseGame();
					paused = true;
				}
				else if (paused)
				{
					PauseController.Instance.ResumeGame();
					paused = false;
				}
			}

			if (obj.performed)
			{
				if (obj.action.name == controls.Player.Dash.name)
				{
					if (!GameManager.Instance.cutscene){
						dash.OnDash();
						//m00ksAnimator.SetTrigger("Dash");
					}
				}
				else if(obj.action.name == controls.Player.Ability1.name)
				{
					ability1.OnAbility1();
					//m00ksAnimator.SetTrigger("Ability1");
				}
				else if(obj.action.name == controls.Player.Ability2.name)
				{
					ability2.OnAbility2();
					//m00ksAnimator.SetTrigger("Ability2");
				}
				else if(obj.action.name == controls.Player.Melee.name)
				{
					melee.OnMelee();
					//m00ksAnimator.SetTrigger("SwingNow");
				}
			}
		}else{
			if (obj.action.name == controls.Player.Skip.name)
			{
				Debug.Log("SKIPPED");
				if (GameManager.Instance.cutscene) {
					Player1Manager.centralManagerInstance.stopCutscene();
				}
			}
		}
	}
	
	public void OnMove(CallbackContext value)
	{
		moveDirection = value.ReadValue<Vector2>().normalized;
		if (moveDirection.magnitude!=0)
		{
			faceDirection = moveDirection;
		}
	}

    void Move()
    {
		// dir = (moveDirection).normalized;
		// Vector3 eulerAngle = new Vector3(0,0,Vector2.SignedAngle(Vector2.right,dir));
		// angle.eulerAngles = eulerAngle;
		// transform.rotation = angle;
        m00ksBody.velocity = new Vector2(moveDirection.x*speed, moveDirection.y*speed);
    }

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, faceDirection*5);
	}
				
	// Only used for reverseDash
	IEnumerator WhatWasI(){
		Vector3 trackedLocation = transform.position;
		yield return new WaitForSeconds(reverseDuration);
		previousLocation = trackedLocation;
	}
}
