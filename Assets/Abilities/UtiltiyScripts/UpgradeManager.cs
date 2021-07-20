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

	public GameObject player;
	//Ability1 ScriptableObjects
	public Ability ab1_Kaiten;
	public Ability ab1_Knockback;
	public Ability ab1_SpikeRange;
	public Ability ab1_Default;
	public enum ability1Upgrade
	{
		Kaiten,
		Knockback,
		SpikeRange,
		Default
	}
	//Ability2 ScriptableObjects
	public Ability ab2_Goo;
	public Ability ab2_Magnet;
	public Ability ab2_Mine;
	public Ability ab2_Teleport;
	public Ability ab2_Default;
	public enum ability2Upgrade
	{
		Goo,
		Magnet,
		Teleport,
		Mine,
		Default
	}
	//Dash ScriptableObjects
	public Ability d_Phase;
	public Ability d_Reverse;
	public Ability d_Triple;
	public Ability d_Spider;
	public Ability d_Default;
	public enum dashUpgrade
	{
		Phase,
		Reverse,
		Triple,
		Spider,
		Default
	}
	//Melee ScriptableObjects
	public Ability m_Breaking;
	public Ability m_Repel;
	public Ability m_Lunge;
	public Ability m_Zangief;
	public Ability m_Default;
	public enum meleeUpgrade
	{
		Breaking,
		Repel,
		Lunge,
		Zangief,
		Default
	}
	//The Various Ability Holders
	private Ability1Holder ability1Holder;
	private DashHolder dashHolder;
	private Ability2Holder ability2Holder;
	private MeleeHolder meleeHolder;
	//The Various Ability States
	public ability1Upgrade ab1Upgrade = ability1Upgrade.Default;
	public ability2Upgrade ab2Upgrade = ability2Upgrade.Default;
	public dashUpgrade dUpgrade = dashUpgrade.Default;
	public meleeUpgrade mUpgrade = meleeUpgrade.Default;

	public void changeAbility1(Ability a1)
	{
		ability1Holder.changeAbility(a1);
	}

	public void changeAbility2(Ability a2)
	{
		ability2Holder.changeAbility(a2);
	}
	public void changeDash(Ability newDash)
	{
		dashHolder.changeAbility(newDash);
	}
	public void changeMelee(Ability newMelee)
	{
		meleeHolder.changeAbility(newMelee);
	}

	public void updateAbilities()
	{
		switch (ab1Upgrade)
		{
			case ability1Upgrade.Kaiten:
				changeAbility1(ab1_Kaiten);
				break;			
			case ability1Upgrade.Knockback:
				changeAbility1(ab1_Knockback);
				break;
			case ability1Upgrade.SpikeRange:
				changeAbility1(ab1_SpikeRange);
				break;
			default:
				changeAbility1(ab1_Default);
				break;
		}
		
		switch (ab2Upgrade)
		{
			case ability2Upgrade.Goo:
				changeAbility2(ab2_Goo);
				//changeAbility2(Attack)
				break;
			case ability2Upgrade.Magnet:
				changeAbility2(ab2_Magnet);
				break;
			case ability2Upgrade.Teleport:
				changeAbility2(ab2_Teleport);
				break;
			case ability2Upgrade.Mine:
				changeAbility2(ab2_Mine);
				break;
			default:
				changeAbility2(ab2_Default);
				break;
		}

		switch (dUpgrade)
		{
			case dashUpgrade.Phase:
				changeDash(d_Phase);
				break;
			case dashUpgrade.Reverse:
				changeDash(d_Reverse);
				break;
			case dashUpgrade.Triple:
				changeDash(d_Triple);
				break;
			case dashUpgrade.Spider:
				changeDash(d_Spider);
				break;
			default:
				changeDash(d_Default);
				break;
		}

		switch (mUpgrade)
		{
			case meleeUpgrade.Breaking:
				changeMelee(m_Breaking);
				break;
			case meleeUpgrade.Repel:
				changeMelee(m_Repel);
				break;
			case meleeUpgrade.Lunge:
				changeMelee(m_Lunge);
				break;
			case meleeUpgrade.Zangief:
				changeMelee(m_Zangief);
				break;
			default:
				changeMelee(m_Default);
				break;
		}

	}

	// Kill Upgrades
	public bool explosionKill = false;
	public bool zombieKill = false;
	public bool hasteKill = false;
	public bool saiyanKill = false;

	// Start is called before the first frame update
	void Start()
    {
        ability1Holder = player.GetComponent<Ability1Holder>();
		dashHolder = player.GetComponent<DashHolder>();
		meleeHolder = player.GetComponent<MeleeHolder>();
		ability2Holder = player.GetComponent<Ability2Holder>();
    }

    // Update is called once per frame
    void Update()
    {
		updateAbilities();
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
