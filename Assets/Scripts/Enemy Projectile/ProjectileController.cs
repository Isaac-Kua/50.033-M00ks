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

    void OnTriggerEnter2D(Collider2D other){
        if(gameObject.CompareTag("Debris")){

            if(other.gameObject.name == "Kaiten(Clone)")
            {
                if(other.gameObject.GetComponent<KaitenController>().HeavyMod){
                    Destroy(gameObject);

                }
            }else if(other.gameObject.name == "M00ks1(Clone)"){
                if(other.gameObject.GetComponent<UpgradeManager>().HeavyMod){
                    Destroy(gameObject);
                }
            }
        }
        
    }
	
	void OnCollisionEnter2D(Collision2D other)
    {
        if(gameObject.CompareTag("Debris")){

            if(other.gameObject.name == "Kaiten(Clone)")
            {
                if(other.gameObject.GetComponent<KaitenController>().HeavyMod){
                    Destroy(gameObject);

                }
            }else if(other.gameObject.name == "M00ks1(Clone)" && other.gameObject.CompareTag("PlayerArrow")){
                if(other.gameObject.GetComponent<UpgradeManager>().HeavyMod){
                    Destroy(gameObject);
                }
            }
        }
        if(HeavyMod){
            if(other.gameObject.CompareTag("Debris"))
            {
                if(gameObject.name == "PlayerArrow(Clone)" ||  gameObject.name == "PlayerSpike(Clone)"){
                    Destroy(other.gameObject);
                }else if(gameObject.name == "M00ks1(Clone)" && gameObject.CompareTag("PlayerArrow")){
                    Destroy(other.gameObject);
                }else if(gameObject.name == "Kaiten(Clone)")
                {
                    Destroy(other.gameObject);
                }
            }
        }
        if (!(gameObject.name == "PlayerSpike(Clone)") && !gameObject.CompareTag("Player") && !(gameObject.name == "Barathrum(Clone)") && !(gameObject.name == "Barathrum") && !(gameObject.name == "M00ks1(Clone)"))
        {
            if (gameObject.name == "Firebolt(Clone)")
            {
                gameObject.GetComponent<FireboltController>().Explode();
            }

            else if (!gameObject.CompareTag("Debris") && !(gameObject.name == "ZangiefFist(Clone)") && !(gameObject.name == "KnockbackProjectile") && !(gameObject.name == "JuggernautBubble(Clone)"))
            {
                if (other.gameObject != owner){
                    if(!(gameObject.name == "M00ks1(Clone)"))
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
        if (!(gameObject.CompareTag("PlayerArrow")) && !gameObject.CompareTag("Player") && !(gameObject.name == "M00ks1(Clone)")){
            if (other.gameObject.CompareTag("Altar"))
            {
                Player1Manager.centralManagerInstance.damageAltar();
            }
        }
    }
}
