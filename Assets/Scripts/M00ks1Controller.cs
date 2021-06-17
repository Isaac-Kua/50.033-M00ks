using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M00ks1Controller : MonoBehaviour
{
	public float maxSpeed = 10;
	public float speed;
	private Rigidbody2D m00ksBody;
	private SpriteRenderer m00ksSprite;
	private bool Immunity = false;
    // Start is called before the first frame update
    void Start()
    {
		m00ksBody = GetComponent<Rigidbody2D>();
		m00ksSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {	

    }
	
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		if (Mathf.Abs(moveHorizontal) > 0){
			Vector2 movement = new Vector2(moveHorizontal, 0);
			if (m00ksBody.velocity.magnitude < maxSpeed)
                  m00ksBody.AddForce(movement * speed, ForceMode2D.Impulse);
		}
		
		float moveVertical = Input.GetAxis("Vertical");
		if (Mathf.Abs(moveVertical) > 0){
			Vector2 movement = new Vector2(0, moveVertical);
			if (m00ksBody.velocity.magnitude < maxSpeed)
                  m00ksBody.AddForce(movement * speed, ForceMode2D.Impulse);
		}
		
		if (Input.GetKeyUp("a") || Input.GetKeyUp("d") || Input.GetKeyDown("w") || Input.GetKeyDown("s")){
			// stop
			m00ksBody.velocity = Vector2.zero;
		 }
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Knight") && !Immunity)
		{
			Debug.Log("Collided with Knight!");
			StartCoroutine(Stunned());
		}
		
		if (other.gameObject.CompareTag("Arrow") && !Immunity)
		{
			Debug.Log("He Shot Me!");
			StartCoroutine(Stunned());
		}
	}
	
	IEnumerator  Stunned(){
		Immunity = true;
		m00ksSprite.material.color = new Color(0.5f,1,1); //C#
		m00ksBody.bodyType = RigidbodyType2D.Static;
		yield return new WaitForSeconds(3f);
		
		m00ksBody.bodyType = RigidbodyType2D.Dynamic;
		m00ksSprite.material.color = new Color (1,0,0);
		
		yield return new WaitForSeconds(0.3f);
		Immunity = false;
		m00ksSprite.material.color = new Color (1,1,1);
	}
	
	IEnumerator  Poisoned(){
		m00ksSprite.material.color = new Color(0,1,0); //C#
		yield return new WaitForSeconds(3f);
	}
}
