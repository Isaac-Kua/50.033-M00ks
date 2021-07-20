using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceboltController : MonoBehaviour
{
	public GameConstants gameConstants;
	public GameObject target1;

	private float speed;
	private float lifeTime;
	private float meltTime;
	
	private bool exploded = false;
	private Rigidbody2D itemBody;
	private SpriteRenderer itemSprite;
	
	void Start()
	{
		itemBody = GetComponent<Rigidbody2D>();
		itemSprite = GetComponent<SpriteRenderer>();
		
		lifeTime = gameConstants.iceboltLifeTime;
		meltTime = gameConstants.iceboltMeltTime;
		speed = gameConstants.iceboltSpeed ;
		
		StartCoroutine(Lifetime());	
	}
		
    // Update is called once per frame
    void Update()
    {
		if (!exploded)
		{
			transform.position = Vector2.MoveTowards(transform.position, target1.transform.position, speed * Time.deltaTime);
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
		exploded = true;
		transform.localScale = new Vector3(1.5f,1.5f,0);
		itemSprite.material.color = new Color(0,0,1); //C#
		gameObject.tag = "Debris";
		StartCoroutine(Debris());
	}
	
	IEnumerator Debris(){
		yield return new WaitForSeconds(meltTime);
		OnBecameInvisible();
	}
	
	IEnumerator Lifetime(){
		yield return new WaitForSeconds(lifeTime);
		Explode();
	}
	
}
