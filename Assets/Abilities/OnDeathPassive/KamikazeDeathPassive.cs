using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeDeathPassive : MonoBehaviour
{
	private  GameConstants gameConstants;
	private GameObject kamikazePrefab;
	
	// Start is called before the first frame update
	void Start()
	{
		gameConstants = GetComponent<UpgradeManager>().gameConstants;
		kamikazePrefab = gameConstants.kamikazePrefab;
	}

	// Update is called once per frame
	void Update()
	{
		gameConstants = GetComponent<UpgradeManager>().gameConstants;
		if (GetComponent<UpgradeManager>().kamikazeDeath){
			if (GetComponent<M00ksDeathHandler>().myLives <1 && !GetComponent<M00ksDeathHandler>().Dead){
				GameObject Boom = Instantiate(kamikazePrefab, transform.position, transform.rotation);
				Boom.GetComponent<ProjectileController>().owner = gameObject;
			}
		} 
	}
}
