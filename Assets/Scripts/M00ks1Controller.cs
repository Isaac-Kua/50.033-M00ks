using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M00ks1Controller : MonoBehaviour
{
	public float maxSpeed = 10;
	public float speed = 20;
	public float stunnedTime = 3f;
	public float deathTime = 3f;
	public float dashSpeed = 100;
	public float chargeDuration = 0.05f;
	public float pauseDuration = 0.1f;
	
	private Rigidbody2D m00ksBody;
	private SpriteRenderer m00ksSprite;
	private Collider2D m00ksCollider;
	private bool Immunity = false;
	private bool Brittle = false;
	
	
    // Start is called before the first frame update
    void Start()
    {
		m00ksBody = GetComponent<Rigidbody2D>();
		m00ksSprite = GetComponent<SpriteRenderer>();
		m00ksCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {	

    }
	
	void FixedUpdate()
	{
		if (Input.GetKeyDown("r"))
		{
			Application.LoadLevel(0);
		}
		
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
		
		if (Input.GetKeyDown("l"))
		{
			Dash();
		}
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(!Immunity){
			if (other.gameObject.CompareTag("Knight"))
			{
				Debug.Log("Collided with Knight!");
				StartCoroutine(Stunned());
			} else if (other.gameObject.CompareTag("Arrow") || other.gameObject.CompareTag("Firebolt")) {
				Debug.Log("He Shot Me!");
				StartCoroutine(Death());
			} else if (other.gameObject.CompareTag("Icebolt")) {
				if (!Brittle){
					Debug.Log("I'm brittle");
					StartCoroutine(Frozen());
				} else if (Brittle){
					Debug.Log("Killed by IceWizard");
					StartCoroutine(Death());
				}
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Barbarian") && !Immunity)
		{
			Debug.Log("Killed By Barbarian");
			StartCoroutine(Death());
		}
	}
	
	IEnumerator  Stunned(){
		Immunity = true;
		m00ksSprite.material.color = new Color(0.5f,1,1); //C#
		// m00ksBody.constraints = RigidbodyConstraints2D.FreezeAll;
		yield return new WaitForSeconds(3f);
		StartCoroutine(Recover());
	}
	
	IEnumerator  Frozen(){
		Brittle = true;
		m00ksSprite.material.color = new Color(0.5f,1,1); //C#	
		m00ksBody.constraints = RigidbodyConstraints2D.FreezeAll;
		yield return new WaitForSeconds(3f);	
		StartCoroutine(Recover());
	}
	
	IEnumerator Recover(){
		Brittle = false;
		m00ksSprite.material.color = new Color(0,1,0); //C#
		m00ksBody.constraints = RigidbodyConstraints2D.FreezeRotation;
		yield return new WaitForSeconds(0.5f);
		Immunity = false;
		m00ksSprite.material.color = new Color (1,1,1);
	}
	
	IEnumerator  Death(){
		Immunity = true;
		m00ksSprite.material.color = new Color(0,0,0); //C#
		m00ksBody.constraints = RigidbodyConstraints2D.FreezeAll;
		yield return new WaitForSeconds(deathTime);
		StartCoroutine(Recover());
	}
	
	void Dash() 
	{
		Immunity = true;
		m00ksCollider.isTrigger = true;
		m00ksBody.AddRelativeForce(m00ksBody.velocity.normalized*dashSpeed, ForceMode2D.Impulse);
		StartCoroutine(StopDash());
	}
	
	IEnumerator StopDash()
	{
		yield return new WaitForSeconds(chargeDuration);
		m00ksBody.velocity = Vector2.zero;
		yield return new WaitForSeconds(pauseDuration);
		m00ksCollider.isTrigger = false;
		Immunity = false;
	}
}
