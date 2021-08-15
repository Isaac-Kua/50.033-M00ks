using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player1Manager : MonoBehaviour
{
    public static Player1Manager centralManagerInstance;
    public GameObject soulManagerObject1;
    private SoulManager soulManager1;
    public GameObject soulManagerObject2;
    private SoulManager soulManager2;
    public GameObject soulManagerObject3;
    private SoulManager soulManager3;
    public GameObject soulManagerObject4;
    private SoulManager soulManager4;
    public GameObject altarManagerObject;
    public GameObject introCutscene;
    public GameObject upgradeCutscene;
    private AltarManager altarManager;
    private List<int> playerSouls = new List<int>{0,0,0,0};
    private List<PlayerConfiguration> players;

    void Awake()
    {
        centralManagerInstance = this;
    }

    void Start()
    {
        soulManager1 = soulManagerObject1.GetComponent<SoulManager>();
        soulManager2 = soulManagerObject2.GetComponent<SoulManager>();
        soulManager3 = soulManagerObject3.GetComponent<SoulManager>();
        soulManager4 = soulManagerObject4.GetComponent<SoulManager>();
        altarManager = altarManagerObject.GetComponent<AltarManager>();

        players = PlayerConfigurationManager.Instance.getListOfPlayerConfigs();
        for (int i=0; i<GameManager.Instance.totalPlayers; i++){
            players[i].playerPrefab.GetComponent<PlayerSoulController>().soulManager1 = soulManager1;
            players[i].playerPrefab.GetComponent<PlayerSoulController>().soulManager2 = soulManager2;
            players[i].playerPrefab.GetComponent<PlayerSoulController>().soulManager3 = soulManager3;
            players[i].playerPrefab.GetComponent<PlayerSoulController>().soulManager4 = soulManager4;
        }
    }

    public void increaseSouls(int player)
    {
        switch (player) {
            case(0):
                soulManager1.increaseSouls();
                playerSouls[0]++;
                break;
            case(1):
                soulManager2.increaseSouls();
                playerSouls[1]++;
                break;
            case(2):
                soulManager3.increaseSouls();
                playerSouls[2]++;
                break;
            case(3):
                soulManager4.increaseSouls();
                playerSouls[3]++;
                break;
        }
    }

    // public void depositSouls(int player)
    // {
    //     switch (player) {
    //         case(0):
    //             altarManager.altarDeposit(soulManager1.depositSouls());
    //             break;
    //         case(1):
    //             altarManager.altarDeposit(soulManager2.depositSouls());
    //             break;
    //         case(2):
    //             altarManager.altarDeposit(soulManager3.depositSouls());
    //             break;
    //         case(3):
    //             altarManager.altarDeposit(soulManager4.depositSouls());
    //             break;
    //     }
    // }

    public void damageAltar()
    {
        altarManager.damageAltar();
    }

    public int mostSoulsPlayer()
    {
        return playerSouls.IndexOf(playerSouls.Max());
    }

    public void stopCutscene()
    {
        if (introCutscene.GetComponent<introScene>().playing == true) {
            introCutscene.GetComponent<introScene>().stop = true;
        }
        if (upgradeCutscene.GetComponent<upgradeScene>().playing == true) {
            upgradeCutscene.GetComponent<upgradeScene>().stop = true;
        }
    }
}
