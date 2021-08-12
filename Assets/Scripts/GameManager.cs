using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int stage = 1;
    public string currentMetric = "None";
    public int firstPlayer = 0;
    public int totalPlayers;
    public bool upgradeSelection = false;
    public int upgradeNo = 1;
    public bool secondUpgrade = false;
    public bool cutscene = false;

    public static GameManager Instance;
    public delegate void gameEvent();
    public static event gameEvent PVPStage;

    public CurrentLevel currentLevel;
    public List<CurrentLevel> LevelSettings;

    void Awake()
    {
        Instance = this;
        currentLevel = LevelSettings[stage-1];
    }

    public void increaseStage(){
        stage += 1;
        if (stage < 5) {
            currentLevel = LevelSettings[stage];
        } else if (stage == 7) {
            PVPStage();
        } 
    }
}
