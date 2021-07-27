using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnUtilityPassive : MonoBehaviour
{

	private GameConstants gameConstants;
    // Start is called before the first frame update
    void Start()
    {
        gameConstants = GetComponent<UpgradeManager>().gameConstants;
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
