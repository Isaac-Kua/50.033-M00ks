using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrowController : MonoBehaviour
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
	
	void OnBecameInvisible()
	{
		Destroy(gameObject);	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("KnightShield"))
		{
			Destroy(gameObject);
		}
		else if (other.gameObject.CompareTag("Knight"))
		{
			Destroy(other.gameObject);
		}
	}
}