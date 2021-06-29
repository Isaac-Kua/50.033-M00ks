using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarManager : MonoBehaviour
{
    private int altarSouls = 0;
    public int soulCap = 5;

    public void altarDeposit(int souls)
    {
        altarSouls += souls;
        Debug.Log("Deposited souls: "+souls);
        Debug.Log("Altar souls: "+altarSouls);
        if (altarSouls >= soulCap)
        {
            NextStage();
        }
    }

    void NextStage()
    {
        Debug.Log("Wave Ended");
    }
}
