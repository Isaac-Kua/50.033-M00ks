using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShivaMovePassive : MonoBehaviour
{
    public GameConstants gameConstants;
    private GameObject shiva;
    private Vector2 shellPosition;
    private Vector2 shellDirection;
    private Quaternion angle = new Quaternion(0, 0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        shiva = Instantiate(gameConstants.shivaAura, transform.position, transform.rotation);
        shiva.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
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
