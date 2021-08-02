using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSelectionManager : MonoBehaviour
{
    private bool[] playerSelect = new bool[4];
    private bool allSelected = true;
    private int randPlayer;

    private List<PlayerConfiguration> players;
    public static UpgradeSelectionManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
    }

    public void playerSelected(int player)
    {
        playerSelect[player] = true;
        foreach(bool p in playerSelect){
            if(!p){
                allSelected = false;
            }
        }
        if (allSelected){
            if (Player1Manager.centralManagerInstance.getAltarHealth() <= 10){
                for (int i=0; i<GameManager.Instance.totalPlayers; i++){
                    players[i].Input.ActivateInput();
                }
                SetLevel.Instance.setLevel();
            }
            else if (Player1Manager.centralManagerInstance.getAltarHealth() <= 35){
                Player1Manager.centralManagerInstance.setAltarHealth(50);
                for (int i=0; i<GameManager.Instance.totalPlayers; i++){
                    players[i].Input.ActivateInput();
                }
                SetLevel.Instance.setLevel();
            }
            else if (GameManager.Instance.secondUpgrade == false){
                SetLevel.Instance.setUpgradeSelect();
                GameManager.Instance.secondUpgrade = true;
            }
            else{
                for (int i=0; i<GameManager.Instance.totalPlayers; i++){
                    players[i].Input.ActivateInput();
                }
                SetLevel.Instance.setLevel();
            }
        }
        else{
            randPlayer = Random.Range(0,4);
            while (playerSelect[randPlayer] == true){
                randPlayer = Random.Range(0,4);
            }
            for (int i=0; i<GameManager.Instance.totalPlayers; i++){
                players[i].Input.ActivateInput();
                if (i != randPlayer){
                    Debug.Log("Deactivate player "+ i+1);
                    players[i].Input.DeactivateInput();
                }
            }
        }
        allSelected = true;
    }

    public void reset()
    {
        for (int i=0; i<4; i++){
            playerSelect[i] = true;
        }
        players = PlayerConfigurationManager.Instance.getListOfPlayerConfigs();
        for (int i=0; i<GameManager.Instance.totalPlayers; i++){
            playerSelect[i] = false;
        }
    }
}
