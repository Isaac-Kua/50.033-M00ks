using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int stage = 1;
    public string currentCondition;
    public int firstPlayer;
    public int chosenPlayer;
    public int totalPlayers;

    public static GameManager Instance;
    public delegate void gameEvent();
    public static event gameEvent BossStage;

    void Awake()
    {
        Instance = this;
    }

    public void increaseStage(){
        stage += 1;
        if (stage == 6) {
            BossStage();
        }
    }
}
