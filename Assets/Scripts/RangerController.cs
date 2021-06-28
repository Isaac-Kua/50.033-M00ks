using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Physics2D;	

public class RangerController : MonoBehaviour
{
	public float speed = 12;
	public float maxRange = 20;
	public float minRange = 10;
	public float missileSpeed = 100;
	public float windUpTime = 3f;	
	public GameObject target1;
	public GameObject missile;
	
	private Rigidbody2D rangerBody;
	private SpriteRenderer rangerSprite;
	private float distance;
	private bool ammo = true;
	private Vector2 dir;
	private Quaternion angle = new Quaternion(0,0,0,0);
	
	
	// Start is called before the first frame update
	void Start()
	{
		rangerBody = GetComponent<Rigidbody2D>();
		rangerSprite = GetComponent<SpriteRenderer>();
	}

	void FixedUpdate()
	{
		if (Input.GetKeyUp("f")){
			Fire();
			Debug.Log(gameObject.tag);
		}
		
		dir = (target1.transform.position - this.transform.position).normalized;
		Vector3 eulerAngle = new Vector3(0,0,Vector2.SignedAngle(Vector2.right,dir));
		angle.eulerAngles = eulerAngle;
		
		distance = Vector2.Distance(transform.position, target1.transform.position);
		transform.rotation = angle;

		if (distance > maxRange)
		{
			rangerBody.velocity = (dir * speed);
		
		} else if (distance > minRange && distance < maxRange) {
			rangerBody.velocity = Vector2.zero;
			if (ammo) {
				Fire();
			} 
		} else if (distance > minRange && distance < maxRange){
			rangerBody.velocity = (-1*dir * speed);
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		
		gameObject.GetComponent<Bumblebee>().dir = dir;
		gameObject.GetComponent<Bumblebee>().speed = speed;
		gameObject.GetComponent<Bumblebee>().detectionRange = maxRange;
		gameObject.GetComponent<Bumblebee>().npcBody = rangerBody;
	}
	
	void Fire()
	{
		ammo = false;		
		GameObject arrow = Instantiate(missile, transform.position, transform.rotation);
		arrow.transform.rotation = angle;
		arrow.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right*missileSpeed, ForceMode2D.Impulse);
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
