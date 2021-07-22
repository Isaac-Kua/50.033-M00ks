using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnUtilityPassive : MonoBehaviour
{

	public GameConstants gameConstants;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<UpgradeManager>().respawnUtil){
			GetComponent<M00ksDeathHandler>().deathTime = gameConstants.reducedDeathTime;
		} else {
			GetComponent<M00ksDeathHandler>().deathTime = gameConstants.deathTime;
		}
    }
}
