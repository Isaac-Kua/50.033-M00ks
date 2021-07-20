using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
	public GameConstants gameConstants;
	public GameObject soul;
	public List<MonoBehaviour> activeAbilities;
	private SpriteRenderer npcSprite;
	private Rigidbody2D npcBody;

    // Start is called before the first frame update
    void Start()
    {
        npcSprite = GetComponent<SpriteRenderer>();
		npcBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void onDeath()
	{
		Destroy(gameObject);	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		// change this to attack animation 
		if (other.gameObject.CompareTag("Player") && !gameObject.CompareTag("DashingBarbarian"))
		{
			Debug.Log("Player killed " + gameObject.tag);
			StartCoroutine(death());
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("PlayerArrow"))
		{
			StartCoroutine(death());
		}
	}

	IEnumerator death()
	{
		npcSprite.color = Color.black;
		yield return new WaitForSeconds(1f);
		Instantiate(soul, new  Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
		onDeath();
	}
	
	public void OnStunned(){
		StartCoroutine(Stunned());
	}
	
	
	public void allDisable(){
		foreach (MonoBehaviour script in activeAbilities){
			script.enabled = false;
		}
		
	}
	
	public void allEnable(){
		foreach (MonoBehaviour script in activeAbilities){
			script.enabled = true;
		}
	}
	
	IEnumerator  Stunned(){
		npcBody.velocity = Vector2.zero;
		allDisable();
		npcSprite.material.color = new Color(0,0,1); //C# blue
		yield return new WaitForSeconds(gameConstants.stunTime);
		allEnable();
		npcSprite.material.color = new Color(1,1,1); //C# white
	}

}
