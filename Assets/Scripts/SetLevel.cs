using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLevel : MonoBehaviour
{
    public GameObject altar;
    public GameObject spawners;
    public GameObject walls;
    public GameObject upgrades;
    private GameObject[] enemies;

    private List<PlayerConfiguration> players;
    [SerializeField]
    private Transform[] playerSpawns;

    public static SetLevel Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        setLevel();
        AltarManager.NextStage += setUpgradeSelect;
        players = PlayerConfigurationManager.Instance.getListOfPlayerConfigs();
    }

    public void setLevel()
    {
        deactivate();
        altar.SetActive(true);
        spawners.SetActive(true);
        walls.SetActive(true);
    }

    public void setUpgradeSelect()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies){
            enemy.SetActive(false);
        }
        deactivate();
        upgrades.SetActive(true);
        for (int i=0; i<GameManager.Instance.totalPlayers; i++){
            players[i].playerPrefab.transform.position = playerSpawns[i].position;
            if (i != GameManager.Instance.firstPlayer){
                Debug.Log("Deactivate player "+ i+1);
                players[i].Input.DeactivateInput();
            }
        }
    }

    void deactivate()
    {
        altar.SetActive(false);
        spawners.SetActive(false);
        walls.SetActive(false);
        upgrades.SetActive(false);
    }
}
