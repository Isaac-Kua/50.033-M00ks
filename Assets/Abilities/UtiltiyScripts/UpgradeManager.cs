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
	
	//Ability 1 Upgrades
	public bool Kaiten = false;
	public bool Knockback = false;
	public bool SpikeRange = false;






	public enum meleeUpgrade
	{
		Melee
	}

	public ability1Upgrade ab1Upgrade = ability1Upgrade.Attack;
	public ability2Upgrade ab2Upgrade = ability2Upgrade.Attack;
	public dashUpgrade dUpgrade = dashUpgrade.Dash;
	public meleeUpgrade mUpgrade = meleeUpgrade.Melee;

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
		SpikeRange
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
		Mine
	}
	//Dash ScriptableObjects
	public Ability d_Phase;
	public Ability d_Reverse;
	public Ability d_Triple;
	public Ability d_Spider;
	public Ability d_Default;
	public enum dashUpgrade
	{
		Dash,
		Phase,
		Reverse,
		Triple,
		Spider
	}
	//Melee ScriptableObjects
	public Ability m_Breaking;
	public Ability m_Repel;
	public Ability m_Lunge;
	public Ability m_Zangief;


	//The Various Ability Holders
	private Ability1Holder ability1Holder;
	private DashHolder dashHolder;
	private Ability2Holder ability2Holder;
	private MeleeHolder meleeHolder;


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
				changeAbility1(ab1_Attack);
				break;
		}
		
		switch (ab2Upgrade)
		{
			case ability2Upgrade.Attack:
				//changeAbility2(Attack)
				break;
			default:
				changeAbility2(ab2_Attack);
				break;
		}

		switch (dUpgrade)
		{
			case dashUpgrade.Dash:
				//changeDash(Melee)
				break;
			default:
				break;
		}

		switch (mUpgrade)
		{
			case meleeUpgrade.Melee:
				//changeMelee(Melee)
				break;
			default:
				break;
		}

	}
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
