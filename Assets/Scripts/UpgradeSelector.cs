using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSelector : MonoBehaviour
{
    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // give upgrade

        this.gameObject.SetActive(false);
        UpgradeSelectionManager.Instance.playerSelected(col.gameObject.GetComponent<PlayerSoulController>().playerNo);
    }
}
