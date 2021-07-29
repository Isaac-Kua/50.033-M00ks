using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VengeanceDeathPassive : MonoBehaviour
{
    private  GameConstants gameConstants;
    // Start is called before the first frame update
    void Start()
    {
        gameConstants = GetComponent<UpgradeManager>().gameConstants;
    }

    // Update is called once per frame
    void Update()
    {
        gameConstants = GetComponent<UpgradeManager>().gameConstants;
        if (GetComponent<UpgradeManager>().vengeanceDeath){
			if (GetComponent<M00ksDeathHandler>().myLives < 1 && !GetComponent<M00ksDeathHandler>().Dead){
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
