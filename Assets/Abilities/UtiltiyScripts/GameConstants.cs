using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =  "GameConstants", menuName =  "ScriptableObjects/GameConstants", order =  1)]
public class GameConstants : ScriptableObject
{
		
	// Generic
	public float deathTime = 3;
	public float stunTime = 3;
	public float gooPoolLifeTime = 3;
	public GameObject gooPool;
	public float stickiness = 0.5f;
	public float defaultDrag = 10;
	public float yBound = 18;
	public float xBound = 30;
	
	// M00ks
	public float M00ksMoveSpeed = 20;
	
	// Defensive Passive Variables 
	// Tough
	public int defaultLives = 1;
	public int thugLives = 2;
	// Mini
	public float defaultSize = 2;
	public float shrinkRatio = 2;
	// Shell
	public float shellDistance = 5;
	public GameObject shell;
	// Unstoppable
	public float slowRatio = 0.3f;
	
	// Death Passive Variables
	// Crawl 
	public float crawlRatio = 0.4f;
	// Kamikaze
	public GameObject kamikazePrefab;
	public float kamikazeMaxRadius = 8;
	public float kamikazeGrowthRate = 1.2f;
	public float kamikazeCastTime = 0.5f;
	
	// Ability1 (Ranged) Variables
	// Knockback
	public float launchDuration = 1;
	public float knockbackSpeed = 150;
	// Kaiten
	public float kaitenGrowthRate = 1.1f;
	public float kaitenCastTime = 0.5f;
	public float kaitenMaxRadius = 8;
	public GameObject kaitenPrefab;
	
	// Ability2 (Alternate) Variables 
	// Reverse
	public float reverseDuration = 1;
	
	// Melee Ability Variables;
	// Zangief
	public float rotationPerSec = 5;

	// Kill Passive Variables
	// Explosion
	public GameObject explosionPrefab;
	public float katsuMaxRadius = 5;
	public float katsuGrowthRate = 1.5f;
	public float katsuCastTime = 0.5f;
	// Zombie
	public GameObject zombiePrefab;
	public float SpiderMoveSpeed = 30;
	public float SpiderLifeTime = 5f;
	// Haste
	public float hasteRatio = 3;
	public float hasteDuration = 2;

	//Movement Passive Variables
	// Shiva
	public GameObject shivaAura;
	public float shivaRatio = 0.2f;
	public float shivaRadius = 15;
	// Ghost
	public float ghostFadeDuration = 5;
	public float ghostFlickerDuration = 1;
	public float ghostApparitionDuration = 0.05f;
	// Juggernaut
	public float juggernautRatio = 2;
	public float juggernautSize = 4;
	public GameObject juggernautBubble;
	public float juggernautRampDuration = 5;

	// Enemies
	// FireWizard
	public float fireboltExplosionScale = 3;
	public float fireboltSpeed = 10;
	public GameObject fireboltTargetArea;
	public GameObject fireWizardFirebolt;
	public float fireWizardMoveSpeed = 5;
	public float fireWizardMaxRange = 20;
	public float fireWizardMinRange = 5;
	public float fireWizardPoofChargeTime = 5;
	public float fireWizardWindUpTime = 3;

	// Ranger
	public GameObject rangerArrow;
	public float rangerMoveSpeed = 12;
	public float rangerMaxRange = 20;	
	public float rangerMinRange = 10;
	public float rangerArrowSpeed = 100;
	public float rangerWindUpTime = 3;
	
	// Knight
	public float knightMoveSpeed = 5;
	public GameObject knightShield;
	public GameObject knightSword;
	public float knightShieldWidth = 1;
	public float knightWindUpTime = 3;
	public float knightSwordlength = 1;
	public float knightSwordLifeTime = 1;
	public float knightSwordRotationPerSec = 1;
	
	// IceWizard
	public float iceWizardMoveSpeed = 10;
	public float iceWizardMaxRange = 30;
	public float iceWizardMinRange = 10 ;
	public float iceWizardBurstChargeTime = 10f;
	public float iceWizardWindUpTime = 3f;
	public GameObject iceWizardIcebolt;
	public GameObject iceWizardIcewave;
	
	public float iceboltLifeTime = 3f;
	public float iceboltMeltTime = 2f;
	public float iceboltSpeed = 10;
	
	public float icewaveLifeTime = 1f;
	public float icewaveMeltTime = 2f;
	public float icewaveSpeed = 500;
	public GameObject debris;
	public int wallLength = 2;

	// Barbarian
	public float BarbarianMoveSpeed = 5;
	public float BarbarianMaxRange = 15;
	public float BarbarianDashSpeed = 150;
	public float BarbarianChargeDuration = 0.05f;
	public float BarbarianPauseDuration = 0.1f;
	public float BarbarianWindUpTime = 3f;
	public int BarbarianMaxCharges = 3;

}
