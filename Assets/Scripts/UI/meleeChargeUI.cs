using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meleeChargeUI : MonoBehaviour
{
    private Text text;
    public int playerNo;
    private int charges = 0;
    private List<PlayerConfiguration> players;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        players = PlayerConfigurationManager.Instance.getListOfPlayerConfigs();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNo < GameManager.Instance.totalPlayers) {
            GameObject playerPrefab = players[playerNo].playerPrefab;
            charges = playerPrefab.GetComponent<MeleeHolder>().charges;
        }
        if (charges > 1) {
            text.text = charges.ToString();
        }
        else {
            text.text = null;
        }
    }
}
