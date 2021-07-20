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
	
	// Defensive Passive Variables 
	// Tough
	public int defaultLives = 1;
	public int thugLives = 2;
	// Mini
	public float defaultSize = 2;
	public float shrinkRatio = 2;
	// Shell
	public float shellDistance = 5;
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
	
	
}