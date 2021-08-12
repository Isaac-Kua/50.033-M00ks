using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HowToPlayButton()
    {
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "HowToPlayScreen")
            {
                eachChild.gameObject.SetActive(true);
            }
        }
    }
}
