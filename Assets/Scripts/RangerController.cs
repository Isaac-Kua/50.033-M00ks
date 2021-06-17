using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerController : MonoBehaviour
{
	public float maxSpeed = 5;
	public float speed;
	private Rigidbody2D rangerBody;
	private SpriteRenderer rangerSprite;
	private float distance;
	public GameObject target1;
	public float maxRange = 20;
	public float minRange = 10;
	public float missileSpeed = 150;	
	public  GameObject missile;
	private bool ammo = true;
    
	
	// Start is called before the first frame update
    void Start()
    {
        rangerBody = GetComponent<Rigidbody2D>();
		rangerSprite = GetComponent<SpriteRenderer>();
    }

	void FixedUpdate()
	{
		if (Input.GetKeyUp("f")){
			Fire();
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
             transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, -1 * speed * Time.deltaTime);
			 // rangerSprite.material.color = new Color(0.5f,1,1); //C#
         }
		 
		 else 
		 {
			if (ammo)
			{
				Fire();
			} 
		 }
     }
	 
	void Fire()
	 {
		ammo = false;
		GameObject arrow = Instantiate(missile, transform.position, transform.rotation);
		arrow.GetComponent<Rigidbody2D>().AddRelativeForce((target1.transform.position - this.transform.position)*missileSpeed);
		Debug.Log("fired");
		StartCoroutine(WindUp());
	 }
	 
	IEnumerator  WindUp()
	 {
		rangerSprite.material.color = new Color(1,1,0.5f); //C#
		yield return new WaitForSeconds(3f);
		rangerSprite.material.color = new Color(1,0,0); //C#
		ammo = true;
	}
}
