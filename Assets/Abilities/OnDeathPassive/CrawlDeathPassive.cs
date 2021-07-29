using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlDeathPassive : MonoBehaviour
{
	private  GameConstants gameConstants;
	private float crawlRatio;
	// Start is called before the first frame update
	void Start()
	{
		gameConstants = GetComponent<UpgradeManager>().gameConstants;
		crawlRatio = gameConstants.crawlRatio;
	}

	// Update is called once per frame
	void Update()
	{
		gameConstants = GetComponent<UpgradeManager>().gameConstants;
		if (GetComponent<UpgradeManager>().crawlDeath){
			if (GetComponent<M00ksDeathHandler>().Dead){
				GetComponent<M00ksDeathHandler>().moveEnabled();
				GetComponent<Rigidbody2D>().drag = 1000*crawlRatio;
				} else {
					GetComponent<Rigidbody2D>().drag = gameConstants.defaultDrag;
				}
		} 
	}
}
