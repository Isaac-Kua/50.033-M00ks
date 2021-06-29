using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Manager : MonoBehaviour
{
    public static Player1Manager centralManagerInstance;
    public GameObject soulManagerObject;
    private SoulManager soulManager;
    public GameObject altarManagerObject;
    private AltarManager altarManager;

    void Awake()
    {
        centralManagerInstance = this;
    }

    void Start()
    {
        soulManager = soulManagerObject.GetComponent<SoulManager>();
        altarManager = altarManagerObject.GetComponent<AltarManager>();
    }

    public void increaseSouls()
    {
        soulManager.increaseSouls();
    }

    public void depositSouls()
    {
        int souls = soulManager.depositSouls();
        altarManager.altarDeposit(souls);
    }

    public void damageAltar()
    {
        altarManager.damageAltar();
    }
}
