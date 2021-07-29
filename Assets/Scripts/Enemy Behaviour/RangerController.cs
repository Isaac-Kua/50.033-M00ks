using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Physics2D;	

public class RangerController : MonoBehaviour
{
	public GameConstants gameConstants;
	public GameObject target1;
	
	private GameObject missile;
	private float speed;
	private float maxRange;
	private float minRange;
	private float missileSpeed;
	private float windUpTime;	
	
	private Rigidbody2D rangerBody;
	private SpriteRenderer rangerSprite;
	private float distance;
	private bool ammo = true;
	private Vector2 dir;
	private Quaternion angle = new Quaternion(0,0,0,0);
	
	
	// Start is called before the first frame update
	void Start()
	{
		target1 = gameObject;
		missile = gameConstants.rangerArrow;
		speed = gameConstants.rangerMoveSpeed;
		maxRange = gameConstants.rangerMaxRange;
		minRange = gameConstants.rangerMinRange;
		windUpTime = gameConstants.rangerWindUpTime;
		missileSpeed = gameConstants.rangerArrowSpeed;
		
		rangerBody = GetComponent<Rigidbody2D>();
		rangerSprite = GetComponent<SpriteRenderer>();
	}

	void FixedUpdate()
	{
		dir = (target1.transform.position - transform.position).normalized;
		Vector3 eulerAngle = new Vector3(0,0,Vector2.SignedAngle(Vector2.right,dir));
		angle.eulerAngles = eulerAngle;
		
		distance = Vector2.Distance(transform.position, target1.transform.position);
		transform.rotation = angle;

		if (target1 == gameObject)
		{
			// do nothing
		}
		else if (distance > maxRange)
		{
			rangerBody.velocity = (dir * speed);
		
		} else if (distance > minRange && distance < maxRange) {
			rangerBody.velocity = Vector2.zero;
			if (ammo) {
				Fire();
			} 
		} else if (distance < minRange) {
			rangerBody.velocity = (-1*dir * speed);
		}
	}
	
	// Update is called once per frame
	void Update()
	{		
		target1 = gameObject.GetComponent<Bumblebee>().selectedTarget;
	}
	
	void Fire()
	{
		ammo = false;
		Vector3 direction = dir;
		GameObject arrow = Instantiate(missile, transform.position+direction, transform.rotation);
		arrow.GetComponent<ArrowController>().target1 = target1;
		arrow.transform.rotation = angle;
		arrow.GetComponent<ProjectileController>().owner = gameObject;
		StartCoroutine(WindUp());
	}
	
	IEnumerator  WindUp()
	{
		rangerSprite.material.color = new Color(1,1,0.5f); //C#
		yield return new WaitForSeconds(windUpTime);
		rangerSprite.material.color = new Color(1,0,0); //C#
		ammo = true;
	}
}
