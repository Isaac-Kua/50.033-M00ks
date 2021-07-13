using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class M00ks1Controller : MonoBehaviour
{
	
	public float maxSpeed = 10;
	public float speed = 20;
	public float stunTime = 3f;
	public float deathTime = 3f;
	public float chargeDuration = 0.05f;
	public float pauseDuration = 0.1f;
	public float slowTime = 3f;
	public float slowRatio = 5f;
	public bool Dead = false;
	public Vector3 previousLocation;
	public GameObject shadow;
	public float teleportDuration =1f;
	public Vector2 moveDirection;
	public Vector2 faceDirection;
	public bool Immunity = false;

	private Rigidbody2D m00ksBody;
	private SpriteRenderer m00ksSprite;
	private Collider2D m00ksCollider;
	private bool Brittle = false;
	private bool Slow = false;





    // Start is called before the first frame update
    void Start()
    {
		m00ksBody = GetComponent<Rigidbody2D>();
		m00ksSprite = GetComponent<SpriteRenderer>();
		m00ksCollider = GetComponent<Collider2D>();
		previousLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {	
    }
	
	void FixedUpdate()
	{
		Move();
		StartCoroutine(WhatWasI());
		// Debug.Log(previousLocation);
		shadow.transform.position = previousLocation;
	}
	
	public void OnMove(InputValue value)
	{
		moveDirection = value.Get<Vector2>().normalized;
		if (moveDirection.magnitude!=0)
		{
			faceDirection = moveDirection;
		}
	}

    void Move()
    {
        m00ksBody.velocity = new Vector2(moveDirection.x*speed, moveDirection.y*speed);
    }

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, faceDirection*5);
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		if(!Dead && !Immunity){
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
		if(!Dead && !Immunity){
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

	void testDash()
	{
		Debug.Log("Dashed");
	}
	
	IEnumerator WhatWasI(){
		Vector3 trackedLocation = transform.position;
		yield return new WaitForSeconds(teleportDuration);
		previousLocation = trackedLocation;
	}
	// void Dash() 
	// {
	// 	Immunity = true;
	// 	m00ksCollider.isTrigger = true;
	// 	m00ksBody.AddRelativeForce(m00ksBody.velocity.normalized*dashSpeed, ForceMode2D.Impulse);
	// 	StartCoroutine(StopDash());
	// }
	
	// IEnumerator StopDash()
	// {
	// 	yield return new WaitForSeconds(chargeDuration);
	// 	m00ksBody.velocity = Vector2.zero;
	// 	yield return new WaitForSeconds(pauseDuration);
	// 	m00ksCollider.isTrigger = false;
	// 	Immunity = false;
	// }
}
