using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
	public float speed = 5;
	public GameObject target1;
	
	
	private Rigidbody2D knightBody;
	private SpriteRenderer knightSprite;
	
    // Start is called before the first frame update
    void Start()
    {
        knightBody = GetComponent<Rigidbody2D>();
		knightSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		transform.position = Vector2.MoveTowards(transform.position, target1.transform.position, speed * Time.deltaTime);
    }
	
	void  onDeath()
	{
		Destroy(gameObject);	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		// change this to attack animation 
		if (other.gameObject.CompareTag("Player"))
		{
			Debug.Log("Player killed Knight");
			onDeath();
		}
	}
}
