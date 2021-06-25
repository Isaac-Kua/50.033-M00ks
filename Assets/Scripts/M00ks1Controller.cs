using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M00ks1Controller : MonoBehaviour
{
	public float maxSpeed = 10;
	public float speed = 20;
	public float stunTime = 3f;
	public float deathTime = 3f;
	public float dashSpeed = 100;
	public float chargeDuration = 0.05f;
	public float pauseDuration = 0.1f;
	public float slowTime = 3f;
	public float slowRatio = 5f;
	public bool Dead = false;
	
	private Rigidbody2D m00ksBody;
	private SpriteRenderer m00ksSprite;
	private Collider2D m00ksCollider;
	private bool Immunity = false;
	private bool Brittle = false;
	private bool Slow = false;
	
	
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
		if (Input.GetKeyUp("r"))
		{
			Application.LoadLevel(0);
		}
		
		if (Input.GetKeyUp("m"))
		{
			StartCoroutine(Death());
		}
		
		if (Input.GetKeyDown("l"))
		{
			Dash();
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
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(!Dead){
			if (other.gameObject.CompareTag("KnightShield"))
			{
				Debug.Log("Collided with KnightShield");
				StartCoroutine(Stunned());
			} else if (other.gameObject.CompareTag("Arrow") || other.gameObject.CompareTag("Firebolt")) {
				Debug.Log("He Shot Me!");
				StartCoroutine(Death());
			} else if (other.gameObject.CompareTag("Icebolt")) {
				if (!Brittle){
					Brittle = true;
					StartCoroutine(Stunned());
				} else if (Brittle){
					Debug.Log("Killed by IceWizard");
					StartCoroutine(Death());
				}
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(!Immunity){
			if (other.gameObject.CompareTag("DashingBarbarian"))
			{
				Debug.Log("Killed By Barbarian");
				StartCoroutine(Death());
			} else if (other.gameObject.CompareTag("Goo")){
				StartCoroutine(Slowed());
			} else if (other.gameObject.CompareTag("KnightSword")){
				Debug.Log("Killed By Knight");
				StartCoroutine(Death());
			}
		}
	}
	
	IEnumerator Slowed() {
		if (!Slow){
			Slow = true;
			maxSpeed /= slowRatio;
			speed /= slowRatio;
			yield return new WaitForSeconds(slowTime);
			maxSpeed *= slowRatio;
			speed *= slowRatio;
			Slow = false;
		}
	}
	
	IEnumerator  Stunned(){
		m00ksSprite.material.color = new Color(0.5f,1,1); //C#	
		m00ksBody.constraints = RigidbodyConstraints2D.FreezeAll;
		yield return new WaitForSeconds(stunTime);
		if (!Dead){
			m00ksBody.constraints = RigidbodyConstraints2D.FreezeRotation;
			Brittle = false;
			m00ksSprite.material.color = new Color(1,1,1); //C#	
		}
	}
	
	IEnumerator Respawn(){
		m00ksSprite.material.color = new Color(0,1,0); //C#
		m00ksBody.constraints = RigidbodyConstraints2D.FreezeRotation;
		yield return new WaitForSeconds(0.5f);
		Brittle = false;
		Immunity = false;
		Dead = false;
		Slow = false;
		m00ksSprite.material.color = new Color (1,1,1);
	}
	
	IEnumerator  Death(){
		Dead = true;
		Immunity = true;
		m00ksSprite.material.color = new Color(0,0,0); //C# Black
		m00ksBody.constraints = RigidbodyConstraints2D.FreezeAll;
		yield return new WaitForSeconds(deathTime);
		StartCoroutine(Respawn());
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
