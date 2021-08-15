using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject bg;
    public Sprite bg2;
    public Sprite bg3;
    public Sprite bg4;
    public Sprite bg5;

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
        switch (stage){
            case(2):
                bg.GetComponent<SpriteRenderer>().sprite = bg2;
                // bg.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                break;
            case(3):
                bg.GetComponent<SpriteRenderer>().sprite = bg3;
                bg.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(7, 7);
                break;
            case(4):
                bg.GetComponent<SpriteRenderer>().sprite = bg4;
                break;
            case(5):
                bg.GetComponent<SpriteRenderer>().sprite = bg5;
                break;
        }
    }
}
