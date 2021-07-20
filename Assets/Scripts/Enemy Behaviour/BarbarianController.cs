using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianController : MonoBehaviour
{
	public float speed = 5;
	public float maxRange = 15;
	public float dashSpeed = 150;
	public GameObject target1;
	public float chargeDuration = 0.05f;
	public float pauseDuration = 0.1f;
	public float windUpTime = 3f;
	public int maxCharges = 3;
	
	private float distance;
	private int charges;
	private bool dashing = false;
	private Rigidbody2D barbBody;
	private SpriteRenderer barbSprite;
	private PolygonCollider2D barbCollider;
	
	private Vector2 dir;
	private Quaternion angle = new Quaternion(0,0,0,0);
	
    // Start is called before the first frame update
    void Start()
    {
        barbBody = GetComponent<Rigidbody2D>();
		barbSprite = GetComponent<SpriteRenderer>();
		barbCollider = GetComponent<PolygonCollider2D>();
		charges = maxCharges;
		GetComponent<ProjectileController>().owner = gameObject;
    }
	
    // Update is called once per frame
    void FixedUpdate()
    {
		// if (Input.GetKeyUp("f"))
		// {
			// charges = maxCharges;
		// }
		
		dir = (target1.transform.position - this.transform.position).normalized;
		Vector3 eulerAngle = new Vector3(0,0,Vector2.SignedAngle(Vector2.right,dir));
		angle.eulerAngles = eulerAngle;
		
		distance = Vector2.Distance(transform.position, target1.transform.position);
		transform.rotation = angle;

		if (distance < maxRange)
		{
			if (charges == 0) {
				barbBody.velocity = (-1*dir * speed);
			} else if (charges > 0 && !dashing) {
				Dash();
			} 
			
		} else {
			barbBody.velocity = (dir * speed);
		}
    }
	
	void Update(){
		target1 = gameObject.GetComponent<Bumblebee>().selectedTarget;
	}
	
	void Dash() 
	{
		dashing = true;
		barbCollider.isTrigger = true;
		gameObject.tag = "DashingBarbarian";
		charges -= 1;
		barbBody.AddRelativeForce(Vector2.right*dashSpeed, ForceMode2D.Impulse);
		StartCoroutine(StopDash());
	}
	
	IEnumerator StopDash()
	{
		yield return new WaitForSeconds(chargeDuration);
		barbBody.velocity = Vector2.zero;
		gameObject.tag = "Barbarian";
		yield return new WaitForSeconds(pauseDuration);
		dashing = false;
		barbCollider.isTrigger = false;
		if (charges == 0){
			barbSprite.material.color = new Color(1,1,0.5f); //C#
			yield return new WaitForSeconds(windUpTime);
			barbSprite.material.color = new Color(1,0,0); //C#
			charges = maxCharges;
		}
	}
}
