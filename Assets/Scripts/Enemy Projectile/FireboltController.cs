using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireboltController : MonoBehaviour
{
	public GameConstants gameConstants;
	public GameObject target1;
	
	private GameObject gooPool;
	private GameObject targetAreaMarker;
	private float explosionScale;
	private float speed;
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
		speed = gameConstants.fireboltSpeed;
		gooPool = gameConstants.gooPool;
		
		itemSprite.flipX = true;
		
		targetLocation = target1.transform.position;
		targetAreaMarker = gameConstants.fireboltTargetArea;
		targetArea = Instantiate(targetAreaMarker, targetLocation, transform.rotation);
		
		explosionScale = gameConstants.fireboltExplosionScale;
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
		GameObject goo = Instantiate(gooPool, transform.position, transform.rotation);
		goo.transform.localScale = transform.localScale;
		OnBecameInvisible();
	}	
}
