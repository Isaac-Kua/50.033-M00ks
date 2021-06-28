using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoulController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Soul"))
        {
            CentralManager.centralManagerInstance.increaseSouls(1);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Altar"))
        {
            CentralManager.centralManagerInstance.depositSouls(1);
        }
    }
}
