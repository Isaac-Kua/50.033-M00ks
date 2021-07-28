using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarManager : MonoBehaviour
{
    private int altarSouls = 0;
    public int soulCap = 1;
    public int altarHealth = 50;

    public delegate void gameEvent();
    public static event gameEvent Lose;
    public static event gameEvent NextStage;

    public void altarDeposit(int souls)
    {
        altarSouls += souls;
        Debug.Log("Deposited souls: "+souls);
        Debug.Log("Altar souls: "+altarSouls);
        if (altarSouls >= soulCap)
        {
            Debug.Log("Goal reached");
            NextStage();
            GameManager.Instance.increaseStage();
            altarSouls = 0;
        }
    }

    public void damageAltar()
    {
        altarHealth -= 1;
        Debug.Log("Altar Damaged");
        Debug.Log("Altar health: "+altarHealth);
        if (altarHealth <= 0)
        {
            Lose();
        }
    }
}
