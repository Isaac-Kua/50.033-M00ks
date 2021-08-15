using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class winScene : MonoBehaviour
{
    public GameObject levelInitializer;
    public Text kills;
    private List<PlayerConfiguration> players;
    public GameObject timer;
    public GameObject background;
    public Sprite winBg;

    void Awake()
    {
        players = PlayerConfigurationManager.Instance.getListOfPlayerConfigs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getWinner()
    {
        players = PlayerConfigurationManager.Instance.getListOfPlayerConfigs();
        List<int> playerKills = new List<int>();
        for (int i=0; i<GameManager.Instance.totalPlayers; i++){
            playerKills.Add(players[i].playerPrefab.GetComponent<M00ksDeathHandler>().playerkills);
        }
        Debug.Log(playerKills);
        
        int winningPlayer = playerKills.IndexOf(playerKills.Max());
        kills.text = "Player " + (winningPlayer+1) + " won!\n" + "PvP Kills: "+ playerKills.Max().ToString();
        levelInitializer.GetComponent<AudioSource>().Stop();
        levelInitializer.GetComponent<AudioSource>().clip = levelInitializer.GetComponent<Initializer>().getAudioClip(3);
        levelInitializer.GetComponent<AudioSource>().Play();
        timer.SetActive(false);
        background.GetComponent<SpriteRenderer>().sprite = winBg;
        background.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2.5f, 2.5f);
    }
}
