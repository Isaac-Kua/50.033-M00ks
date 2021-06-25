using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerController : MonoBehaviour
{
	public float speed = 12;
	public float maxRange = 20;
	public float minRange = 10;
	public float missileSpeed = 100;
	public float windUpTime = 3f;	
	public GameObject target1;
	public GameObject missile;
	
	private Rigidbody2D rangerBody;
	private SpriteRenderer rangerSprite;
	private float distance;
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
         distance = Vector2.Distance(transform.position, target1.transform.position);
 
         if (distance > maxRange)
         {
             transform.position = Vector2.MoveTowards(transform.position, target1.transform.position, speed * Time.deltaTime);
         }
 
         else if (distance < minRange)
		 {
             transform.position = Vector2.MoveTowards(transform.position, target1.transform.position, -1 * speed * Time.deltaTime);
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
		Vector2 dir = (target1.transform.position - this.transform.position).normalized;
		Quaternion angle = new Quaternion(0,0,0,0);
		Vector3 eulerAngle = new Vector3(0,0,Vector2.SignedAngle(Vector2.right,dir));
		angle.eulerAngles = eulerAngle;
		
		GameObject arrow = Instantiate(missile, transform.position, transform.rotation);
		arrow.transform.rotation = angle;
		arrow.GetComponent<Rigidbody2D>().AddRelativeForce(dir*missileSpeed, ForceMode2D.Impulse);
		StartCoroutine(WindUp());
	 }
	 
	IEnumerator  WindUp()
	 {
		rangerSprite.material.color = new Color(1,1,0.5f); //C#
		yield return new WaitForSeconds(windUpTime);
		rangerSprite.material.color = new Color(1,0,0); //C#
		ammo = true;
	}
}
