using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Ability2Holder : MonoBehaviour
{
    public Ability ability;
    [SerializeField]
	public AudioClip[] audioClips;
    private AudioSource a2Audio;
    //public string abilityType;
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
    private void Start() {
        a2Audio = gameObject.GetComponents<AudioSource>()[3];
    }
    public void changeAbility(Ability newAbility){
        ability = newAbility;
        switch (gameObject.GetComponent<UpgradeManager>().ab2Upgrade)
		{
		case UpgradeManager.ability2Upgrade.Goo:
			a2Audio.clip = audioClips[1];
			break;
		case UpgradeManager.ability2Upgrade.Magnet:
			a2Audio.clip = audioClips[2];
			break;
		case UpgradeManager.ability2Upgrade.Teleport:
			a2Audio.clip = audioClips[3];
			break;
        case UpgradeManager.ability2Upgrade.Mine:
            a2Audio.clip = audioClips[4];
            break;
		default:
			a2Audio.clip = audioClips[0];
			break;
		}
    }
    public void rechargeFully(){
        charges = ability.charges;
        state = AbilityState.ready;
    }

    //public KeyCode key;
    private bool input = false;
    
    public void OnAbility2()
    {
        input = true;
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
                    //Debug.Log("First Use!!!");
                }
                else
                {
                    state = AbilityState.recharging;
                    // Debug.Log(charges);
                    //Debug.Log("Subsequent Use!!!");
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
                    //Debug.Log("recharged!!!");
                }
                if(charges == ability.charges)
                {
                    state = AbilityState.ready;
                    //Debug.Log("fully recharged!!!");
                }
                input = false;
                
            break;
        }
    }
}
