using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
	public GameConstants gameConstants;
	public GameObject gameManager;
	public GameObject target1;
	
	public bool engaged = false;
	private GameObject sword;
	
   	private Rigidbody2D itemBody;
	private SpriteRenderer itemSprite;
	
	void Start()
	{
		itemBody = GetComponent<Rigidbody2D>();
		itemSprite = GetComponent<SpriteRenderer>();
		sword = gameConstants.knightSword;
	}

    // Update is called once per frame
    void Update()
    {
		transform.localScale = new Vector3(transform.localScale.x * gameManager.GetComponent<GameManager>().currentLevel.knightShieldWidth, transform.localScale.y, transform.localScale.z);
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
		gameObject.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("SwingNow");
		yield return new WaitForSeconds(gameConstants.knightWindUpTime);
		engaged = false;
		Vector3 dir = (target1.transform.position - this.transform.position).normalized;
		Quaternion angle = new Quaternion(0,0,0,0);
		Vector3 eulerAngle = new Vector3(0,0,90+Vector2.SignedAngle(Vector2.right,dir));
		angle.eulerAngles = eulerAngle;

		GameObject stroke = Instantiate(sword, transform.position + 2f*dir, transform.rotation);
		stroke.GetComponent<SwordController>().gameManager = gameManager;
		stroke.GetComponent<ProjectileController>().owner = gameObject.transform.parent.gameObject;
		stroke.transform.parent = gameObject.transform;
		stroke.transform.rotation = angle;
		stroke.GetComponent<SwordController>().shield = gameObject.transform.parent.gameObject;
		
		itemBody.constraints = RigidbodyConstraints2D.None;
	}
}
