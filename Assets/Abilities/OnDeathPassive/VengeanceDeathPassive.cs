using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VengeanceDeathPassive : MonoBehaviour
{
    public  GameConstants gameConstants;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       	if (GetComponent<UpgradeManager>().vengeanceDeath){
			if (GetComponent<M00ksDeathHandler>().myLives == 0 && !GetComponent<M00ksDeathHandler>().Dead){
				GameObject other = GetComponent<M00ksDeathHandler>().lastHit;
				if(other.CompareTag("Player")){
					other.GetComponent<M00ksDeathHandler>().OnStunned();
				} else {
					other.GetComponent<DeathHandler>().OnStunned();
				}
			}
		} 
    }
}
