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
	private AudioSource fireWizAudio;
	private float distance;
	private Vector2 dir;
	private Quaternion angle = new Quaternion(0,0,0,0);
	private CurrentLevel levelDifficulty;
	
	// Start is called before the first frame update
	void Start()
	{
		target1 = gameObject;
		
		fireWizBody = GetComponent<Rigidbody2D>();
		fireWizSprite = GetComponent<SpriteRenderer>();
		fireWizAnimator = GetComponent<Animator>();
		fireWizAudio = GetComponent<AudioSource>();
		levelDifficulty = GetComponent<DeathHandler>().gameManager.GetComponent<GameManager>().currentLevel;
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
			if (GetComponent<DeathHandler>().ammo) {
				StartCoroutine(Fire());
			} 
		} else if (distance < gameConstants.fireWizardMinRange)
		{
			if (GetComponent<DeathHandler>().burstCharge) {
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
		levelDifficulty = GetComponent<DeathHandler>().gameManager.GetComponent<GameManager>().currentLevel;
	}
	
	IEnumerator Panic()
	{
		GetComponent<DeathHandler>().burstCharge = false;
		fireWizAnimator.SetTrigger("Panic");
		yield return new WaitForSeconds(gameConstants.fireWizardPoofCastTime);
		transform.position = new Vector2(Random.Range(-gameConstants.xBound, gameConstants.xBound), Random.Range(-gameConstants.yBound, gameConstants.yBound));
		yield return new WaitForSeconds(gameConstants.fireWizardPoofChargeTime);
		GetComponent<DeathHandler>().burstCharge = true;
	}

	IEnumerator Fire()
	{
		GetComponent<DeathHandler>().ammo = false;
		fireWizAnimator.SetTrigger("Firing");
		yield return new WaitForSeconds(gameConstants.fireWizardSwingTime);
		GameObject firebolt = Instantiate(gameConstants.fireWizardFirebolt, transform.position, transform.rotation);
		fireWizAudio.Play();
		firebolt.GetComponent<FireboltController>().gameManager = GetComponent<DeathHandler>().gameManager;
		firebolt.GetComponent<FireboltController>().target1 = target1;
		firebolt.GetComponent<ProjectileController>().owner = gameObject;
		StartCoroutine(WindUp());
	}
	
	IEnumerator  WindUp()
	{
		yield return new WaitForSeconds(gameConstants.fireWizardWindUpTime);
		GetComponent<DeathHandler>().ammo = true;
	}
}
