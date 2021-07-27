using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWizardController : MonoBehaviour
{
	public GameConstants gameConstants;
	public GameObject target1;
	
	private float speed;
	private float maxRange;
	private float minRange;

	private GameObject missile;
	private float windUpTime;
	
	private GameObject wave;
	private float burstChargeTime;
	private float waveSpeed;
	
	private Rigidbody2D iceWizBody;
	private SpriteRenderer iceWizSprite;
	private float distance;
	private bool burstCharge = true;
	private bool ammo = true;
	private Vector2 dir;
	private Quaternion angle = new Quaternion(0,0,0,0);
	
	void Start()
	{
		speed = gameConstants.iceWizardMoveSpeed;
		maxRange = gameConstants.iceWizardMaxRange;
		minRange = gameConstants.iceWizardMinRange;
		burstChargeTime = gameConstants.iceWizardBurstChargeTime;
		windUpTime = gameConstants.iceWizardWindUpTime;
		missile = gameConstants.iceWizardIcebolt;
		wave = gameConstants.iceWizardIcewave;
	
		waveSpeed = gameConstants.icewaveSpeed;
		iceWizBody = GetComponent<Rigidbody2D>();
		iceWizSprite = GetComponent<SpriteRenderer>();
	}

	void FixedUpdate()
	{
		dir = (target1.transform.position - this.transform.position).normalized;
		Vector3 eulerAngle = new Vector3(0,0,Vector2.SignedAngle(Vector2.right,dir));
		angle.eulerAngles = eulerAngle;
		
		distance = Vector2.Distance(transform.position, target1.transform.position);
		transform.rotation = angle;

		if (distance > maxRange)
		{
			iceWizBody.velocity = (dir * speed);
			
		} else if (distance > minRange && distance < maxRange) {
			iceWizBody.velocity = Vector2.zero;
			if (ammo) {
				Fire();
			} 
		} else if (distance < minRange){
			if (burstCharge) {
				Burst();
			} else {
				iceWizBody.velocity = (-1*dir * speed);
			}
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		target1 = gameObject.GetComponent<Bumblebee>().selectedTarget;
	}
	
	void Burst()
	{
		burstCharge = false;	
		Vector3 eulerAngle = new Vector3(0,0, 90+Vector2.SignedAngle(Vector2.right,dir));
		angle.eulerAngles = eulerAngle;
		eulerAngle = dir;
		
		GameObject burst = Instantiate(wave, transform.position + eulerAngle, transform.rotation);		
		burst.transform.rotation = angle;
		burst.GetComponent<Rigidbody2D>().AddRelativeForce(dir*waveSpeed, ForceMode2D.Impulse);
		burst.GetComponent<IcewaveController>().core = true;
		StartCoroutine(Panic());
	}
	
	IEnumerator Panic()
	{
		iceWizSprite.material.color = new Color(0,0,1); //C# Deepblue
		yield return new WaitForSeconds(burstChargeTime);
		burstCharge = true;
		iceWizSprite.material.color = new Color(1,1,1); //C# White
	}
	
	void Fire() 
	{
		ammo = false;
		GameObject icebolt = Instantiate(missile, transform.position, transform.rotation);
		icebolt.GetComponent<IceboltController>().target1 = target1;
		icebolt.GetComponent<ProjectileController>().owner = gameObject;
		StartCoroutine(WindUp());
	}
	
	IEnumerator  WindUp()
	{
		iceWizSprite.material.color = new Color(1,1,0.5f); //C# Yellow
		yield return new WaitForSeconds(windUpTime);
		iceWizSprite.material.color = new Color(1,0,0); //C# Red
		ammo = true;
	}
}
