using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWizardController : MonoBehaviour
{
	public float speed = 10;
	public float maxRange = 30;
	public float minRange = 10 ;
	
	public float burstChargeTime = 10f;
	public float windUpTime = 3f;
	public float missileSpeed = 10;
	public float waveSpeed = 500;
	public GameObject target1;
	public GameObject missile;
	public GameObject wave;
	
	private Rigidbody2D iceWizBody;
	private SpriteRenderer iceWizSprite;
	private float distance;
	private bool burstCharge = true;
	private bool ammo = true;
	
	void Start()
    {
        iceWizBody = GetComponent<Rigidbody2D>();
		iceWizSprite = GetComponent<SpriteRenderer>();
    }

	void FixedUpdate()
	{
		if (Input.GetKeyUp("f")){
			Burst();
		 }
	}
	
    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, target1.transform.position);
 
        if (distance > maxRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, target1.transform.position, speed * Time.deltaTime);
        } else {
			if (ammo) 
			{
				Fire();
			}
			else if (distance < minRange)
			{
				if (burstCharge) 
				{
					Burst();
				} else {
					transform.position = Vector2.MoveTowards(transform.position, target1.transform.position, -1 * speed * Time.deltaTime);
				}
			}
		}
	 }
	
	void Burst()
	 {
		burstCharge = false;
		Vector2 dir = (target1.transform.position - this.transform.position).normalized;
		Quaternion angle = new Quaternion(0,0,0,0);
		Vector3 eulerAngle = new Vector3(0,0,90+Vector2.SignedAngle(Vector2.right,dir));
		angle.eulerAngles = eulerAngle;
		
		GameObject burst = Instantiate(wave, transform.position, transform.rotation);
		burst.transform.rotation = angle;
		burst.GetComponent<Rigidbody2D>().AddRelativeForce(dir*waveSpeed, ForceMode2D.Impulse);
		StartCoroutine(Panic());
	 }
	 
	IEnumerator Panic()
	{
		iceWizSprite.material.color = new Color(0,0,1); //C#
		yield return new WaitForSeconds(burstChargeTime);
		burstCharge = true;
		iceWizSprite.material.color = new Color(1,1,1); //C#
	}
	 
	void Fire() 
	{
		ammo = false;
		GameObject icebolt = Instantiate(missile, transform.position, transform.rotation);
		icebolt.GetComponent<IceboltController>().target1 = target1;
		icebolt.GetComponent<IceboltController>().speed = missileSpeed;
		StartCoroutine(WindUp());
	}
	 
	IEnumerator  WindUp()
	{
		iceWizSprite.material.color = new Color(1,1,0.5f); //C#
		yield return new WaitForSeconds(windUpTime);
		iceWizSprite.material.color = new Color(1,0,0); //C#
		ammo = true;
	}
	
	void  onDeath()
	{
		Destroy(gameObject);	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		// change this to attack animation 
		if (other.gameObject.CompareTag("Player"))
		{
			Debug.Log("Player killed IceWizard");
			onDeath();
		}
	}
}
