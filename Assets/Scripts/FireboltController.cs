using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireboltController : MonoBehaviour
{
	public float speed = 10;
	public float lifetime = 2f;
	public GameObject target1;
	
	private bool exploded = false;
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
			Explode();
		}
	}
	
	void Explode()
	{
		exploded = true;
		transform.localScale = new Vector3(2,2,0);
		StartCoroutine(Crater());
	}
	
	IEnumerator Crater(){
		yield return new WaitForSeconds(2f);
		OnBecameInvisible();
	}
	
	IEnumerator Lifetime(){
		yield return new WaitForSeconds(lifetime);
		Explode();
	}
	
}
