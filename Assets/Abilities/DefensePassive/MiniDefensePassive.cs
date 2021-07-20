using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniDefensePassive: MonoBehaviour
{
	public  GameConstants gameConstants;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		if (GetComponent<UpgradeManager>().miniDefense){
			transform.localScale = new Vector2(gameConstants.defaultSize/gameConstants.shrinkRatio,gameConstants.defaultSize/gameConstants.shrinkRatio);
		} else {
			transform.localScale = new Vector2(gameConstants.defaultSize,gameConstants.defaultSize);
		}	
    }
}
