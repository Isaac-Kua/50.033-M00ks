using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
	public float speed = 5;
	public float maxRange = 15;
	public GameObject target1;
	public GameObject shield;
	public GameObject myShield;	
	
	public float swordLength = 1f;
	public float shieldWidth = 1f;
	public float windUpTime = 3f;
	
	
	private Rigidbody2D knightBody;
	private SpriteRenderer knightSprite;
	
	private Vector2 dir;
	private Quaternion angle = new Quaternion(0,0,0,0);
	
	// Start is called before the first frame update
	void Start()
	{
		knightBody = GetComponent<Rigidbody2D>();
		knightSprite = GetComponent<SpriteRenderer>();
		myShield = Instantiate(shield, transform.position, transform.rotation);
		myShield.GetComponent<ShieldController>().swordLength = swordLength;
		myShield.GetComponent<ShieldController>().shieldWidth = shieldWidth;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		dir = (target1.transform.position - this.transform.position).normalized;
		Vector3 eulerAngle = new Vector3(0,0,Vector2.SignedAngle(Vector2.right,dir));
		angle.eulerAngles = eulerAngle;
		transform.rotation = angle;
		eulerAngle = dir;
		
		if (!myShield.GetComponent<ShieldController>().engaged && !target1.GetComponent<M00ks1Controller>().Dead) {
			knightBody.velocity = (dir * speed);
			
			myShield.GetComponent<ShieldController>().target1 = target1;
			myShield.transform.position = transform.position + 2f*eulerAngle;
			
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
