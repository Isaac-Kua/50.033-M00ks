using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoulController : MonoBehaviour
{
    public int playerNo;

    public SoulManager soulManager1;
    public SoulManager soulManager2;
    public SoulManager soulManager3;
    public SoulManager soulManager4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Soul"))
        {
            Player1Manager.centralManagerInstance.increaseSouls(playerNo);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Altar"))
        {
            switch (playerNo) {
            case(0):
                soulManager1.depositSouls();
                break;
            case(1):
                soulManager2.depositSouls();
                break;
            case(2):
                soulManager3.depositSouls();
                break;
            case(3):
                soulManager4.depositSouls();
                break;
            }
        }
    }
}
