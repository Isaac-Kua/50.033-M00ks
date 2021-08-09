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
    public GameObject upgradeUI;
    public GameObject speechBubble;
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
        AltarManager.NextStage1 += chooseFirstPlayer;
        AltarManager.NextStage1 += setUpgradeSelect;
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
        Debug.Log("Choose upgrades");
        UpgradeSelectionManager.Instance.reset();
        GameManager.Instance.upgradeNo += 1;
        deactivate();
        upgradeAssigner.GetComponent<UpgradeAssigner>().assignUpgrade();
        upgrades.SetActive(true);
        upgradeUI.SetActive(true);
        foreach (Transform child in upgrades.transform){
            child.gameObject.SetActive(true);
        }
        if (AltarManager.Instance.altarDamage > 40){
            speechBubble.GetComponent<UpgradeSpeech>().oneStar();
        }
        else if (AltarManager.Instance.altarDamage > 15){
            speechBubble.GetComponent<UpgradeSpeech>().twoStar();
        }
        else{
            speechBubble.GetComponent<UpgradeSpeech>().threeStar();
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
        upgradeUI.SetActive(false);

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

    void chooseFirstPlayer()
    {
        if (GameManager.Instance.currentMetric == "Random"){
            int randPlayer = Random.Range(0,4);
            while (randPlayer >= GameManager.Instance.totalPlayers){
                randPlayer = Random.Range(0,4);
            }
            GameManager.Instance.firstPlayer = randPlayer;
        }
        if (GameManager.Instance.currentMetric == "Most Souls Collected"){
            GameManager.Instance.firstPlayer = Player1Manager.centralManagerInstance.mostSoulsPlayer();
        }
        if (GameManager.Instance.currentMetric == "Least Deaths"){
            GameManager.Instance.firstPlayer = Calculator.Instance.leastDeaths();
        }
        if (GameManager.Instance.currentMetric == "Most Kills"){
            GameManager.Instance.firstPlayer = 0;
        }
    }
}
