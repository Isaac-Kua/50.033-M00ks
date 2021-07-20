using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToughDefensePassive : MonoBehaviour
{
	public GameConstants gameConstants;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<UpgradeManager>().toughDefense){
			GetComponent<M00ksDeathHandler>().lives = gameConstants.thugLives;
		} else {
			GetComponent<M00ksDeathHandler>().lives = gameConstants.defaultLives;
		}
    }
}
