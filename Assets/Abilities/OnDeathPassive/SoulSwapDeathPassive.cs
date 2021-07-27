using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSwapDeathPassive : MonoBehaviour
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
        if (GetComponent<UpgradeManager>().soulswapDeath){
			if (GetComponent<M00ksDeathHandler>().myLives <1 && !GetComponent<M00ksDeathHandler>().Dead){
				Vector3 selfPosition = transform.position;
				Vector3 killerPosition = GetComponent<M00ksDeathHandler>().lastHit.transform.position;
				
				GetComponent<M00ksDeathHandler>().lastHit.transform.position = selfPosition;
				transform.position = killerPosition;
			}
		} 
    }
}
