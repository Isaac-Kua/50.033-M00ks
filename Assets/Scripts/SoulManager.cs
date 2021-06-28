using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulManager : MonoBehaviour
{
    private int player1TotalSouls = 0;
    private int player1CurrentSouls = 0;
    private int altarSouls = 0;

    public void increaseSouls(int player)
    {
        if (player == 1)
        {
            player1CurrentSouls += 1;
            player1TotalSouls += 1;
            Debug.Log("Gained soul, Souls: "+player1CurrentSouls);
        }
    }

    public void depositSouls(int player)
    {
        if (player == 1)
        {
            altarSouls += player1CurrentSouls;
            Debug.Log("Souls deposited: "+player1CurrentSouls);
            player1CurrentSouls = 0;
        }
    }
}
