using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UprgradeScreenController : MonoBehaviour
{
    public Button p1;
    public Button upgradeButton1;
    public Button upgradeButton2;
    public Button upgradeButton3;
    public Button upgradeButton4;
    public Button condition1;
    private EventSystem eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        AltarManager.NextStage += beforeUpgradeScreen;
        eventSystem = EventSystem.current;
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
        GameManager.centralManagerInstance.increaseStage();
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "before Upgrade Selection")
            {
                eachChild.gameObject.SetActive(true);
            }                
        }
        Time.timeScale = 0f;
        eventSystem.SetSelectedGameObject(p1.gameObject, new BaseEventData(eventSystem));
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
        eventSystem.SetSelectedGameObject(upgradeButton1.gameObject, new BaseEventData(eventSystem));
    }

    public void Upgrade1()
    {
        Debug.Log("Upgrade 1 selected");
        upgradeButton1.interactable = false;
        eventSystem.SetSelectedGameObject(upgradeButton1.gameObject, new BaseEventData(eventSystem));
    }

    public void Upgrade2()
    {
        Debug.Log("Upgrade 2 selected");
        upgradeButton2.interactable = false;
        eventSystem.SetSelectedGameObject(p1.gameObject, new BaseEventData(eventSystem));
    }

    public void Upgrade3()
    {
        Debug.Log("Upgrade 3 selected");
        upgradeButton3.interactable = false;
        eventSystem.SetSelectedGameObject(p1.gameObject, new BaseEventData(eventSystem));
    }

    public void Upgrade4()
    {
        Debug.Log("Upgrade 4 selected");
        upgradeButton4.interactable = false;
        eventSystem.SetSelectedGameObject(p1.gameObject, new BaseEventData(eventSystem));
    }

    public void PlayerNo(int player)
    {
        GameManager.centralManagerInstance.chosenPlayer = player;
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
        eventSystem.SetSelectedGameObject(condition1.gameObject, new BaseEventData(eventSystem));
    }

    public void SelectCondition(Button button)
    {
        GameManager.centralManagerInstance.currentCondition = button.name;
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "after Upgrade Selection")
            {
                eachChild.gameObject.SetActive(false);
            }                
        }
        Time.timeScale = 1f;
    }
}
