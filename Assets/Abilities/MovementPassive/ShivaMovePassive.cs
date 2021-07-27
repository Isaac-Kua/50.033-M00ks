using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShivaMovePassive : MonoBehaviour
{
    private GameConstants gameConstants;
    private GameObject shiva;
    // Start is called before the first frame update
    void Start()
    {
        gameConstants = GetComponent<UpgradeManager>().gameConstants;
        shiva = Instantiate(gameConstants.shivaAura, transform.position, transform.rotation);
        shiva.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        gameConstants = GetComponent<UpgradeManager>().gameConstants;
        shiva.transform.position = transform.position;
        if (GetComponent<UpgradeManager>().shivaMove)
        {
            shiva.SetActive(true);  
        }
        else
        {
            shiva.SetActive(false);
        }
    }
}
