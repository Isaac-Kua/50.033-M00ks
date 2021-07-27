using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeDeathPassive : MonoBehaviour
{
	public  GameConstants gameConstants;
	private GameObject kamikazePrefab;
	
	// Start is called before the first frame update
	void Start()
	{
		kamikazePrefab = gameConstants.kamikazePrefab;
	}

	// Update is called once per frame
	void Update()
	{
		if (GetComponent<UpgradeManager>().kamikazeDeath){
			if (GetComponent<M00ksDeathHandler>().myLives == 0 && !GetComponent<M00ksDeathHandler>().Dead){
				GameObject Boom = Instantiate(kamikazePrefab, transform.position, transform.rotation);
				Boom.GetComponent<ProjectileController>().owner = gameObject;
			}
		} 
	}
}
