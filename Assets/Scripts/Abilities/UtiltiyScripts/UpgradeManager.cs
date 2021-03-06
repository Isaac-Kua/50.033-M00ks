using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UpgradeManager : MonoBehaviour
{
	public GameConstants gameConstants;
	public GameObject player;
	private AudioSource comboAudio;
	[SerializeField]
	private AudioClip[] audioClips;

	// Defensive upgrades
	public bool miniDefense = false;
	public bool shellDefense = false;
	public bool unstoppableDefense = false;
	public bool toughDefense = false;

	// Death Upgrades
	public bool crawlDeath = false;
	public bool kamikazeDeath = false;
	public bool soulswapDeath = true;
	public bool vengeanceDeath = false;

	// Kill Upgrades
	public bool explosionKill = false;
	public bool zombieKill = false;
	public bool hasteKill = false;
	public bool saiyanKill = false;

	// Move Upgrades
	public bool juggernautMove = false;
	public bool wallwalkerMove = false;
	public bool shivaMove = false;
	public bool ghostMove = false;
	
	// Utility Upgrades
	public bool respawnUtil = false;
	public bool meleeUtil = false;
	public bool rangedUtil = false;
	public bool altUtil = false;

	// Alt 1 Modifier
	public bool rangedBullet = false;
	public bool phaseBullet = false;
	public bool heavyBullet = false;
	public bool homingBullet = false;
	public bool RangeMod = false;
    public bool BypassMod = false;
    public bool SpeedMod = false;
    public bool HeavyMod = false;

	// Ability 1 Ranged
	private bool arrowRange = false;
	private bool knockbackRange = false;
	private bool kaitenRange = false;
	private bool spikeRange = false;

	// Ability 2 Alternate
	private bool mineAlt = false;
	private bool teleportAlt = false;
	private bool gooAlt = false;
	private bool magnetAlt = false;

	// Melee Abilities
	private bool breakingMelee = false;
	private bool repelMelee = false;
	private bool lungeMelee = false;
	private bool zangiefMelee = false;

	// Dash Abilities
	private bool phaseDash = false;
	private bool reverseDash = false;
	private bool tripleDash = false;
	private bool spiderDash = false;

	// ComboLists
	private bool[] JuggernautList;
	private bool[] WidowmakerList;
	private bool[] TophList;
	private bool[] AchmedList;
	private bool[] PacquiaoList;
	private bool[] DannyList;
	private bool[] TurleList;
	private bool[] MagnusList;

	// Combo Passives
	public bool JuggernautCombo = false;
	public bool WidowmakerCombo = false;
	public bool TophCombo = false;
	public bool AchmedCombo = false;
	public bool PacquiaoCombo = false;
	public bool DannyCombo = false;
	public bool TurtleCombo = false;
	public bool MagnusCombo = false;
	private GameObject Aura;
	private Animator AuraAnimator;


	//Ability1 ScriptableObjects
	public Ability ab1_Kaiten;
	public Ability ab1_Knockback;
	public Ability ab1_SpikeRange;
	public Ability ab1_Arrow;
	public Ability ab1_Default;

	public enum ability1Upgrade
	{
		Kaiten,
		Knockback,
		SpikeRange,
		Arrow,
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
	private Animator m00ksAnimator;

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

	public Dictionary<string, bool> GetUpgrades()
	{
		Dictionary<string, bool> upgrades = new Dictionary<string, bool>();
		// Defensive upgrades
		upgrades.Add("miniDef", miniDefense);
		upgrades.Add("shellDef", shellDefense);
		upgrades.Add("unstoppableDef", unstoppableDefense);
		upgrades.Add("toughDef", toughDefense);
		// Death Upgrades
		upgrades.Add("crawlDeath", crawlDeath);
		upgrades.Add("kamikazeDeath", kamikazeDeath);
		upgrades.Add("soulswapDeath", soulswapDeath);
		upgrades.Add("vengeanceDeath", vengeanceDeath);
		// Kill Upgrades
		upgrades.Add("explosionKill", explosionKill);
		upgrades.Add("zombieKill", zombieKill);
		upgrades.Add("hasteKill", hasteKill);
		upgrades.Add("saiyanKill", saiyanKill);
		// Move Upgrades
		upgrades.Add("juggernautMove", juggernautMove);
		upgrades.Add("wallwalkerMove", wallwalkerMove);
		upgrades.Add("shivaMove", shivaMove);
		upgrades.Add("ghostMove", ghostMove);
		// Utility Upgrades
		upgrades.Add("respawnUtil", respawnUtil);
		upgrades.Add("meleeUtil", meleeUtil);
		upgrades.Add("rangedUtil", rangedUtil);
		upgrades.Add("altUtil", altUtil);
		// Alt 1 Modifier
		upgrades.Add("rangedBullet", rangedBullet);
		upgrades.Add("phaseBullet", phaseBullet);
		upgrades.Add("heavyBullet", heavyBullet);
		upgrades.Add("homingBullet", homingBullet);
		return upgrades;
	}

	// Start is called before the first frame update
	void Start()
	{
		ability1Holder = player.GetComponent<Ability1Holder>();
		dashHolder = player.GetComponent<DashHolder>();
		meleeHolder = player.GetComponent<MeleeHolder>();
		ability2Holder = player.GetComponent<Ability2Holder>();
		m00ksAnimator = GetComponent<Animator>();
		Aura = Instantiate(gameConstants.AuraDisplay, transform.position, transform.rotation);
		Aura.transform.parent = transform;
		AuraAnimator = Aura.GetComponent<Animator>();
		comboAudio = player.GetComponents<AudioSource>()[4];
	}

	// Update is called once per frame
	void Update()
	{
		// AURA DISPLAY
		float OffsetY = 0;
		Aura.GetComponent<SpriteRenderer>().flipX = GetComponent<SpriteRenderer>().flipX;
		if (miniDefense)
		{
			 OffsetY = gameConstants.AuraOffsetY / gameConstants.shrinkRatio;
		}
		else {
			 OffsetY = gameConstants.AuraOffsetY;
		}
		if (GetComponent<SpriteRenderer>().flipX)
		{
			Aura.transform.position = transform.position + new Vector3(-gameConstants.AuraOffsetX, OffsetY, 0);
		}
		else
		{
			Aura.transform.position = transform.position + new Vector3(gameConstants.AuraOffsetX, OffsetY, 0);
		}


		updateAbilities();
		calculateCombo();
		if (wallwalkerMove)
		{
			if (transform.position.x > gameConstants.xBound)
			{
				transform.position = transform.position - new Vector3(2 * gameConstants.xBound, 0, 0);
			}
			else if (transform.position.x < -gameConstants.xBound)
			{
				transform.position = transform.position + new Vector3(2 * gameConstants.xBound, 0, 0);
			}
			else if (transform.position.y > gameConstants.yBound)
			{
				transform.position = transform.position - new Vector3(0, 2 * gameConstants.yBound+6, 0);
			}
			else if (transform.position.y < -gameConstants.yBound-6)
			{
				transform.position = transform.position + new Vector3(0, 2 * gameConstants.yBound+6, 0);
			}
		}
	}

	public void onKill(GameObject victim)
	{
		Debug.Log("I killed " + victim.name);
		if (explosionKill)
		{
			GameObject Boom = Instantiate(gameConstants.explosionPrefab, victim.transform.position, victim.transform.rotation);
			Boom.GetComponent<ProjectileController>().owner = gameObject;
		}
		else if (zombieKill)
		{
			GameObject Spider = Instantiate(gameConstants.zombiePrefab, victim.transform.position, victim.transform.rotation);
			Spider.GetComponent<ProjectileController>().owner = gameObject;
		}
		else if (hasteKill)
		{
			StartCoroutine(Haste());
		}
		else if (saiyanKill)
		{
			Debug.Log("ALL RECHARGE");
		}
	}

	IEnumerator Haste()
	{
		GetComponent<M00ks1Controller>().speed *= gameConstants.hasteRatio;
		yield return new WaitForSeconds(gameConstants.hasteDuration);
		GetComponent<M00ks1Controller>().speed /= gameConstants.hasteRatio;
	}

	public void updateAbilities()
	{
		// Ability 1 Ranged
		arrowRange = false;
		knockbackRange = false;
		kaitenRange = false;
		spikeRange = false;

		// Ability 2 Alternate
		mineAlt = false;
		teleportAlt = false;
		gooAlt = false;
		magnetAlt = false;

		// Melee Abilities
		breakingMelee = false;
		repelMelee = false;
		lungeMelee = false;
		zangiefMelee = false;

		// Dash Abilities
		phaseDash = false;
		reverseDash = false;
		tripleDash = false;
		spiderDash = false;
		
		switch (ab1Upgrade)
		{
		case ability1Upgrade.Kaiten:
			changeAbility1(ab1_Kaiten);
			kaitenRange = true;
			break;
		case ability1Upgrade.Knockback:
			changeAbility1(ab1_Knockback);
			knockbackRange = true;
			break;
		case ability1Upgrade.SpikeRange:
			changeAbility1(ab1_SpikeRange);
			spikeRange = true;
			break;
		case ability1Upgrade.Arrow:
			changeAbility1(ab1_Arrow);
			arrowRange = true;
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
			gooAlt = true;
			break;
		case ability2Upgrade.Magnet:
			changeAbility2(ab2_Magnet);
			magnetAlt = true;
			break;
		case ability2Upgrade.Teleport:
			changeAbility2(ab2_Teleport);
			teleportAlt = true;
			break;
		case ability2Upgrade.Mine:
			changeAbility2(ab2_Mine);
			mineAlt = true;
			break;
		default:
			changeAbility2(ab2_Default);
			break;
		}

		switch (dUpgrade)
		{
		case dashUpgrade.Phase:
			changeDash(d_Phase);
			phaseDash = true;
			break;
		case dashUpgrade.Reverse:
			changeDash(d_Reverse);
			reverseDash = true;
			break;
		case dashUpgrade.Triple:
			changeDash(d_Triple);
			tripleDash = true;
			break;
		case dashUpgrade.Spider:
			changeDash(d_Spider);
			spiderDash = true;
			break;
		default:
			changeDash(d_Default);
			break;
		}

		switch (mUpgrade)
		{
		case meleeUpgrade.Breaking:
			changeMelee(m_Breaking);		
			breakingMelee = true;
			break;
		case meleeUpgrade.Repel:
			changeMelee(m_Repel);		
			repelMelee = true;
			break;
		case meleeUpgrade.Lunge:
			changeMelee(m_Lunge);	
			lungeMelee = true;
			break;
		case meleeUpgrade.Zangief:
			changeMelee(m_Zangief);	
			zangiefMelee = true;
			break;
		default:
			changeMelee(m_Default);	
			break;
		}

		m00ksAnimator.SetBool("ZangiefMelee", zangiefMelee);
		m00ksAnimator.SetBool("DeathCrawlPassive", crawlDeath);
		m00ksAnimator.SetBool("TeleportAlt2", teleportAlt);
		m00ksAnimator.SetBool("RewindDash", reverseDash);
	}

	void calculateCombo(){
		JuggernautList = new bool[] { unstoppableDefense, knockbackRange, heavyBullet, breakingMelee, juggernautMove };
        WidowmakerList = new bool[] { arrowRange, rangedBullet, rangedUtil, spiderDash, saiyanKill };
        TophList = new bool[] { miniDefense, spikeRange, homingBullet, tripleDash, repelMelee };
        AchmedList = new bool[] { kaitenRange, magnetAlt, kamikazeDeath, explosionKill, zangiefMelee };
        PacquiaoList = new bool[] { toughDefense, meleeUtil, vengeanceDeath, hasteKill, lungeMelee };
        DannyList = new bool[] { phaseBullet, teleportAlt, respawnUtil, phaseDash, ghostMove };
        TurleList = new bool[] { shellDefense, gooAlt, altUtil, crawlDeath, shivaMove };
        MagnusList = new bool[] { mineAlt, reverseDash, soulswapDeath, zombieKill, wallwalkerMove };


        if (JuggernautList.Count(upgrade => upgrade == true) > gameConstants.comboCount)
        {
            if (!JuggernautCombo)
            {
                JuggernautCombo = true;
                Debug.Log("I'm the Juggernaut Bitch");
				comboAudio.clip = audioClips[0];
				comboAudio.Play();
            }
        }
        else
        {
            JuggernautCombo = false;
        }

        if (WidowmakerList.Count(upgrade => upgrade == true) > gameConstants.comboCount)
        {
            if (!WidowmakerCombo)
            {
                WidowmakerCombo = true;
                Debug.Log("Widowmaker pew pew pew");
				comboAudio.clip = audioClips[1];
				comboAudio.Play();
            }
        }
        else
        {
            WidowmakerCombo = false;
        }

        if (TophList.Count(upgrade => upgrade == true) > gameConstants.comboCount)
        {
            if (!TophCombo)
            {
                TophCombo = true;
                Debug.Log("I am the greatest earthbender in the world, don't you two dunder heads ever forget it");
				comboAudio.clip = audioClips[2];
				comboAudio.Play();
            }
        }
        else
        {
            TophCombo = false;
        }

        if (AchmedList.Count(upgrade => upgrade == true) > gameConstants.comboCount)
        {
            if (!AchmedCombo)
            {
                AchmedCombo = true;
                Debug.Log("Admiral Ackbar!");
				comboAudio.clip = audioClips[3];
				comboAudio.Play();
            }
        }
        else
        {
            AchmedCombo = false;
        }

        if (PacquiaoList.Count(upgrade => upgrade == true) > gameConstants.comboCount)
        {
            if (!PacquiaoCombo)
            {
                PacquiaoCombo = true;
                Debug.Log("Manny Pacquiao");
				comboAudio.clip = audioClips[4];
				comboAudio.Play();
            }
        }
        else
        {
            PacquiaoCombo = false;
        }

        if (DannyList.Count(upgrade => upgrade == true) > gameConstants.comboCount)
        {
            if (!DannyCombo)
            {
                DannyCombo = true;
                Debug.Log("He's a phantom");
				comboAudio.clip = audioClips[5];
				comboAudio.Play();
            }
        }
        else
        {
            DannyCombo = false;
        }

        if (TurleList.Count(upgrade => upgrade == true) > gameConstants.comboCount)
        {
            if (!TurtleCombo)
            {
                TurtleCombo = true;
                Debug.Log("Teenage Mutant Ninja Turtles!");
				comboAudio.clip = audioClips[6];
				comboAudio.Play();
            }
        }
        else
        {
            TurtleCombo = false;
        }

        if (MagnusList.Count(upgrade => upgrade == true) > gameConstants.comboCount)
        {
            if (!MagnusCombo)
            {
                MagnusCombo = true;
                Debug.Log("Magnus Carlsen");
				comboAudio.clip = audioClips[7];
				comboAudio.Play();
            }
        }
        else
        {
            MagnusCombo = false;
        }

        AuraAnimator.SetBool("Magnus", MagnusCombo);
		AuraAnimator.SetBool("Achmed", AchmedCombo);
		AuraAnimator.SetBool("Juggernaut", JuggernautCombo);
		AuraAnimator.SetBool("Toph", TophCombo);
		AuraAnimator.SetBool("Pacquiao", PacquiaoCombo);
		AuraAnimator.SetBool("Danny", DannyCombo);
		AuraAnimator.SetBool("Turtle", TurtleCombo);
		AuraAnimator.SetBool("Widowmaker", WidowmakerCombo);
	}
}

