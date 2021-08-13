using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DashHolder : MonoBehaviour
{
    public Ability ability;
    [SerializeField]
	public AudioClip[] audioClips;
    private AudioSource dAudio;
    //public string abilityType;
    public float cooldownTime;
    float activeTime;
    public float rechargeTime;
    public int charges = -999;
    enum AbilityState{
        ready,
        active,
        recharging
    }

    AbilityState state = AbilityState.ready;
    private void Start() {
        dAudio = gameObject.GetComponents<AudioSource>()[1];
        cooldownTime = ability.rechargeTime;
    }
    public void changeAbility(Ability newAbility){
        ability = newAbility;
        cooldownTime = ability.rechargeTime;
        switch (gameObject.GetComponent<UpgradeManager>().dUpgrade)
		{
		case UpgradeManager.dashUpgrade.Default:
            dAudio.clip = audioClips[0];
            break;
        case UpgradeManager.dashUpgrade.Phase:
			dAudio.clip = audioClips[1];
			break;
		case UpgradeManager.dashUpgrade.Reverse:
			dAudio.clip = audioClips[2];
			break;
		case UpgradeManager.dashUpgrade.Triple:
			dAudio.clip = audioClips[3];
			break;
        case UpgradeManager.dashUpgrade.Spider:
            dAudio.clip = audioClips[4];
            break;
		default:
			dAudio.clip = audioClips[0];
			break;
		}
    }
    public void rechargeFully(){
        charges = ability.charges;
        state = AbilityState.ready;
    }
    //public KeyCode key;
    private bool input = false;
    public void OnDash()
    {
        input = true;
        Debug.Log("dashing in ability holder");
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
                    dAudio.Play();
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
                    dAudio.Play();
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
