using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName =  "ReverseDashAbility", menuName =  "Dash/Reverse")]
public class ReverseDashAbility : Ability
{
    public override void Activate(GameObject parent)
    {
        parent.GetComponent<M00ksDeathHandler>().Immunity = true;
        Debug.Log("Dash: Reverse");
        StartCoroutine(DashCoroutine(parent));
    }
	
    private IEnumerator DashCoroutine(GameObject parent)
    {
        Debug.Log("dashing");
		parent.transform.position = parent.GetComponent<M00ks1Controller>().previousLocation;  
        parent.GetComponent<M00ksDeathHandler>().Immunity = false;
		yield return null;
    }
}
