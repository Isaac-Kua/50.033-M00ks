using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerController : MonoBehaviour
{
	public float maxSpeed = 5;
	public float speed;
	private Rigidbody2D rangerBody;
	private SpriteRenderer rangerSprite;
	private bool Immunity = false;
	private float distance;
	public GameObject target1;
	public float maxRange;
	public float minRange;
    // Start is called before the first frame update
    void Start()
    {
        rangerBody = GetComponent<Rigidbody2D>();
		rangerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
     {
         distance = Vector3.Distance(transform.position, target1.transform.position);
 
         if (distance > maxRange)
         {
             transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, speed * Time.deltaTime);
			 rangerSprite.material.color = new Color(1,0.5f,1); //C#
         }
 
         else if (distance < minRange)
         {
             transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, -1 * speed * Time.deltaTime);
			 rangerSprite.material.color = new Color(0.5f,1,1); //C#
         }

     }
}
