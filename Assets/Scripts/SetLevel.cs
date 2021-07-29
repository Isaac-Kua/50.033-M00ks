using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLevel : MonoBehaviour
{
    public GameObject altar;
    public GameObject spawners;
    public GameObject upgrades;
    private GameObject[] enemies;
    private GameObject[] souls;
    private GameObject[] projectiles;

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
        GameManager.Instance.upgradeSelection = false;
    }

    public void setUpgradeSelect()
    {
        GameManager.Instance.upgradeNo += 1;
        deactivate();
        upgrades.SetActive(true);
        foreach (Transform child in upgrades.transform){
            child.gameObject.SetActive(true);
        }
        for (int i=0; i<GameManager.Instance.totalPlayers; i++){
            players[i].playerPrefab.transform.position = playerSpawns[i].position;
            if (i != GameManager.Instance.firstPlayer){
                Debug.Log("Deactivate player "+ i+1);
                players[i].Input.DeactivateInput();
            }
        }
        GameManager.Instance.upgradeSelection = true;
    }

    void deactivate()
    {
        altar.SetActive(false);
        spawners.SetActive(false);
        upgrades.SetActive(false);

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies){
            enemy.SetActive(false);
        }
        souls = GameObject.FindGameObjectsWithTag("Soul");
        foreach(GameObject soul in souls){
            soul.SetActive(false);
        }
        // projectiles = GameObject.FindGameObjectsWithTag("Enemy Projectile");
        // foreach(GameObject proj in projectiles){
        //     Destroy(proj);
        // }
    }
}
