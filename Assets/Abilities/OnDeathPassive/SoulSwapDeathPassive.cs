using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSwapDeathPassive : MonoBehaviour
{
	public  GameConstants gameConstants;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
