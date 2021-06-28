using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumblebee : MonoBehaviour
{
	public float speed;
	public float detectionRange;
	public Rigidbody2D npcBody;
	public Vector2 dir;
	
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void FixedUpdate(){
		//Length of the ray
		int layerMask = LayerMask.GetMask("Debris");
		//Get the first object hit by the ray
		RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.right, dir , detectionRange, layerMask);

		//If the collider of the object hit is not NUll
		if (hit.collider!= null && hit.collider.tag == "Debris")
		{
			//Hit something, print the tag of the object
			Debug.Log("Hitting: " + hit.collider.tag);
			npcBody.velocity += (-1 * dir * speed);
		}


		//Method to draw the ray in scene for debug purpose
		Debug.DrawRay(transform.position, dir * detectionRange, Color.red);
	}
}
