using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
	public GameConstants gameConstants;
	// Defensive upgrades
	public bool miniDefense = false;
	public bool shellDefense = false;
	public bool unstoppableDefense = false;
	public bool	toughDefense = false;
	
	// Death Upgrades
	public bool crawlDeath = false;
	public bool kamikazeDeath = false;
	public bool soulswapDeath = false;
	public bool vengeanceDeath = false;

	// Kill Upgrades
	public bool explosionKill = false;
	public bool zombieKill = false;
	public bool hasteKill = false;
	public bool saiyanKill = false;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void onKill(GameObject victim) {
		Debug.Log("I killed " + victim.name);
		if (explosionKill) {
			Instantiate(gameConstants.explosionPrefab, victim.transform.position, victim.transform.rotation);
		} else if (zombieKill) {
			GameObject Spider = Instantiate(gameConstants.zombiePrefab, victim.transform.position, victim.transform.rotation);
			Spider.GetComponent<ProjectileController>().owner = gameObject;
		} else if (hasteKill) {
			Debug.Log("GOTTA GO FAST");
		} else if (saiyanKill) {
			Debug.Log("ALL RECHARGE");
		}
	}
}
