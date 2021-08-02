using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private AltarManager altarManager;

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
    }

    public void increaseSouls(int player)
    {
        switch (player) {
            case(0):
                soulManager1.increaseSouls();
                break;
            case(1):
                soulManager2.increaseSouls();
                break;
            case(2):
                soulManager3.increaseSouls();
                break;
            case(3):
                soulManager4.increaseSouls();
                break;
        }
    }

    public void depositSouls(int player)
    {
        switch (player) {
            case(0):
                altarManager.altarDeposit(soulManager1.depositSouls());
                break;
            case(1):
                altarManager.altarDeposit(soulManager2.depositSouls());
                break;
            case(2):
                altarManager.altarDeposit(soulManager3.depositSouls());
                break;
            case(3):
                altarManager.altarDeposit(soulManager4.depositSouls());
                break;
        }
    }

    public void damageAltar()
    {
        altarManager.damageAltar();
    }

    public int getAltarHealth()
    {
        return altarManager.getHealth();
    }

    public void setAltarHealth(int health)
    {
        altarManager.setHealth(health);
    }
}
