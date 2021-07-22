using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceboltController : MonoBehaviour
{
	public GameConstants gameConstants;
	public GameObject target1;

	private float speed;
	private float lifeTime;
	
	private bool exploded = false;
	private Rigidbody2D itemBody;
	private SpriteRenderer itemSprite;
	
	void Start()
	{
		itemBody = GetComponent<Rigidbody2D>();
		itemSprite = GetComponent<SpriteRenderer>();
		
		lifeTime = gameConstants.iceboltLifeTime;
		speed = gameConstants.iceboltSpeed ;
		
		StartCoroutine(Lifetime());	
	}
		
    // Update is called once per frame
    void Update()
    {
		if (!exploded)
		{
			itemBody.velocity = (target1.transform.position - transform.position).normalized*speed;
		}
    }
	
	void  OnBecameInvisible()
	{
		Destroy(gameObject);	
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{   
			OnBecameInvisible();
		}
	}
	
	void Explode()
	{
		GameObject debris = Instantiate(gameConstants.debris, transform.position, transform.rotation);
		debris.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
		OnBecameInvisible();
	}
	
	IEnumerator Lifetime(){
		yield return new WaitForSeconds(lifeTime);
		Explode();
	}
	
}
