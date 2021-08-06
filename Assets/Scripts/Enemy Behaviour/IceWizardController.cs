using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	private Animator iceWizAnimator;

	private float distance;
	private bool burstCharge = true;
	private Vector2 dir;
	private Quaternion angle = new Quaternion(0,0,0,0);
	
	void Awake()
    {
		Debug.Log("GoodMorning");
    }
	void Start()
	{
		target1 = gameObject;
		iceWizBody = GetComponent<Rigidbody2D>();
		iceWizSprite = GetComponent<SpriteRenderer>();
		iceWizAnimator = GetComponent<Animator>();
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
			iceWizBody.velocity = Vector2.zero;

		}
		else if (distance > gameConstants.iceWizardMaxRange)
		{
			iceWizBody.velocity = (dir * gameConstants.iceWizardMoveSpeed);

        }
        else if (distance > gameConstants.iceWizardMinRange && distance < gameConstants.iceWizardMaxRange)
        {
            iceWizBody.velocity = Vector2.zero;
            if (GetComponent<DeathHandler>().ammo)
            {
				StartCoroutine(Fire());
            }
        } else if (distance < gameConstants.iceWizardMinRange)
		{
			if (burstCharge) {
				Burst();
			} else {
				iceWizBody.velocity = (-1*dir * gameConstants.iceWizardMoveSpeed);
			}
		}

		iceWizAnimator.SetFloat("Speed", Mathf.Abs(iceWizBody.velocity.magnitude));
		iceWizSprite.flipX = (dir.x < 0);
	}
	
	// Update is called once per frame
	void Update()
	{
		target1 = gameObject.GetComponent<Bumblebee>().selectedTarget;
	}
	
	void Burst()
	{
		iceWizAnimator.SetTrigger("Panic");
		burstCharge = false;	
		Vector3 eulerAngle = new Vector3(0,0, 90+Vector2.SignedAngle(Vector2.right,dir));
		angle.eulerAngles = eulerAngle;

		Vector3 faceDir = dir;
		
		GameObject burst = Instantiate(gameConstants.iceWizardIcewave, transform.position + faceDir, transform.rotation);		
		burst.GetComponent<Rigidbody2D>().AddForce(dir* gameConstants.icewaveSpeed, ForceMode2D.Impulse);
		burst.GetComponent<IcewaveController>().core = true;
		StartCoroutine(Panic());
	}
	
	IEnumerator Panic()
	{
		yield return new WaitForSeconds(gameConstants.iceWizardBurstChargeTime);
		burstCharge = true;
	}

	IEnumerator Fire()
	{
		GetComponent<DeathHandler>().ammo = false;
		iceWizAnimator.SetTrigger("Firing");
		yield return new WaitForSeconds(gameConstants.iceWizardSwingTime);
		GameObject icebolt = Instantiate(gameConstants.iceWizardIcebolt, transform.position, transform.rotation);
		icebolt.GetComponent<IceboltController>().target1 = target1;
		icebolt.GetComponent<ProjectileController>().owner = gameObject;
		StartCoroutine(WindUp());
	}
	
	IEnumerator  WindUp()
	{
		yield return new WaitForSeconds(gameConstants.iceWizardWindUpTime);
		GetComponent<DeathHandler>().ammo = true;
	}
}
