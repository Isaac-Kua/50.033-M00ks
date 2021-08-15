using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarManager : MonoBehaviour
{
    public int altarSouls = 0;
    public int soulCap = 10;
    public int altarHealth = 50;
    public int altarDamage = 0;

    public delegate void gameEvent();
    public static event gameEvent Lose;
    public static event gameEvent NextStage1;
    public static event gameEvent NextStage2;
    public static AltarManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (altarSouls >= soulCap)
        {
            altarSouls = 0;
            Debug.Log("Goal reached");
            NextStage1();
            NextStage2();
            GameManager.Instance.increaseStage();  
        }
    }

    public void altarDeposit(int souls)
    {
        altarSouls += souls;
        Debug.Log("Deposited souls: "+souls);
        Debug.Log("Altar souls: "+altarSouls);
    }

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
