using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToughDefensePassive : MonoBehaviour
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
        gameConstants = GetComponent<UpgradeManager>().gameConstants;
        if (GetComponent<UpgradeManager>().toughDefense){
			GetComponent<M00ksDeathHandler>().lives = gameConstants.thugLives;
		} else {
			GetComponent<M00ksDeathHandler>().lives = gameConstants.defaultLives;
		}
    }
}
