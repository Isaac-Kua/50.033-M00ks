using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    public string abilityType;
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

    public void changeAbility(Ability newAbility){
        ability = newAbility;
    }
    public void rechargeFully(){
        charges = ability.charges;
        state = AbilityState.ready;
    }
    //public KeyCode key;
    private bool input = false;
    public void OnDash()
    {
        if(abilityType=="Dash")
        {
            input = true;
        }
        Debug.Log("dashing in ability holder");
    }
    public void OnAbility1()
    {
        
        if(abilityType=="Ability1")
        {
            input = true;
        }
        Debug.Log("ability1 in abiliy holder");
    }
    public void OnAbility2()
    {
        if(abilityType=="Ability2")
        {
            input = true;
        }
        Debug.Log("ability2 in abiliy holder");
    }
	public void OnMelee()
    {
        if(abilityType=="Melee")
        {
            input = true;
        }
        Debug.Log("melee in abiliy holder");
    }
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
                if(input)//Input.GetKeyDown(key))
                {
                    
                    ability.Activate(gameObject);
                    charges--;
                    state = AbilityState.active;
                    activeTime = ability.activeTime;
                }
                input = false;
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
                    // Debug.Log(charges);
                    Debug.Log("Subsequent Use!!!");
                    // Debug.Log(rechargeTime);
                }
                input = false;

            break;
            case AbilityState.recharging:
                // Debug.Log("Recharging");
                if(input && charges>0)
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
                    //Debug.Log(charges);
                    Debug.Log("recharged!!!");
                }
                if(charges == ability.charges)
                {
                    state = AbilityState.ready;
                    Debug.Log("fully recharged!!!");
                }
                input = false;
                
            break;
        }
    }
}
