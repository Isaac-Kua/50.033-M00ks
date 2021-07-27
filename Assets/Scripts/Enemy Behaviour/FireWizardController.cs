using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWizardController : MonoBehaviour
{
	public GameConstants gameConstants;
	public GameObject target1;
	
	private float speed;
	private float yBound;
	private float xBound;
	private float maxRange;
	private float minRange;
	private float poofChargeTime;
	private float windUpTime;
	private GameObject missile;
	
	private Rigidbody2D fireWizBody;
	private SpriteRenderer fireWizSprite;
	private float distance;
	private bool poofCharge = true;
	private bool ammo = true;
	private Vector2 dir;
	private Quaternion angle = new Quaternion(0,0,0,0);

	
	
	// Start is called before the first frame update
	void Start()
	{
		target1 = gameObject;
		speed = gameConstants.fireWizardMoveSpeed;
		yBound = gameConstants.yBound;
		xBound = gameConstants.xBound;
		maxRange = gameConstants.fireWizardMaxRange;
		minRange = gameConstants.fireWizardMinRange;
		poofChargeTime = gameConstants.fireWizardPoofChargeTime;
		windUpTime = gameConstants.fireWizardWindUpTime;
		missile = gameConstants.fireWizardFirebolt;
		
		fireWizBody = GetComponent<Rigidbody2D>();
		fireWizSprite = GetComponent<SpriteRenderer>();
	}

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
		else if (distance > maxRange)
		{
			fireWizBody.velocity = (dir * speed);
			
		} else if (distance > minRange && distance < maxRange) {
			fireWizBody.velocity = Vector2.zero;
			if (ammo) {
				Fire();
			} 
		} else if (distance < minRange){
			if (poofCharge) {
				Poof();
			} else {
				fireWizBody.velocity = (-1*dir * speed);
			}
		}
	}
	
	// Update is called once per frame
	void Update() {
		target1 = gameObject.GetComponent<Bumblebee>().selectedTarget;
	}
	
	void Poof()
	{
		transform.position = new Vector2(Random.Range(-xBound, xBound),Random.Range(-yBound, yBound));
		poofCharge = false;
		StartCoroutine(Panic());
	}
	
	IEnumerator Panic()
	{
		fireWizSprite.material.color = new Color(0,0,1); //C# Deep Blue
		yield return new WaitForSeconds(poofChargeTime);
		poofCharge = true;
		fireWizSprite.material.color = new Color(1,1,1); //C# White
	}
	
	void Fire() 
	{
		ammo = false;
		GameObject firebolt = Instantiate(missile, transform.position, transform.rotation);
		firebolt.GetComponent<FireboltController>().target1 = target1;
		firebolt.GetComponent<ProjectileController>().owner = gameObject;
		StartCoroutine(WindUp());
	}
	
	IEnumerator  WindUp()
	{
		fireWizSprite.material.color = new Color(1,1,0.5f); //C# Yellow
		yield return new WaitForSeconds(windUpTime);
		fireWizSprite.material.color = new Color(1,0,0); //C# Red
		ammo = true;
	}
}
