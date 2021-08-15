using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
	public GameConstants gameConstants;
	public bool engaged;
   	private Rigidbody2D itemBody;
	private SpriteRenderer itemSprite;
	
	void Start()
	{
		engaged = false;
		itemBody = GetComponent<Rigidbody2D>();
		itemSprite = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
		if (transform.parent.gameObject != null){
			transform.localScale = new Vector3(transform.localScale.x , GameManager.Instance.currentLevel.knightShieldWidth, transform.localScale.z);
		} else {	
			Destroy(gameObject);
		}
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
		yield return new WaitForSeconds(gameConstants.knightWindUpTime);
		gameObject.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("SwingNow");
		engaged = false;
		itemBody.constraints = RigidbodyConstraints2D.FreezeRotation;
	}
}
