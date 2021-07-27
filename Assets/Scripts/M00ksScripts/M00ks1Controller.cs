using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class M00ks1Controller : MonoBehaviour
{
	public GameConstants gameConstants;
	public float speed;
	public Vector3 previousLocation;
	public Vector2 moveDirection;
	public Vector2 faceDirection;
	public int playerNo;

	// ability use case
	private Rigidbody2D m00ksBody;
	private Collider2D m00ksCollider;
	private Vector2 dir;
	private float reverseDuration;
	private Quaternion angle = new Quaternion(0,0,0,0);

	// player input
	private PlayerConfiguration playerConfig;
	private InputMaster controls;
	private PlayerInput input;

	void Awake()
	{
		controls = new InputMaster();	
	}

    // Start is called before the first frame update
    void Start()
    {
		m00ksBody = GetComponent<Rigidbody2D>();
		m00ksCollider = GetComponent<Collider2D>();
		previousLocation = transform.position;
		reverseDuration = gameConstants.reverseDuration;
		speed = gameConstants.M00ksMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

	}
	
	void FixedUpdate()
	{
		Move();
		StartCoroutine(WhatWasI());
	}

	public void InitializePlayer(PlayerConfiguration pc){
		playerConfig = pc;
		playerConfig.Input.onActionTriggered += Input_onActionTriggered;
	}

	private void Input_onActionTriggered(CallbackContext obj){
		//Debug.Log("ACTION!!!");
		if(obj.action.name == controls.Player.Move.name){
			OnMove(obj);
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
		dir = (moveDirection).normalized;
		Vector3 eulerAngle = new Vector3(0,0,Vector2.SignedAngle(Vector2.right,dir));
		angle.eulerAngles = eulerAngle;
		transform.rotation = angle;
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
