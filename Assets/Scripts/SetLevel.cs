using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLevel : MonoBehaviour
{
    public GameObject altar;
    public GameObject spawners;
    public GameObject upgrades;
    public GameObject obstacles;
    public GameObject hpbar;
    public GameObject upgradeAssigner;
    private GameObject[] enemies;
    private GameObject[] souls;
    private GameObject[] arrow;
    private GameObject[] icebolt;
    private GameObject[] fireball;
    private GameObject[] area;
    private GameObject[] debris;

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
        obstacles.SetActive(true);
        hpbar.SetActive(true);
        GameManager.Instance.upgradeSelection = false;
        GameManager.Instance.secondUpgrade = false;
    }

    public void setUpgradeSelect()
    {
        UpgradeSelectionManager.Instance.reset();
        GameManager.Instance.upgradeNo += 1;
        deactivate();
        upgradeAssigner.GetComponent<UpgradeAssigner>().assignUpgrade();
        upgrades.SetActive(true);
        foreach (Transform child in upgrades.transform){
            child.gameObject.SetActive(true);
        }
        for (int i=0; i<GameManager.Instance.totalPlayers; i++){
            players[i].playerPrefab.transform.position = playerSpawns[i].position;
            if (i != GameManager.Instance.firstPlayer){
                Debug.Log("Deactivate player "+ (i+1));
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
        obstacles.SetActive(false);
        hpbar.SetActive(false);

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies){
            enemy.SetActive(false);
        }
        souls = GameObject.FindGameObjectsWithTag("Soul");
        foreach(GameObject soul in souls){
            soul.SetActive(false);
        }
        arrow = GameObject.FindGameObjectsWithTag("Arrow");
        foreach(GameObject proj in arrow){
            Destroy(proj);
        }
        fireball = GameObject.FindGameObjectsWithTag("Firebolt");
        foreach(GameObject proj in fireball){
            Destroy(proj);
        }
        debris = GameObject.FindGameObjectsWithTag("Debris");
        foreach(GameObject proj in debris){
            Destroy(proj);
        }
        icebolt = GameObject.FindGameObjectsWithTag("Icebolt");
        foreach(GameObject proj in icebolt){
            Destroy(proj);
        }
        area = GameObject.FindGameObjectsWithTag("Area");
        foreach(GameObject proj in area){
            Destroy(proj);
        }
    }
}
