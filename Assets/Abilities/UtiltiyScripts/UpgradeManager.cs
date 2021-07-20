using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
	public GameConstants gameConstants;
	public GameObject shivaAura;
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

	// Movement Upgrades
	public bool juggernautMove = false;
	public bool wallwalkerMove = false;
	public bool shivaMove = false;
	public bool chameleonMove = false;

	// Start is called before the first frame update
	void Start()
    {
		shivaAura.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
		if (juggernautMove)
		{
			Debug.Log("IM THE JUGGERNAUT");
		} else if (wallwalkerMove) {
			if (transform.position.x > gameConstants.xBound) {
				transform.position = transform.position - new Vector3(2 * gameConstants.xBound, 0, 0);
			} else if (transform.position.x < -gameConstants.xBound) {
				transform.position = transform.position + new Vector3(2 * gameConstants.xBound, 0, 0);
			} else if (transform.position.y > gameConstants.yBound) {
				transform.position = transform.position - new Vector3(0, 2 * gameConstants.yBound, 0);
			} else if (transform.position.y < -gameConstants.yBound) {
				transform.position = transform.position + new Vector3(0, 2 * gameConstants.yBound, 0);
			}
		} else if (shivaMove) {
			shivaAura.SetActive(true);
		}
    }

	public void onKill(GameObject victim) {
		Debug.Log("I killed " + victim.name);
		if (explosionKill) {
			GameObject Boom = Instantiate(gameConstants.explosionPrefab, victim.transform.position, victim.transform.rotation);
			Boom.GetComponent<ProjectileController>().owner = gameObject;
		} else if (zombieKill) {
			GameObject Spider = Instantiate(gameConstants.zombiePrefab, victim.transform.position, victim.transform.rotation);
			Spider.GetComponent<ProjectileController>().owner = gameObject;
		} else if (hasteKill) {
			StartCoroutine(Haste());
		} else if (saiyanKill) {
			Debug.Log("ALL RECHARGE");
		}
	}

	IEnumerator Haste() {
		GetComponent<M00ks1Controller>().speed *= gameConstants.hasteRatio;
			yield return new WaitForSeconds(gameConstants.hasteDuration);
		GetComponent<M00ks1Controller>().speed /= gameConstants.hasteRatio;
	}
}
