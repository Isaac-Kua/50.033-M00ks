using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarManager : MonoBehaviour
{
    public int altarSouls = 0;
    public int soulCap = 10;
    public int altarHealth = 50;
    public int altarDamage = 0;

    public GameObject soulManagerObject1;
    private SoulManager soulManager1;
    public GameObject soulManagerObject2;
    private SoulManager soulManager2;
    public GameObject soulManagerObject3;
    private SoulManager soulManager3;
    public GameObject soulManagerObject4;
    private SoulManager soulManager4;

    public delegate void gameEvent();
    public static event gameEvent Lose;
    public static event gameEvent NextStage1;
    public static event gameEvent NextStage2;
    public static AltarManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        soulManager1 = soulManagerObject1.GetComponent<SoulManager>();
        soulManager2 = soulManagerObject2.GetComponent<SoulManager>();
        soulManager3 = soulManagerObject3.GetComponent<SoulManager>();
        soulManager4 = soulManagerObject4.GetComponent<SoulManager>();
    }

    public void altarDeposit()
    {
        altarSouls = soulManager1.depositedSouls+soulManager2.depositedSouls+soulManager3.depositedSouls+soulManager4.depositedSouls;
        Debug.Log(altarSouls);
        if (altarSouls >= soulCap)
        {
            altarSouls = 0;
            soulManager1.depositedSouls = 0;
            soulManager2.depositedSouls = 0;
            soulManager3.depositedSouls = 0;
            soulManager4.depositedSouls = 0;
            Debug.Log("Goal reached");
            NextStage1();
            NextStage2();
            GameManager.Instance.increaseStage();  
        }
    }

    // public void altarDeposit(int souls)
    // {
    //     altarSouls += souls;
    //     Debug.Log("Deposited souls: "+souls);
    //     Debug.Log("Altar souls: "+altarSouls);
    // }

    public void damageAltar()
    {
        altarDamage += 1;
        Debug.Log("Altar health: "+(altarHealth-altarDamage));
        if (altarHealth <= altarDamage)
        {
            Lose();
        }
    }

    public int getDamage()
    {
        return altarDamage;
    }

    public int getAltarHealth()
    {
        return altarHealth - altarDamage;
    }

    public void setHealth(int health)
    {
        altarHealth = health;
    }

    public void resolve()
    {
        altarHealth -= altarDamage;
        altarDamage = 0;
    }
}
