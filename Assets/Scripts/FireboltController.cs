using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireboltController : MonoBehaviour
{
	public float speed = 10;
	public float explosionTime = 0.1f;
	public float lifeTime = 2f;
	public GameObject target1;
	public GameObject targetAreaMarker;
	public float explosionScale = 3;
	
	private bool exploded = false;
	private Rigidbody2D itemBody;
	private SpriteRenderer itemSprite;
	private Vector3 targetLocation;
	private Collider2D itemCollider;
	private GameObject targetArea;
	
	void Start()
	{
		itemBody = GetComponent<Rigidbody2D>();
		itemSprite = GetComponent<SpriteRenderer>();
		itemCollider = GetComponent<Collider2D>();
		targetLocation = target1.transform.position;
		targetArea = Instantiate(targetAreaMarker, targetLocation, transform.rotation);
		targetArea.GetComponent<TargetAreaController>().explosionScale = explosionScale;
	}
		
    // Update is called once per frame
    void Update()
    {
		if (transform.position != targetLocation && !exploded)
		{
			transform.position = Vector2.MoveTowards(transform.position, targetLocation, speed * Time.deltaTime);
		} else {
			Explode();
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
		Destroy(targetArea);
		exploded = true;
		transform.localScale = new Vector3(explosionScale,explosionScale,0);
		StartCoroutine(Crater());
	}
	
	IEnumerator Crater(){
		yield return new WaitForSeconds(explosionTime);
		transform.position = new Vector3(transform.position.x, transform.position.y,1);
		itemCollider.isTrigger = true;
		gameObject.tag = "Goo";
		yield return new WaitForSeconds(lifeTime);
		OnBecameInvisible();
	}
	
}
