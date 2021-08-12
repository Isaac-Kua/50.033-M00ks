using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public bool HeavyMod = false;
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
        if (!gameObject.CompareTag("Player") && !(gameObject.name == "Barathrum(Clone)") && !(gameObject.name == "Barathrum"))
        {
            if (gameObject.name == "Firebolt(Clone)")
            {
                gameObject.GetComponent<FireboltController>().Explode();
            }
            else if (gameObject.name == "PlayerSpike(Clone)" && other.gameObject.CompareTag("Debris"))
            {
                if(gameObject.GetComponent<PlayerSpikeController>().HeavyMod)
                {
                    Destroy(other.gameObject);
                    Destroy(gameObject);
                }
            }
            else if (!gameObject.CompareTag("Debris") && !(gameObject.name == "ZangiefFist(Clone)") && !(gameObject.name == "KnockbackProjectile") && !(gameObject.name == "JuggernautBubble(Clone)"))
            {
                if (other.gameObject != owner){
                    Destroy(gameObject);
                }
            }
        }
        if (!gameObject.CompareTag("PlayerArrow") && !gameObject.CompareTag("Player")){
            if (other.gameObject.CompareTag("Altar"))
            {
                Player1Manager.centralManagerInstance.damageAltar();
            }
        }
    }
}
