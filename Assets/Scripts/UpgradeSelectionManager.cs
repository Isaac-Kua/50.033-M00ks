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
    public delegate void gameEvent();
    public static event gameEvent SelectMetric;

    void Awake()
    {
        Instance = this;
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
            if (AltarManager.Instance.altarDamage > 15){
                AltarManager.Instance.resolve();
                AltarManager.Instance.setHealth(20);
                GameManager.Instance.upgradeNo += 1;
                for (int i=0; i<GameManager.Instance.totalPlayers; i++){
                    players[i].Input.actions.Enable();
                }
                SelectMetric();
                SetLevel.Instance.setLevel();
            }
            // else if (AltarManager.Instance.altarDamage > 6){
            //     AltarManager.Instance.resolve();
            //     AltarManager.Instance.setHealth(20);
            //     GameManager.Instance.upgradeNo += 1;
            //     for (int i=0; i<GameManager.Instance.totalPlayers; i++){
            //         players[i].Input.actions.Enable();
            //     }
            //     SelectMetric();
            //     SetLevel.Instance.setLevel();
            // }
            else if (GameManager.Instance.secondUpgrade == false){
                SetLevel.Instance.setUpgradeSelect();
                GameManager.Instance.secondUpgrade = true;
            }
            else{
                AltarManager.Instance.resolve();
                AltarManager.Instance.setHealth(20);
                for (int i=0; i<GameManager.Instance.totalPlayers; i++){
                    players[i].Input.actions.Enable();
                }
                SelectMetric();
                SetLevel.Instance.setLevel();
            }
        }
        else{
            randPlayer = Random.Range(0,4);
            while (playerSelect[randPlayer] == true){
                randPlayer = Random.Range(0,4);
            }
            for (int i=0; i<GameManager.Instance.totalPlayers; i++){
                // players[i].Input.ActivateInput();
                players[i].Input.actions.Enable();
                if (i != randPlayer){
                    Debug.Log("Deactivate player "+ i+1);
                    // players[i].Input.DeactivateInput();
                    players[i].Input.actions.Disable();
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
