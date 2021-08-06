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
	private Animator barbAnimator;

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
		barbAnimator = GetComponent<Animator>();
    }
	
    // Update is called once per frame
    void FixedUpdate()
    {	
		dir = (target1.transform.position - this.transform.position).normalized;
		Vector3 eulerAngle = new Vector3(0,0,Vector2.SignedAngle(Vector2.right,dir));
		angle.eulerAngles = eulerAngle;
		
		distance = Vector2.Distance(transform.position, target1.transform.position);
		//transform.rotation = angle;

		if (target1 == gameObject)
		{
			barbBody.velocity = Vector2.zero;
		}
		else if (distance < gameConstants.BarbarianMaxRange)
		{
			if (charges > 0 && !dashing)
			{
				Dash();
			}
			else if (charges != gameConstants.BarbarianMaxCharges && !dashing)
            {
                barbBody.velocity = (-1 * dir * gameConstants.BarbarianMoveSpeed);
            }


        }
        else if (distance > gameConstants.BarbarianMaxRange)
		{
			barbBody.velocity = (dir * gameConstants.BarbarianMoveSpeed);
		}
		else if (distance == gameConstants.BarbarianMaxRange)
		{
			barbBody.velocity = Vector2.zero;
		}


		barbAnimator.SetFloat("Speed", Mathf.Abs(barbBody.velocity.magnitude));
		barbSprite.flipX = (dir.x < 0);

	}
	
	void Update(){
		target1 = gameObject.GetComponent<Bumblebee>().selectedTarget;
		if (GetComponent<DeathHandler>().ammo) {
			charges = gameConstants.BarbarianMaxCharges;
			GetComponent<DeathHandler>().ammo = false;
		}
	}
	
	void Dash()
	{
		barbAnimator.SetTrigger("Firing");
		dashing = true;
		barbCollider.isTrigger = true;
		gameObject.tag = "DashingBarbarian";
		charges -= 1;
		barbBody.AddForce(dir*gameConstants.BarbarianDashSpeed, ForceMode2D.Impulse);
		StartCoroutine(StopDash());
	}
	
	IEnumerator StopDash()
	{
		yield return new WaitForSeconds(gameConstants.BarbarianChargeDuration);
		barbBody.velocity = Vector2.zero;
		gameObject.tag = "Enemy";
		barbCollider.isTrigger = false;
		yield return new WaitForSeconds(gameConstants.BarbarianPauseDuration);
		dashing = false;
		if (charges == 0){
			barbSprite.material.color = new Color(1,1,0.5f); //C#
			yield return new WaitForSeconds(gameConstants.BarbarianWindUpTime);
			barbSprite.material.color = new Color(1,0,0); //C#
			charges = gameConstants.BarbarianMaxCharges;
		}
	}
}
