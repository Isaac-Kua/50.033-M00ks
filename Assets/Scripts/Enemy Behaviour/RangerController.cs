using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Physics2D;	

public class RangerController : MonoBehaviour
{
	public GameConstants gameConstants;
	public GameObject target1;

	private float maxRange;
	private float minRange;

	private Vector2 dir;
	private Rigidbody2D rangerBody;
	private SpriteRenderer rangerSprite;
	private Animator rangerAnimator;
	private float distance;
	private bool ammo = true;
	private Quaternion angle = new Quaternion(0,0,0,0);
	
	
	// Start is called before the first frame update
	void Start()
	{
		target1 = gameObject;
		rangerBody = GetComponent<Rigidbody2D>();
		rangerSprite = GetComponent<SpriteRenderer>();
		rangerAnimator = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		dir = (target1.transform.position - transform.position).normalized;
		Vector3 eulerAngle = new Vector3(0,0,Vector2.SignedAngle(Vector2.right,dir));
		angle.eulerAngles = eulerAngle;
		rangerSprite.flipX = (dir.x < 0);
		
		distance = Vector2.Distance(transform.position, target1.transform.position);
		//transform.rotation = angle;

		if (target1 == gameObject)
		{
			rangerBody.velocity = Vector2.zero;
			// do nothing
		}
		else if (distance > gameConstants.rangerMaxRange)
		{
			rangerBody.velocity = (dir * gameConstants.rangerMoveSpeed);
		
		} else if (distance > gameConstants.rangerMinRange && distance < gameConstants.rangerMaxRange) {
			rangerBody.velocity = Vector2.zero;
			if (ammo) {
				StartCoroutine(Fire());
			} 
		} else if (distance < gameConstants.rangerMinRange) {
			rangerBody.velocity = (-1*dir * gameConstants.rangerMoveSpeed);
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		target1 = gameObject.GetComponent<Bumblebee>().selectedTarget;
		rangerAnimator.SetFloat("Speed", Mathf.Abs(rangerBody.velocity.magnitude));
	}

	IEnumerator Fire()
	{
		rangerAnimator.SetTrigger("Firing");
		ammo = false;
		Vector3 direction = dir;
		yield return new WaitForSeconds(gameConstants.rangerFireTime);
		GameObject arrow = Instantiate(gameConstants.rangerArrow, transform.position+direction, angle);
		arrow.GetComponent<ArrowController>().target1 = target1;
		arrow.transform.rotation = angle;
		arrow.GetComponent<ProjectileController>().owner = gameObject;
		StartCoroutine(WindUp());
	}
	
	IEnumerator  WindUp()
	{
		rangerSprite.material.color = new Color(1,1,0.5f); //C#
		yield return new WaitForSeconds(gameConstants.rangerWindUpTime);
		rangerSprite.material.color = new Color(1,0,0); //C#
		ammo = true;
	}
}
