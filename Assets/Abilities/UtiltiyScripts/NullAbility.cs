using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NullAbility")]
public class NullAbility : Ability
{
    public override void Activate(GameObject parent)
    {
        //parent.GetComponent<Animator>()
        Debug.Log(parent.name + " is useless");
    }
}
