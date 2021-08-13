using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToughDefensePassive : MonoBehaviour
{
	private GameConstants gameConstants;
    public SpriteRenderer toughDefenseSprite;
    private GameObject toughField;
    // Start is called before the first frame update
    void Start()
    {
        gameConstants = GetComponent<UpgradeManager>().gameConstants;
        toughField = Instantiate(gameConstants.toughField, transform.position, transform.rotation);
        toughField.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        gameConstants = GetComponent<UpgradeManager>().gameConstants;
        if (GetComponent<UpgradeManager>().toughDefense){
			GetComponent<M00ksDeathHandler>().lives = gameConstants.thugLives;
            toughField.SetActive(true);

		} else {
			GetComponent<M00ksDeathHandler>().lives = gameConstants.defaultLives;
            toughField.SetActive(false);
		}
    }
}
