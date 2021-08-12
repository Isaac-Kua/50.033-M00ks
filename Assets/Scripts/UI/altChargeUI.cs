using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class altChargeUI : MonoBehaviour
{
    private Text text;
    public int playerNo;
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
        GameObject playerPrefab = players[playerNo].playerPrefab;
        int charges = playerPrefab.GetComponent<Ability2Holder>().charges;
        if (charges >= 1) {
            text.text = charges.ToString();
        }
        else {
            text.text = null;
        }
    }
}
