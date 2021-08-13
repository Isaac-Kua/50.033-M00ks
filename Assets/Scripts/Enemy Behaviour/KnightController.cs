using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
	public GameConstants gameConstants;
	public GameObject target1;
	
	private bool target_is_dead = false;
	private GameObject shield;
	private GameObject myShield;	
	private Rigidbody2D knightBody;
	private SpriteRenderer knightSprite;
	private Animator knightAnimator;

	private Vector2 dir;
	private Quaternion angle = new Quaternion(0,0,0,0);
	private CurrentLevel levelDifficulty;

	// Start is called before the first frame update
	void Start()
	{
		target1 = gameObject;
		knightBody = GetComponent<Rigidbody2D>();
		knightSprite = GetComponent<SpriteRenderer>();
		knightAnimator = GetComponent<Animator>();

		shield = gameConstants.knightShield;
		
		myShield = Instantiate(shield, transform.position, transform.rotation);
		myShield.transform.parent = transform;
		Vector3 eulerAngle = new Vector3(0,0,90);
		angle.eulerAngles = eulerAngle;
		levelDifficulty = GetComponent<DeathHandler>().gameManager.GetComponent<GameManager>().currentLevel;
		myShield.transform.rotation = angle;
		myShield.GetComponent<ShieldController>().gameManager = GetComponent<DeathHandler>().gameManager;
	}

	void OnDisable(){
		Destroy(myShield);
	}
	void OnEnable(){
		myShield = Instantiate(shield, transform.position, transform.rotation);
		myShield.transform.parent = transform;
		Vector3 eulerAngle = new Vector3(0,0,90);
		angle.eulerAngles = eulerAngle;
		levelDifficulty = GetComponent<DeathHandler>().gameManager.GetComponent<GameManager>().currentLevel;
		myShield.transform.rotation = angle;
		myShield.GetComponent<ShieldController>().gameManager = GetComponent<DeathHandler>().gameManager;
	}


	// Update is called once per frame
	void FixedUpdate()
	{
		target1 = gameObject.GetComponent<Bumblebee>().selectedTarget[0];
		if(target1.GetComponent<M00ksDeathHandler>() != null){
			target_is_dead = target1.GetComponent<M00ksDeathHandler>().Dead;
		}
		else
		{
			target_is_dead = true;
		}
		
		if (target1 == gameObject)
		{
			knightBody.velocity = Vector2.zero;
		}
		else if (!myShield.GetComponent<ShieldController>().engaged && !target_is_dead) {

			dir = (target1.transform.position - this.transform.position).normalized;
			Vector3 eulerAngle = new Vector3(0, 0, Vector2.SignedAngle(Vector2.right, dir));
			angle.eulerAngles = eulerAngle;
			//transform.rotation = angle;
			knightSprite.flipX = (dir.x < 0);
			eulerAngle = dir;


			knightBody.velocity = (dir * levelDifficulty.knightMoveSpeed);
			myShield.GetComponent<ShieldController>().target1 = target1;
			myShield.transform.position = transform.position + 1.2f*eulerAngle;
			
			eulerAngle = new Vector3(0,0,90+Vector2.SignedAngle(Vector2.right,dir));
			angle.eulerAngles = eulerAngle;
			myShield.transform.rotation = angle;
		} else {
			knightBody.velocity = Vector2.zero;
		}

		knightAnimator.SetFloat("Speed", Mathf.Abs(knightBody.velocity.magnitude));
	}

	void Update()
	{
		myShield.GetComponent<ShieldController>().gameManager = GetComponent<DeathHandler>().gameManager;
		target1 = gameObject.GetComponent<Bumblebee>().selectedTarget[0];
		levelDifficulty = GetComponent<DeathHandler>().gameManager.GetComponent<GameManager>().currentLevel;
		knightAnimator.SetBool("Engaged", myShield.GetComponent<ShieldController>().engaged);
		knightAnimator.SetBool("SwingUp", dir.y > 0.5);
		knightAnimator.SetBool("SwingDown", dir.y < -0.5);
		knightAnimator.SetBool("SwingFront", (dir.y <= 0.5 && dir.y >= -0.5));
	}
}
