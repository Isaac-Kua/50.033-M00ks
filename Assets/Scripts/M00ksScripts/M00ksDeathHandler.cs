using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M00ksDeathHandler : MonoBehaviour
{
	public GameConstants gameConstants;
	public List<MonoBehaviour> activeAbilities;
	public MonoBehaviour movementAbility;
	public bool Dead = false;
	public bool Immunity = false;
	public bool Brittle = false;
	public int lives;
	private bool Slow = false;
	private float launchDuration;
	private float stunTime;
	private Rigidbody2D m00ksBody;
	private float deathTime;
	private SpriteRenderer m00ksSprite;
	public int myLives;
	public GameObject lastHit;
	
	// Start is called before the first frame update
	void Start()
	{
		m00ksBody = GetComponent<Rigidbody2D>();
		m00ksSprite = GetComponent<SpriteRenderer>();
		lives = gameConstants.defaultLives;
		myLives = lives;
		deathTime = gameConstants.deathTime;
		stunTime = gameConstants.stunTime;
		launchDuration = gameConstants.launchDuration;
	}

	// Update is called once per frame
	void Update()
	{
		if (myLives == 0 && !Dead){
			StartCoroutine(Death());
		}
	}
	
	void onHit(GameObject other){
		Debug.Log(other.GetComponent<ProjectileController>().owner);
		lastHit = other.GetComponent<ProjectileController>().owner;
		myLives -=1;
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(!Dead && !Immunity){
			if (other.gameObject.CompareTag("KnightShield"))
			{
				OnStunned();
			} else if (other.gameObject.CompareTag("Arrow") || other.gameObject.CompareTag("Firebolt")) {
				onHit(other.gameObject);
			} else if (other.gameObject.CompareTag("Icebolt")) {
				if (!Brittle){
					OnStunned();
				} else if (Brittle){
					onHit(other.gameObject);
				}
			}
		}

		if (this.tag == "PlayerArrow" && other.gameObject.CompareTag("Debris")) {
			Rigidbody2D debris = other.gameObject.GetComponent<Rigidbody2D>();
			debris.constraints = RigidbodyConstraints2D.FreezeRotation;
			debris.velocity = m00ksBody.velocity;
			this.tag = "Player";
			other.gameObject.tag = "PlayerArrow";
			StartCoroutine(Disintegrate(other.gameObject));
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(!Immunity){
			if (other.gameObject.CompareTag("DashingBarbarian")){
				onHit(other.gameObject);
			} else if (other.gameObject.CompareTag("KnightSword")){
				onHit(other.gameObject);
			}
		}
	}
	
	// void OnTriggerEnter2D(Collider2D other)
	// {
		// if(!Immunity){
			// if (other.gameObject.CompareTag("DashingBarbarian"))
			// {
				// Debug.Log("Hit By Barbarian");
				// onHit();
			// } else if (other.gameObject.CompareTag("KnightSword")){
				// Debug.Log("Hit By Knight");
				// onHit();
			// }
		// }
		// if(!Dead && !Immunity){
			// if (other.gameObject.CompareTag("KnightShield"))
			// {
				// Debug.Log("Collided with KnightShield");
				// StartCoroutine(Stunned());
			// } else if (other.gameObject.CompareTag("Arrow") || other.gameObject.CompareTag("Firebolt")) {
				// onHit();
			// } else if (other.gameObject.CompareTag("Icebolt")) {
				// if (!Brittle){
					// Brittle = true;
					// // StartCoroutine(Stunned());
				// } else if (Brittle){
					// Debug.Log("Hit by IceWizard");
					// onHit();
				// }
			// }
		// }
	// }
	
	public void OnStunned(){
		StartCoroutine(Stunned());
	}
	
	void moveDisabled (){
		m00ksBody.constraints = RigidbodyConstraints2D.FreezeAll;
		movementAbility.enabled = false;
	}
	
	public void moveEnabled (){
		m00ksBody.constraints = RigidbodyConstraints2D.FreezeRotation;
		movementAbility.enabled = true;
	}
	
	public void allDisable(){
		moveDisabled();
		foreach (MonoBehaviour script in activeAbilities){
			script.enabled = false;
		}
		
	}
	
	public void allEnable(){
		moveEnabled();
		foreach (MonoBehaviour script in activeAbilities){
			script.enabled = true;
		}
	}

	IEnumerator  Stunned(){
		Brittle = true;
		allDisable();
		m00ksSprite.material.color = new Color(0,0,1); //C# blue
		yield return new WaitForSeconds(stunTime);
		if (!Dead){
			allEnable();
			Brittle = false;
		m00ksSprite.material.color = new Color(1,1,1); //C# white
		}
	}
	
	IEnumerator  Death(){
		m00ksSprite.material.color = new Color(0,0,0); //C# black
		Dead = true;
		Immunity = true;
		allDisable();
		yield return new WaitForSeconds(deathTime);
		allEnable();
		StartCoroutine(Respawn());
	}
	
	
	IEnumerator Respawn(){
		m00ksSprite.material.color = new Color(0,1,0); //C# green
		lastHit = null;
		yield return new WaitForSeconds(0.5f);
		m00ksSprite.material.color = new Color(1,1,1); //C# white
		Brittle = false;
		Immunity = false;
		Dead = false;
		Slow = false;
		myLives = lives;
	}
	
	// Ony used for Knockback
	IEnumerator Disintegrate(GameObject debrisProjectile)
	{
		yield return new WaitForSeconds(launchDuration);
		debrisProjectile.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		debrisProjectile.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
		debrisProjectile.tag = "Debris";
	}
}
