using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
	private Rigidbody2D itemBody;
	private SpriteRenderer itemSprite;
	
	void Start()
	{
		itemBody = GetComponent<Rigidbody2D>();
		itemSprite = GetComponent<SpriteRenderer>();
	}
	
    // Update is called once per frame
    void Update()
    {
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
}
