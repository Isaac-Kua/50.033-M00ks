using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UprgradeScreenController : MonoBehaviour
{
    public Button upgradeButton1;
    public Button upgradeButton2;
    public Button upgradeButton3;
    public Button upgradeButton4;

    // Start is called before the first frame update
    void Start()
    {
        AltarManager.NextStage += beforeUpgradeScreen;
    }

    void Update()
    {
        if (!upgradeButton1.interactable && !upgradeButton2.interactable && !upgradeButton3.interactable && !upgradeButton4.interactable)
        {
            Debug.Log("Moving to next stage");
            Next();
        }
    }

    void beforeUpgradeScreen()
    {
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "before Upgrade Selection")
            {
                eachChild.gameObject.SetActive(true);
            }                
        }
    }

    void UpgradeScreen()
    {
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "Upgrade Selection")
            {
                eachChild.gameObject.SetActive(true);
            }                
        }
    }

    public void Upgrade1()
    {
        Debug.Log("Upgrade 1 selected");
        upgradeButton1.interactable = false;
    }

    public void Upgrade2()
    {
        Debug.Log("Upgrade 2 selected");
        upgradeButton2.interactable = false;
    }

    public void Upgrade3()
    {
        Debug.Log("Upgrade 3 selected");
        upgradeButton3.interactable = false;
    }

    public void Upgrade4()
    {
        Debug.Log("Upgrade 4 selected");
        upgradeButton4.interactable = false;
    }

    public void PlayerNo()
    {
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "before Upgrade Selection")
            {
                eachChild.gameObject.SetActive(false);
            }                
        }
        UpgradeScreen();
    }

    void Next()
    {
        upgradeButton1.interactable = true;
        upgradeButton2.interactable = true;
        upgradeButton3.interactable = true;
        upgradeButton4.interactable = true;
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "Upgrade Selection")
            {
                eachChild.gameObject.SetActive(false);
            }                
        }
        afterUpgrade();
    }

    void afterUpgrade()
    {
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "after Upgrade Selection")
            {
                eachChild.gameObject.SetActive(true);
            }                
        }
    }

    public void SelectCondition()
    {
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "after Upgrade Selection")
            {
                eachChild.gameObject.SetActive(false);
            }                
        }
    }
}
