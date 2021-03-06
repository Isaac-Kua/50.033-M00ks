using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulManager : MonoBehaviour
{
    private int totalSouls = 0;
    private int currentSouls = 0;
    public int depositedSouls = 0;

    public void increaseSouls()
    {
        currentSouls += 1;
        totalSouls += 1;
        Debug.Log("Player Souls: "+currentSouls);
    }

    public void depositSouls()
    {
        depositedSouls += currentSouls;
        Debug.Log("Souls deposited: "+currentSouls);
        currentSouls = 0;
    }
}
