using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireboltController : MonoBehaviour
{
	private Rigidbody2D itemBody;
	private SpriteRenderer itemSprite;
	public float speed = 20;
	public GameObject target1;
    public float angleChangingSpeed;
	private bool exploded = false;
	
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
			transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, speed * Time.deltaTime);
		}
    }
	
	void  OnBecameInvisible()
	{
		Destroy(gameObject);	
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("M00ks"))
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
		yield return new WaitForSeconds(3f);
		Explode();
	}
	
}
