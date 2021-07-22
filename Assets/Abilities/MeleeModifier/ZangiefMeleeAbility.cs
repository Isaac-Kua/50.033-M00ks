using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =  "ZangiefMeleeAbility", menuName =  "Melee/Zangief")]
public class ZangiefMeleeAbility : Ability
{
    public GameObject missile;
    private Vector2 missile1Position;
    private Vector2 missile2Position;
    private Vector2 missileDirection;
    public override void Activate(GameObject parent)
    {
        missileDirection = parent.GetComponent<M00ks1Controller>().faceDirection;
        missile1Position = new Vector2(parent.transform.position.x, parent.transform.position.y) + missileDirection*2;
        missile2Position = new Vector2(parent.transform.position.x, parent.transform.position.y) - missileDirection*2;
        GameObject missile1 = Instantiate(missile, missile1Position, parent.transform.rotation);
		GameObject missile2 = Instantiate(missile, missile2Position, parent.transform.rotation);
		
		missile1.GetComponent<ZangiefFistController>().player = parent;
		missile2.GetComponent<ZangiefFistController>().player = parent;
		missile1.GetComponent<ZangiefFistController>().rotationPerSec = gameConstants.rotationPerSec;
		missile2.GetComponent<ZangiefFistController>().rotationPerSec = gameConstants.rotationPerSec;
		
		missile1.GetComponent<ZangiefFistController>().lifeTime = activeTime;
		missile2.GetComponent<ZangiefFistController>().lifeTime = activeTime;
		
		missile1.GetComponent<ProjectileController>().owner = parent;
		missile2.GetComponent<ProjectileController>().owner = parent;
		
    }
}
