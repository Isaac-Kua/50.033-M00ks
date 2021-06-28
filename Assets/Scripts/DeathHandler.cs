using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
	private SpriteRenderer npcSprite;
	public GameObject soul;

    // Start is called before the first frame update
    void Start()
    {
        npcSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void onDeath()
	{
		if (gameObject.tag == "Knight"){
			Destroy(gameObject.GetComponent<KnightController>().myShield);
		}
		Destroy(gameObject);	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		// change this to attack animation 
		if (other.gameObject.CompareTag("Player") && !gameObject.CompareTag("DashingBarbarian"))
		{
			Debug.Log("Player killed " + gameObject.tag);
			StartCoroutine(death());
		}
	}

	IEnumerator death()
	{
		npcSprite.color = Color.black;
		yield return new WaitForSeconds(1f);
		Instantiate(soul, new  Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
		onDeath();
	}

}
