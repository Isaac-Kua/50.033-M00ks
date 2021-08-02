using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoulController : MonoBehaviour
{
    public int playerNo;

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
            Player1Manager.centralManagerInstance.depositSouls(playerNo);
        }
    }
}
