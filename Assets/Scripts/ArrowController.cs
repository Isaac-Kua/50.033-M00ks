using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
	private Rigidbody2D itemBody;
	private SpriteRenderer itemSprite;
	public float speed = 15;

	void Start()
	{
		itemBody = GetComponent<Rigidbody2D>();
		itemSprite = GetComponent<SpriteRenderer>();
	}
	
    // Update is called once per frame
    void Update()
    {
        // MoveItem();
    }
	
	void  OnBecameInvisible()
	{
		Destroy(gameObject);	
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("M00ks"))
		{
			OnBecameInvisible();
		}
	}
}
