using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meleeCDController : MonoBehaviour
{
    private Image cdFill;
    public int playerNo;
    private List<PlayerConfiguration> players;

    // Start is called before the first frame update
    void Start()
    {
        cdFill = GetComponent<Image>();
        players = PlayerConfigurationManager.Instance.getListOfPlayerConfigs();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNo < GameManager.Instance.totalPlayers) {
            GameObject playerPrefab = players[playerNo].playerPrefab;
            float cooldown = playerPrefab.GetComponent<MeleeHolder>().cooldownTime;
            float current = playerPrefab.GetComponent<MeleeHolder>().rechargeTime;
            if (cooldown == 0){
                setCDvalue(0);
            }
            else{
                setCDvalue(current/cooldown);
            }
        }
        else {
            setCDvalue(0);
        }
    }

    void setCDvalue(float value)
    {
        if (value == 1) {value = 0;}
        cdFill.fillAmount = value;
    }
}
