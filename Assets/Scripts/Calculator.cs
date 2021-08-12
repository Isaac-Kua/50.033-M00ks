using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Calculator : MonoBehaviour
{
    private List<PlayerConfiguration> players;
    public static Calculator Instance;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        players = PlayerConfigurationManager.Instance.getListOfPlayerConfigs();
    }

    public int leastDeaths()
    {
        List<int> playerDeaths =  new List<int>();
        for (int i=0; i<GameManager.Instance.totalPlayers; i++){
            playerDeaths.Add(players[i].playerPrefab.GetComponent<M00ksDeathHandler>().deaths);
        }
        return playerDeaths.IndexOf(playerDeaths.Min());
    }

    public int mostKills()
    {
        List<int> playerKills =  new List<int>();
        for (int i=0; i<GameManager.Instance.totalPlayers; i++){
            playerKills.Add(players[i].playerPrefab.GetComponent<M00ksDeathHandler>().enemykills);
        }
        return playerKills.IndexOf(playerKills.Max());
    }
}
