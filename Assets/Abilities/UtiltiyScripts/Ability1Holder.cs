using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ability1Holder : MonoBehaviour
{
    public Ability ability;

    [SerializeField]
	public AudioClip[] audioClips;
    private AudioSource a1Audio;
    //public string abilityType;
    float cooldownTime;
    float activeTime;
    float rechargeTime;
    int charges = -999;

    public bool RangeMod;
    public bool BypassMod;
    public bool SpeedMod;
    public bool HeavyMod;

    private void Start() {
        a1Audio = gameObject.GetComponents<AudioSource>()[2];
    }
    bool checkModifications()
    {
        RangeMod = gameObject.GetComponent<UpgradeManager>().RangeMod;
        BypassMod = gameObject.GetComponent<UpgradeManager>().BypassMod;
        SpeedMod = gameObject.GetComponent<UpgradeManager>().SpeedMod;
        HeavyMod = gameObject.GetComponent<UpgradeManager>().HeavyMod;
        return true;
    }
    
    enum AbilityState{
        ready,
        active,
        recharging
    }

    AbilityState state = AbilityState.ready;

    public void changeAbility(Ability newAbility){
        ability = newAbility;
        switch (gameObject.GetComponent<UpgradeManager>().ab1Upgrade)
		{
		case UpgradeManager.ability1Upgrade.Kaiten:
			a1Audio.clip = audioClips[1];
			break;
		case UpgradeManager.ability1Upgrade.Knockback:
			a1Audio.clip = audioClips[2];
			break;
		case UpgradeManager.ability1Upgrade.SpikeRange:
			a1Audio.clip = audioClips[3];
			break;
        case UpgradeManager.ability1Upgrade.Arrow:
			a1Audio.clip = audioClips[4];
			break;
		default:
			a1Audio.clip = audioClips[0];
			break;
		}
    }
    public void rechargeFully(){
        charges = ability.charges;
        state = AbilityState.ready;
    }

    //public KeyCode key;
    private bool input = false;

    public void OnAbility1()
    {
        input = true;
        Debug.Log("ability1 in ability holder");
    }
    
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(state);
        //Debug.Log(charges);
        checkModifications();
        //Debug.Log("this is the range mod");
        //Debug.Log(RangeMod);
        switch (state)
        {
            case AbilityState.ready:
                //Debug.Log("Ready");
                if(charges == -999){charges = ability.charges;}
                if(input)//Input.GetKeyDown(key))
                {
                    
                    ability.Activate(gameObject);
                    a1Audio.Play();
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
                    a1Audio.Play();
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
