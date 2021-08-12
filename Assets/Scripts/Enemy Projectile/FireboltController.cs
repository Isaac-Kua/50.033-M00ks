using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireboltController : MonoBehaviour
{
	public GameConstants gameConstants;
	public GameObject target1;
	
	private GameObject gooPool;
	private GameObject targetAreaMarker;
	private bool exploded = false;
	private Rigidbody2D itemBody;
	private SpriteRenderer itemSprite;
	private Vector3 targetLocation;
	private Collider2D itemCollider;
	public GameObject targetArea;
	public GameObject gameManager;

	void Start()
	{
		itemBody = GetComponent<Rigidbody2D>();
		itemSprite = GetComponent<SpriteRenderer>();
		itemCollider = GetComponent<Collider2D>();
		targetLocation = target1.transform.position;
		gooPool = gameConstants.gooPool;
		
		itemSprite.flipX = true;
		
		targetLocation = target1.transform.position;
		targetArea = Instantiate(gameConstants.fireboltTargetArea, targetLocation, transform.rotation);

		Vector2 dir = (targetLocation - this.transform.position).normalized;
		Vector3 eulerAngle = new Vector3(0, 0, Vector2.SignedAngle(Vector2.right, dir));
		Quaternion angle = new Quaternion(0, 0, 0, 0);
		angle.eulerAngles = eulerAngle;
		transform.rotation = angle;
	}
		
    // Update is called once per frame
    void Update()
    {
		if (transform.position != targetLocation && !exploded)
		{
			transform.position = Vector2.MoveTowards(transform.position, targetLocation, gameManager.GetComponent<GameManager>().currentLevel.fireboltSpeed * Time.deltaTime);
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
	
	public void Explode()
	{
		Destroy(targetArea);
		exploded = true;
		transform.localScale = new Vector3(gameManager.GetComponent<GameManager>().currentLevel.fireboltExplosionScale, gameManager.GetComponent<GameManager>().currentLevel.fireboltExplosionScale,0);
		GameObject goo = Instantiate(gooPool, transform.position, new Quaternion(0, 0, 0, 0));
		goo.transform.localScale = transform.localScale;
		OnBecameInvisible();
	}	
}
