using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstoppableDefensePassive : MonoBehaviour
{
	private  GameConstants gameConstants;
	private float slowRatio;
	// Start is called before the first frame update
	void Start()
	{
		gameConstants = GetComponent<UpgradeManager>().gameConstants;
		slowRatio = gameConstants.slowRatio;
	}

	// Update is called once per frame
	void Update()
	{
		gameConstants = GetComponent<UpgradeManager>().gameConstants;
		if (GetComponent<UpgradeManager>().unstoppableDefense){
			if (GetComponent<M00ksDeathHandler>().Brittle){
				GetComponent<M00ksDeathHandler>().allEnable();
				GetComponent<Rigidbody2D>().drag = 1000*slowRatio;
				} else {
					GetComponent<Rigidbody2D>().drag = gameConstants.defaultDrag;
				}
		} 
	}
}
