using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianController : MonoBehaviour
{
	public float speed = 5;
	public float maxRange = 15;
	public float dashSpeed = 100;
	public GameObject target1;
	public float chargeDuration = 0.05f;
	public float pauseDuration = 0.1f;
	public float windUpTime = 3f;
	
	private float distance;
	private float charges = 3;
	private bool dashing = false;
	private Rigidbody2D barbBody;
	private SpriteRenderer barbSprite;
	private PolygonCollider2D barbCollider;
	
    // Start is called before the first frame update
    void Start()
    {
        barbBody = GetComponent<Rigidbody2D>();
		barbSprite = GetComponent<SpriteRenderer>();
		barbCollider = GetComponent<PolygonCollider2D>();
    }

	void FixedUpdate()
	{
		if (Input.GetKeyUp("f"))
		{
			charges = 3;
		}
	}
	
    // Update is called once per frame
    void Update()
    {
		distance = Vector2.Distance(transform.position, target1.transform.position);
 
        if (charges == 0)
        {
             transform.position = Vector2.MoveTowards(transform.position, -1*target1.transform.position, speed * Time.deltaTime);
        }
		 
		else if (charges > 0 && !dashing)
		{
			Dash();
		} 
    }
	
	void Dash() 
	{
		dashing = true;
		barbCollider.isTrigger = true;
		charges -= 1;
		Vector2 v2 = (target1.transform.position - this.transform.position);
		barbBody.AddRelativeForce(v2.normalized*dashSpeed, ForceMode2D.Impulse);
		StartCoroutine(StopDash());
	}
	
	IEnumerator StopDash()
	{
		yield return new WaitForSeconds(chargeDuration);
		barbBody.velocity = Vector2.zero;
		yield return new WaitForSeconds(pauseDuration);
		dashing = false;
		barbCollider.isTrigger = false;
		if (charges == 0){
			barbSprite.material.color = new Color(1,1,0.5f); //C#
			yield return new WaitForSeconds(windUpTime);
			barbSprite.material.color = new Color(1,0,0); //C#
			charges = 3;
		}
	}
	
	void  onDeath()
	{
		Destroy(gameObject);	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		// change this to attack animation 
		if (other.gameObject.CompareTag("Player") && !dashing)
		{
			Debug.Log("Player killed Barbarian");
			onDeath();
		}
	}
}
