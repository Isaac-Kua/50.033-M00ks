using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    float cooldownTime;
    float activeTime;
    float rechargeTime;
    int charges = -999;
    enum AbilityState{
        ready,
        active,
        recharging
    }

    AbilityState state = AbilityState.ready;

    public KeyCode key;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(state);
        //Debug.Log(charges);
        switch (state)
        {
            case AbilityState.ready:
                //Debug.Log("Ready");
                if(charges == -999){charges = ability.charges;}
                if(Input.GetKeyDown(key))
                {
                    ability.Activate(gameObject);
                    charges--;
                    state = AbilityState.active;
                    activeTime = ability.activeTime;
                }
            break;
            case AbilityState.active:
                //Debug.Log("active");
                if (activeTime>0)
                {
                    activeTime -= Time.deltaTime;
                }
                else if (charges == ability.charges-1)
                {
                    state = AbilityState.recharging;
                    rechargeTime = ability.rechargeTime;
                    Debug.Log("First Use!!!");
                }
                else
                {
                    state = AbilityState.recharging;
                    Debug.Log(charges);
                    Debug.Log("Subsequent Use!!!");
                    Debug.Log(rechargeTime);
                }

            break;
            case AbilityState.recharging:
                //Debug.Log("Recharging");
                if(Input.GetKeyDown(key) && charges>0)
                {
                    ability.Activate(gameObject);
                    state = AbilityState.active;
                    activeTime = ability.activeTime;
                    charges--;
                }
                else if(rechargeTime>0)
                {
                    rechargeTime -= Time.deltaTime;
                }
                else if(charges < ability.charges)
                {
                    charges++;
                    rechargeTime = ability.rechargeTime;
                    Debug.Log(charges);
                    Debug.Log("recharged!!!");
                }
                if(charges == ability.charges)
                {
                    state = AbilityState.ready;
                    Debug.Log("fully recharged!!!");
                }
                
            break;
        }
    }
}
