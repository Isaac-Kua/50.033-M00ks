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
            if (playerNo == 0) {
                Player1Manager.centralManagerInstance.increaseSouls();
            }
            else if (playerNo == 1) {
                Player2Manager.centralManagerInstance.increaseSouls();
            }
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Altar"))
        {
            if (playerNo == 0) {
                Player1Manager.centralManagerInstance.depositSouls();
            }
            else if (playerNo == 1) {
                Player2Manager.centralManagerInstance.depositSouls();
            }
        }
    }
}
