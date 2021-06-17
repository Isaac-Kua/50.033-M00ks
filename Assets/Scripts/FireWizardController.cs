using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWizardController : MonoBehaviour
{
	public float maxSpeed = 5;
	public float speed;
	private Rigidbody2D fireWizBody;
	private SpriteRenderer fireWizSprite;
	private float distance;
	public GameObject target1;
	public float maxRange = 20;
	public float minRange = 5 ;
	public float missileSpeed = 200;	
	public  GameObject missile;
	private bool poofCharge = true;
	private bool ammo = true;
	public float yBound = 18;
	public float xBound = 30;
    
	
	// Start is called before the first frame update
    void Start()
    {
        fireWizBody = GetComponent<Rigidbody2D>();
		fireWizSprite = GetComponent<SpriteRenderer>();
    }

	void FixedUpdate()
	{
		if (Input.GetKeyUp("f")){
			// stop
			// ammo = true;
			Poof();
		 }
	}
	
    // Update is called once per frame
    void Update()
     {
         distance = Vector3.Distance(transform.position, target1.transform.position);
 
         if (distance > maxRange)
         {
             transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, speed * Time.deltaTime);
			 // rangerSprite.material.color = new Color(1,0.5f,1); //C#
         }
 
         else if (distance < minRange)
         {
			 // rangerSprite.material.color = new Color(0.5f,1,1); //C#
			if (poofCharge) 
			{
				Poof();
			} else {
				 transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, -speed * Time.deltaTime);
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
		 transform.position = new Vector3(Random.Range(-xBound, xBound),Random.Range(-yBound, yBound),0);
		 poofCharge = false;
		 Debug.Log("poof");
		 StartCoroutine(Panic());
	 }
	 
	 IEnumerator Panic()
	 {
		fireWizSprite.material.color = new Color(0,0,1); //C#
		yield return new WaitForSeconds(3f);
		poofCharge = true;
		fireWizSprite.material.color = new Color(1,1,1); //C#
	 }
	 
	 void Fire() 
	 {
		ammo = false;
		GameObject firebolt = Instantiate(missile, transform.position, transform.rotation);
		firebolt.GetComponent<FireboltController>().target1 = target1;
		// firebolt.GetComponent<Rigidbody2D>().AddRelativeForce((target1.transform.position - this.transform.position)*missileSpeed);
		Debug.Log("fired");
		StartCoroutine(WindUp());
	 }
	 
	 IEnumerator  WindUp()
	 {
		fireWizSprite.material.color = new Color(1,1,0.5f); //C#
		yield return new WaitForSeconds(3f);
		fireWizSprite.material.color = new Color(1,0,0); //C#
		ammo = true;
	}
}
