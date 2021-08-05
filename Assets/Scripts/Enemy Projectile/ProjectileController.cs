using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
	public GameObject owner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter2D(Collision2D other)
    {
        if (!gameObject.CompareTag("Player") && !(gameObject.name == "Barathrum(Clone)"))
        {

            if (gameObject.name == "Firebolt(Clone)")
            {
                gameObject.GetComponent<FireboltController>().Explode();
            }
            else if (!gameObject.CompareTag("Debris") && !(gameObject.name == "ZangiefFist(Clone)") && !(gameObject.name == "KnockbackProjectile") && !(gameObject.name == "JuggernautBubble(Clone)"))
            {
                if (other.gameObject != owner){
                    Destroy(gameObject);
                }
            }
        }
        if (!gameObject.CompareTag("PlayerArrow")){
            if (other.gameObject.CompareTag("Altar"))
            {
                Player1Manager.centralManagerInstance.damageAltar();
            }
        }
    }
}
