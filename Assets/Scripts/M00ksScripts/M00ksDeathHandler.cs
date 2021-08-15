using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M00ksDeathHandler : MonoBehaviour
{
	public GameConstants gameConstants;
	public List<MonoBehaviour> activeAbilities;
	public MonoBehaviour movementAbility;
	public GameObject vision;
	public bool Dead = false;
	public bool Immunity = false;
	public bool Brittle = false;
	public bool Invisible = false;
	public bool Stun = false;
	public int lives;
	public float deathTime;
	public int myLives;
	public GameObject lastHit;
	public int deaths = 0;
	public int enemykills = 0;
	public int playerkills = 0;

	private float launchDuration;
	private float stunTime;
	private Rigidbody2D m00ksBody;
	private SpriteRenderer m00ksSprite;
	private Animator m00ksAnimator;
	private GameObject stunAnim;

	// Start is called before the first frame update
	void Start()
	{
		m00ksBody = GetComponent<Rigidbody2D>();
		m00ksSprite = GetComponent<SpriteRenderer>();
		m00ksAnimator = GetComponent<Animator>();

		lives = gameConstants.defaultLives;
		myLives = lives;
		deathTime = gameConstants.deathTime;
		stunTime = gameConstants.stunTime;
		launchDuration = gameConstants.launchDuration;
		AltarManager.NextStage2 += resetDeathCounter;

		stunAnim = Instantiate(gameConstants.stunAnimation, transform.position, transform.rotation);
		stunAnim.transform.parent = transform;
		stunAnim.transform.position = gameConstants.stunPosition;
		stunAnim.SetActive(false);
	}
	private void OnDestroy() {
		AltarManager.NextStage2 -= resetDeathCounter;
	}

	// Update is called once per frame
	void Update()
	{
		if (Dead && !GetComponent<UpgradeManager>().crawlDeath)
		{
			allDisable();
		}
		stunAnim.transform.position = transform.position + gameConstants.stunPosition;
		m00ksAnimator.SetBool("Dead", Dead);
		if (myLives < 1 && !Dead){
			m00ksAnimator.SetTrigger("Death");
			StartCoroutine(Death());
			if (lastHit.CompareTag("Player")) {
				lastHit.GetComponent<M00ksDeathHandler>().playerkills++;
				lastHit.GetComponent<UpgradeManager>().onKill(this.gameObject);
			}
		}
	}
	
	void onHit(GameObject other){
		Invisible = false;
		vision.SetActive(true);
		// Debug.Log(other.GetComponent<ProjectileController>().owner);
		lastHit = other.GetComponent<ProjectileController>().owner;
		myLives -=1;
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(!Dead && !Immunity){
			if (other.gameObject.CompareTag("KnightShield"))
			{
				OnStunned();
			}
			else if (other.gameObject.CompareTag("Arrow") || other.gameObject.CompareTag("Firebolt"))
			{
				onHit(other.gameObject);
			}
			else if (other.gameObject.CompareTag("Icebolt"))
			{
				if (!Brittle)
				{
					OnStunned();
				}
				else if (Brittle)
				{
					onHit(other.gameObject);
				}
			}
			else if (other.gameObject.CompareTag("PlayerArrow")) {
				if (other.gameObject.GetComponent<ProjectileController>().owner != this.gameObject)
				{
					onHit(other.gameObject);
				}
				else {
					Debug.Log("phew its just me");
				}
			}
		}

		if (this.tag == "PlayerArrow" && other.gameObject.CompareTag("Debris")) {
			Rigidbody2D debris = other.gameObject.GetComponent<Rigidbody2D>();
			debris.constraints = RigidbodyConstraints2D.FreezeRotation;
			debris.velocity = m00ksBody.velocity*gameConstants.knockbackStrength;
			this.tag = "Player";

			GetComponent<ProjectileController>().owner = gameObject;
			other.gameObject.GetComponent<ProjectileController>().owner = gameObject;
			other.gameObject.tag = "PlayerArrow";
			other.gameObject.name = "KnockbackProjectile";

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

		if (other.gameObject.CompareTag("PlayerArrow"))
		{
			if (other.gameObject.GetComponent<ProjectileController>().owner != this.gameObject)
			{
				onHit(other.gameObject);
			}
			else
			{
				Debug.Log("phew its just me");
			}
		}
	}
	
	public void OnStunned(){
		Invisible = false;
		m00ksBody.velocity = Vector2.zero;
		vision.SetActive(true);
		stunAnim.SetActive(true);
		Stun = true;
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
		stunAnim.SetActive(false);
		moveEnabled();
		foreach (MonoBehaviour script in activeAbilities){
			script.enabled = true;
		}
	}

	IEnumerator  Stunned(){
		Brittle = true;
		allDisable();
		yield return new WaitForSeconds(stunTime);
		if (!Dead){
			allEnable();
			Brittle = false;
			Stun = false;
		m00ksSprite.material.color = new Color(1,1,1); //C# white
		}
	}
	
	IEnumerator  Death(){
		m00ksSprite.material.color = new Color(0.3f,0.3f,0.3f); //C# black
		deaths++;
		Dead = true;
		Immunity = true;
		allDisable();
		DeathPassive();
		yield return new WaitForSeconds(deathTime);
		m00ksAnimator.SetTrigger("Respawn");
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
		Stun = false;
		allEnable();
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

	void resetDeathCounter(){
		deaths = 0;
		enemykills = 0;
		playerkills = 0;
	}

	void DeathPassive() {
		if (GetComponent<UpgradeManager>().vengeanceDeath)
		{
			GameObject other = GetComponent<M00ksDeathHandler>().lastHit;
			if (other.CompareTag("Player"))
			{
				other.GetComponent<M00ksDeathHandler>().OnStunned();
			}	else {
				other.GetComponent<DeathHandler>().OnStunned();
			}
		}

		else if (GetComponent<UpgradeManager>().kamikazeDeath)
		{
			GameObject Boom = Instantiate(gameConstants.kamikazePrefab, transform.position, transform.rotation);
			Boom.GetComponent<ProjectileController>().owner = gameObject;
		}

		else if (GetComponent<UpgradeManager>().soulswapDeath)
		{
			Vector3 selfPosition = transform.position;
			Vector3 killerPosition = GetComponent<M00ksDeathHandler>().lastHit.transform.position;

			lastHit.transform.position = selfPosition;
			transform.position = killerPosition;
		}

		if (GetComponent<UpgradeManager>().PacquiaoCombo)
		{
			GameObject other = GetComponent<M00ksDeathHandler>().lastHit;
			GameObject pew = Instantiate(gameConstants.WidowmakerArrow, other.transform.position, transform.rotation);
			pew.GetComponent<ProjectileController>().owner = gameObject;
		}
	}
}
