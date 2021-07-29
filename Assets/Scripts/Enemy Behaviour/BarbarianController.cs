using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianController : MonoBehaviour
{
	public GameConstants gameConstants;
	public GameObject target1;
	
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
		target1 = gameObject;
		barbBody = GetComponent<Rigidbody2D>();
		barbSprite = GetComponent<SpriteRenderer>();
		barbCollider = GetComponent<PolygonCollider2D>();
		charges = gameConstants.BarbarianMaxCharges;
		GetComponent<ProjectileController>().owner = gameObject;
    }
	
    // Update is called once per frame
    void FixedUpdate()
    {	
		dir = (target1.transform.position - this.transform.position).normalized;
		Vector3 eulerAngle = new Vector3(0,0,Vector2.SignedAngle(Vector2.right,dir));
		angle.eulerAngles = eulerAngle;
		
		distance = Vector2.Distance(transform.position, target1.transform.position);
		transform.rotation = angle;

		if (target1 == gameObject)
		{
			// do nothing
		}
		else if (distance < gameConstants.BarbarianMaxRange)
		{
			if (charges == 0) {
				barbBody.velocity = (-1*dir * gameConstants.BarbarianMoveSpeed);
			} else if (charges > 0 && !dashing) {
				Dash();
			} 
			
		} else {
			barbBody.velocity = (dir * gameConstants.BarbarianMoveSpeed);
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
		barbBody.AddRelativeForce(Vector2.right*gameConstants.BarbarianDashSpeed, ForceMode2D.Impulse);
		StartCoroutine(StopDash());
	}
	
	IEnumerator StopDash()
	{
		yield return new WaitForSeconds(gameConstants.BarbarianChargeDuration);
		barbBody.velocity = Vector2.zero;
		gameObject.tag = "Enemy";
		yield return new WaitForSeconds(gameConstants.BarbarianPauseDuration);
		dashing = false;
		barbCollider.isTrigger = false;
		if (charges == 0){
			barbSprite.material.color = new Color(1,1,0.5f); //C#
			yield return new WaitForSeconds(gameConstants.BarbarianWindUpTime);
			barbSprite.material.color = new Color(1,0,0); //C#
			charges = gameConstants.BarbarianMaxCharges;
		}
	}
}
