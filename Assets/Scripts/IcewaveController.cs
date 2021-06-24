using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcewaveController : MonoBehaviour
{
	public float lifeTime = 1f;
	public float meltTime = 2f;
	
	private Rigidbody2D itemBody;
	private SpriteRenderer itemSprite;
	
	void Start()
	{
		itemBody = GetComponent<Rigidbody2D>();
		itemSprite = GetComponent<SpriteRenderer>();
		StartCoroutine(Lifetime());	
	}
	
    // Update is called once per frame
    void Update()
    {
		
    }
	
	void  OnBecameInvisible()
	{
		Destroy(gameObject);	
	}
	
	void Explode()
	{
		itemBody.velocity = Vector2.zero;
		itemBody.bodyType = RigidbodyType2D.Static;
		itemSprite.material.color = new Color(0,0,1); //C#
		StartCoroutine(Debris());
	}
	
	IEnumerator Debris()
	{
		yield return new WaitForSeconds(meltTime);
		// Debug.Log("Ice wave melted");
		OnBecameInvisible();
	}
	
	IEnumerator Lifetime()
	{
		yield return new WaitForSeconds(lifeTime);
		// Debug.Log("Ice wave stopped");
		Explode();
	}
}
