using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceboltController : MonoBehaviour
{
	public GameConstants gameConstants; 
	public GameObject gameManager;
	public GameObject target1;

	private float lifeTime;

	private Vector2 dir;
	private Quaternion angle = new Quaternion(0, 0, 0, 0);
	private bool exploded = false;
	private Rigidbody2D itemBody;
	private SpriteRenderer itemSprite;
	
	void Start()
	{
		itemBody = GetComponent<Rigidbody2D>();
		itemSprite = GetComponent<SpriteRenderer>();
		itemSprite.flipX = true;
		StartCoroutine(Lifetime());	
	}
		
    // Update is called once per frame
    void Update()
    {
		dir = (target1.transform.position - this.transform.position).normalized;
		Vector3 eulerAngle = new Vector3(0, 0, Vector2.SignedAngle(Vector2.right, dir));
		angle.eulerAngles = eulerAngle;
		transform.rotation = angle;
		if (!exploded)
		{ 
			itemBody.velocity = (target1.transform.position - transform.position).normalized* gameManager.GetComponent<GameManager>().currentLevel.iceboltSpeed;
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
		GameObject debris = Instantiate(gameConstants.debris, transform.position, new Quaternion(0,0,0,0));
		debris.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
		OnBecameInvisible();
	}
	
	IEnumerator Lifetime(){
		yield return new WaitForSeconds(gameConstants.iceboltLifeTime);
		Explode();
	}
	
}
