using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWizardController : MonoBehaviour
{
	public GameConstants gameConstants;
	public GameObject target1;

	private Rigidbody2D fireWizBody;
	private SpriteRenderer fireWizSprite;
	private Animator fireWizAnimator;
	private float distance;
	private bool poofCharge = true;
	private bool ammo = true;
	private Vector2 dir;
	private Quaternion angle = new Quaternion(0,0,0,0);
	
	// Start is called before the first frame update
	void Start()
	{
		target1 = gameObject;
		
		fireWizBody = GetComponent<Rigidbody2D>();
		fireWizSprite = GetComponent<SpriteRenderer>();
		fireWizAnimator = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		
		dir = (target1.transform.position - this.transform.position).normalized;
		Vector3 eulerAngle = new Vector3(0,0,Vector2.SignedAngle(Vector2.right,dir));
		angle.eulerAngles = eulerAngle;

		distance = Vector2.Distance(transform.position, target1.transform.position);
		//transform.rotation = angle;

		if (target1 == gameObject)
		{
			fireWizBody.velocity = Vector2.zero;
		}
		else if (distance > gameConstants.fireWizardMaxRange)
		{
			fireWizBody.velocity = (dir * gameConstants.fireWizardMoveSpeed);
			
		} else if (distance > gameConstants.fireWizardMinRange && distance < gameConstants.fireWizardMaxRange) {
			fireWizBody.velocity = Vector2.zero;
			if (ammo) {
				StartCoroutine(Fire());
			} 
		} else if (distance < gameConstants.fireWizardMinRange)
		{
			if (poofCharge) {
				StartCoroutine(Panic());
			} else {
				fireWizBody.velocity = (-1*dir * gameConstants.fireWizardMoveSpeed);
			}
		}

		fireWizAnimator.SetFloat("Speed", Mathf.Abs(fireWizBody.velocity.magnitude));
		fireWizSprite.flipX = (dir.x < 0);

	}

	// Update is called once per frame
	void Update() {
		target1 = gameObject.GetComponent<Bumblebee>().selectedTarget;
	}
	
	IEnumerator Panic()
	{
		poofCharge = false;
		fireWizAnimator.SetTrigger("Panic");
		yield return new WaitForSeconds(gameConstants.fireWizardPoofCastTime);
		transform.position = new Vector2(Random.Range(-gameConstants.xBound, gameConstants.xBound), Random.Range(-gameConstants.yBound, gameConstants.yBound));
		fireWizSprite.material.color = new Color(0,0,1); //C# Deep Blue
		yield return new WaitForSeconds(gameConstants.fireWizardPoofChargeTime);
		poofCharge = true;
		fireWizSprite.material.color = new Color(1,1,1); //C# White
	}

	IEnumerator Fire()
	{
		ammo = false;
		fireWizAnimator.SetTrigger("Firing");
		yield return new WaitForSeconds(gameConstants.fireWizardSwingTime);
		GameObject firebolt = Instantiate(gameConstants.fireWizardFirebolt, transform.position, transform.rotation);
		firebolt.GetComponent<FireboltController>().target1 = target1;
		firebolt.GetComponent<ProjectileController>().owner = gameObject;
		StartCoroutine(WindUp());
	}
	
	IEnumerator  WindUp()
	{
		fireWizSprite.material.color = new Color(1,1,0.5f); //C# Yellow
		yield return new WaitForSeconds(gameConstants.fireWizardWindUpTime);
		fireWizSprite.material.color = new Color(1,0,0); //C# Red
		ammo = true;
	}
}
