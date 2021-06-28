using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void  onDeath()
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
			onDeath();
		}
	}
}
