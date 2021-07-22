using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =  "TeleportAlternateAbility", menuName =  "Ability 2/Teleport")]
public class TeleportAlternateAbility : Ability
{
	// should make this a gameconstant
    public float yBound = 18;
	public float xBound = 30;
	
    public override void Activate(GameObject parent)
    {
        parent.GetComponent<M00ksDeathHandler>().Immunity = true;
        parent.transform.position = new Vector2(Random.Range(-xBound, xBound),Random.Range(-yBound, yBound));
        parent.GetComponent<M00ksDeathHandler>().Immunity = false;
    }
}
