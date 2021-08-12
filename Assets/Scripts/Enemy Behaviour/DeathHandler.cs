using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
	public GameConstants gameConstants;
	public GameObject soul;
	public GameObject lastHit;
	public List<MonoBehaviour> activeAbilities;

	public bool ammo;
	private SpriteRenderer npcSprite;
	private Rigidbody2D npcBody;
	private Collider2D npcCollider;

	private Animator npcAnimator;
	private bool dead = false;
	private GameObject stunAnim;


	// Start is called before the first frame update
	void Start()
    {
        npcSprite = GetComponent<SpriteRenderer>();
		npcBody = GetComponent<Rigidbody2D>();
		npcCollider = GetComponent<Collider2D>();
		npcAnimator = GetComponent<Animator>();
		stunAnim = Instantiate(gameConstants.stunAnimation, transform.position, transform.rotation);
		stunAnim.transform.parent = transform;
		stunAnim.transform.position = gameConstants.stunPosition;
		stunAnim.SetActive(false);
		ammo = true;
	}

    // Update is called once per frame
    void Update()
    {
        stunAnim.transform.position = transform.position + gameConstants.stunPosition;
	}
	
	void onDeath()
	{
		dead = false;
		allEnable();
		//npcSprite.color = Color.white;
		npcCollider.enabled = true;
		this.gameObject.SetActive(false);
		ammo = true;
	}
	

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("PlayerArrow") && !dead)
		{
			dead = true;
			Debug.Log(other.gameObject.GetComponent<ProjectileController>().owner.name);
			StartCoroutine(death(other.gameObject));
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("PlayerArrow") && !dead)
		{
			dead = true;
			Debug.Log(other.gameObject.GetComponent<ProjectileController>().owner.name);
			StartCoroutine(death(other.gameObject));
		}
	}
	

	IEnumerator death(GameObject killer)
	{
		allDisable();
		npcAnimator.SetTrigger("Death");
		npcCollider.enabled = false;
		lastHit = killer.GetComponent<ProjectileController>().owner;
		if (lastHit.CompareTag("Player"))
		{
			lastHit.GetComponent<UpgradeManager>().onKill(this.gameObject);
			lastHit.GetComponent<M00ksDeathHandler>().enemykills++;
		}
		//npcSprite.color = Color.black;
		yield return new WaitForSeconds(gameConstants.deathFadeTime);
		Instantiate(soul, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
		onDeath();
	}
	
	public void OnStunned(){
		StartCoroutine(Stunned());
	}
	
	
	public void allDisable(){
		npcBody.constraints = RigidbodyConstraints2D.FreezeAll;
		foreach (MonoBehaviour script in activeAbilities){
			script.enabled = false;
		}
		
	}
	
	public void allEnable(){
		stunAnim.SetActive(false);
		npcBody.constraints = RigidbodyConstraints2D.FreezeRotation;
		foreach (MonoBehaviour script in activeAbilities){
			script.enabled = true;
		}
	}
	
	IEnumerator  Stunned(){
		stunAnim.SetActive(true);
		npcBody.velocity = Vector2.zero;
		allDisable();
		yield return new WaitForSeconds(gameConstants.stunTime);
		if (!dead) {
			allEnable();
        }
	}

}
