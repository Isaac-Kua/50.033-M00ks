using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ConditionScreen : MonoBehaviour
{
    public GameObject select;
    
    // Start is called before the first frame update
    void Start()
    {
        UpgradeSelectionManager.SelectMetric += load;
    }

    void load()
    {
        Time.timeScale = 0f;
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "ConditionScreen")
            {
                eachChild.gameObject.SetActive(true);
            }
        }
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(select, new BaseEventData(eventSystem));
    }

    public void condition(string metric)
    {
        GameManager.Instance.currentMetric = metric;
        next();
    }

    void next()
    {
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "ConditionScreen")
            {
                eachChild.gameObject.SetActive(false);
            }
        }
        Time.timeScale = 1f;
    }
}
