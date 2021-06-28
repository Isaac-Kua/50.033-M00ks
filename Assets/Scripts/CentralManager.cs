using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralManager : MonoBehaviour
{
    public GameObject soulManagerObject;
    private SoulManager soulManager;
    public static CentralManager centralManagerInstance;

    void Awake()
    {
        centralManagerInstance = this;
    }

    void Start()
    {
        soulManager = soulManagerObject.GetComponent<SoulManager>();
    }

    public void increaseSouls(int player)
    {
        soulManager.increaseSouls(player);
    }

    public void depositSouls(int player)
    {
        soulManager.depositSouls(player);
    }

    public void test()
    {
        Debug.Log("test");
    }
}
