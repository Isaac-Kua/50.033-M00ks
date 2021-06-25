using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWizardController : MonoBehaviour
{
	public float speed = 5;
	public float yBound = 18;
	public float xBound = 30;
	public float maxRange = 20;
	public float minRange = 5 ;
	
	public float poofChargeTime = 5f;
	public float windUpTime = 3f;
	public float missileSpeed = 10;
	public float missileLifeTime = 2f;
	public GameObject target1;
	public GameObject missile;
	
	private Rigidbody2D fireWizBody;
	private SpriteRenderer fireWizSprite;
	private float distance;
	private bool poofCharge = true;
	private bool ammo = true;

    
	
	// Start is called before the first frame update
    void Start()
    {
        fireWizBody = GetComponent<Rigidbody2D>();
		fireWizSprite = GetComponent<SpriteRenderer>();
    }

	void FixedUpdate()
	{
		if (Input.GetKeyUp("f")){
			Poof();
		 }
	}
	
    // Update is called once per frame
    void Update()
     {
         distance = Vector2.Distance(transform.position, target1.transform.position);
 
         if (distance > maxRange)
         {
             transform.position = Vector2.MoveTowards(transform.position, target1.transform.position, speed * Time.deltaTime);
         }
 
         else if (distance < minRange)
         {
			if (poofCharge) 
			{
				Poof();
			} else {
				 transform.position = Vector2.MoveTowards(transform.position, target1.transform.position, -speed * Time.deltaTime);
			}
         } 
		 
		 else
		 {
			 if (ammo) 
			 {
				 Fire();
			 }
		 }
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
		firebolt.GetComponent<FireboltController>().speed = missileSpeed;
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
