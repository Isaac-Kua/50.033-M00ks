using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager centralManagerInstance;

    // Start is called before the first frame update
    void Awake()
    {
        centralManagerInstance = this;
    }

    public void setLevel()
    {
        
    }
}
