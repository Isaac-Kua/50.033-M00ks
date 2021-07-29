using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
	public GameConstants gameConstants;
	public GameObject target1;
	
	private float speed;
	private GameObject shield;
	private GameObject myShield;	
	private Rigidbody2D knightBody;
	private SpriteRenderer knightSprite;
	
	private Vector2 dir;
	private Quaternion angle = new Quaternion(0,0,0,0);
	
	// Start is called before the first frame update
	void Start()
	{

		target1 = gameObject;
		knightBody = GetComponent<Rigidbody2D>();
		knightSprite = GetComponent<SpriteRenderer>();
		
		speed = gameConstants.knightMoveSpeed;
		shield = gameConstants.knightShield;
		
		myShield = Instantiate(shield, transform.position, transform.rotation);
		myShield.transform.parent = transform;
		Vector3 eulerAngle = new Vector3(0,0,90);
		angle.eulerAngles = eulerAngle;
		myShield.transform.rotation = angle;		
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		dir = (target1.transform.position - this.transform.position).normalized;
		Vector3 eulerAngle = new Vector3(0,0,Vector2.SignedAngle(Vector2.right,dir));
		angle.eulerAngles = eulerAngle;
		//transform.rotation = angle;
		eulerAngle = dir;

		if (target1 == gameObject)
		{
			knightBody.velocity = Vector2.zero;
		}
		else if (!myShield.GetComponent<ShieldController>().engaged && !target1.GetComponent<M00ksDeathHandler>().Dead) {
			knightBody.velocity = (dir * speed);
			
			myShield.GetComponent<ShieldController>().target1 = target1;
			myShield.transform.position = transform.position + 1.5f*eulerAngle;
			
			eulerAngle = new Vector3(0,0,90+Vector2.SignedAngle(Vector2.right,dir));
			angle.eulerAngles = eulerAngle;
			myShield.transform.rotation = angle;
		} else {
			knightBody.velocity = Vector2.zero;
		}
	}
	
	void Update() {
		target1 = gameObject.GetComponent<Bumblebee>().selectedTarget;
	}
}
