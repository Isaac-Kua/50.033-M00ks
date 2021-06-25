using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
	public GameObject sword;
	public GameObject target1;
	public float swordLength = 1f;
	public float shieldWidth = 1f;
	public float windUpTime = 3f;
	public bool engaged = false;
	
   	private Rigidbody2D itemBody;
	private SpriteRenderer itemSprite;
	
	void Start()
	{
		itemBody = GetComponent<Rigidbody2D>();
		itemSprite = GetComponent<SpriteRenderer>();
		transform.localScale = new Vector3(transform.localScale.x*shieldWidth,transform.localScale.y,transform.localScale.z);
	}

    // Update is called once per frame
    void Update()
    {
    }
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player")) {
				engaged = true;
				itemBody.constraints = RigidbodyConstraints2D.FreezeAll;
				StartCoroutine(Swing());
		}
	}
	
	IEnumerator Swing(){
		yield return new WaitForSeconds(windUpTime);
		
		Vector3 dir = (target1.transform.position - this.transform.position).normalized;
		Quaternion angle = new Quaternion(0,0,0,0);
		Vector3 eulerAngle = new Vector3(0,0,90+Vector2.SignedAngle(Vector2.right,dir));
		angle.eulerAngles = eulerAngle;
		
		GameObject stroke = Instantiate(sword, transform.position + 2f*dir, transform.rotation);
		stroke.transform.rotation = angle;
		stroke.GetComponent<SwordController>().length = swordLength;
		stroke.GetComponent<SwordController>().shield = gameObject;
		
		itemBody.constraints = RigidbodyConstraints2D.None;
		engaged = false;
	}
}
