using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyLevel", menuName = "GameConstants/EnemyLevel", order = 1)]
public class CurrentLevel : ScriptableObject
{
	// Enemies
	// FireWizard
	public float fireboltExplosionScale = 3;
	public float fireboltSpeed = 10;
	public int fireWizardTargets = 1;

	// Ranger
	public float rangerMoveSpeed = 12;
	public float rangerWindUpTime = 3;
	public int rangerTargets = 1;

	// Knight
	public float knightMoveSpeed = 5;
	public float knightShieldWidth = 1;

	// IceWizard
	public float iceWizardWindUpTime = 3f;
	public float iceboltSpeed = 10;
	public int wallLength = 2;


	// Barbarian
	public float BarbarianMoveSpeed = 5;
	public float BarbarianMaxRange = 15;
	public int BarbarianMaxCharges = 3;
}
