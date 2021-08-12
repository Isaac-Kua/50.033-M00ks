using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyLevel1", menuName = "GameConstants/EnemyLevel1", order = 1)]
public class EnemyLevel1 : ScriptableObject
{
	// Enemies
	// FireWizard
	public float fireboltExplosionScale = 3;
	public float fireboltSpeed = 10;
	public float fireWizardMoveSpeed = 5;
	public float fireWizardMaxRange = 20;
	public float fireWizardMinRange = 5;
	public float fireWizardPoofChargeTime = 5;
	public float fireWizardPoofCastTime = 0.5f;
	public float fireWizardWindUpTime = 3;
	public float fireWizardSwingTime = 0.2f;

	// Ranger
	public float rangerMoveSpeed = 12;
	public float rangerMaxRange = 20;
	public float rangerMinRange = 10;
	public float rangerArrowSpeed = 100;
	public float rangerFireTime = 0.5f;
	public float rangerWindUpTime = 3;

	// Knight
	public float knightMoveSpeed = 5;
	public float knightShieldWidth = 1;
	public float knightWindUpTime = 3;
	public float knightSwordlength = 1;
	public float knightSwordLifeTime = 1;
	public float knightSwordRotationPerSec = 1;

	// IceWizard
	public float iceWizardMoveSpeed = 10;
	public float iceWizardMaxRange = 30;
	public float iceWizardMinRange = 10;
	public float iceWizardBurstChargeTime = 10f;
	public float iceWizardWindUpTime = 3f;
	public float iceWizardSwingTime = 0.2f;

	public float iceboltLifeTime = 3f;
	public float iceboltSpeed = 10;

	public float icewaveLifeTime = 1f;
	public float icewaveMeltTime = 2f;
	public float icewaveSpeed = 3000;
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
