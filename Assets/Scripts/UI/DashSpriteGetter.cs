using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashSpriteGetter : MonoBehaviour
{
    public int player;
    public Icons icons;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        updateSprite();
    }

    void updateSprite()
    {
        try {
            GameObject playerPrefab = PlayerConfigurationManager.Instance.getPlayerPrefab(player);
            UpgradeManager upgrades = playerPrefab.GetComponent<UpgradeManager>();
            switch(upgrades.dUpgrade){
                case(UpgradeManager.dashUpgrade.Phase):
                    image.sprite = icons.phaseDash;
                    break;
                case(UpgradeManager.dashUpgrade.Triple):
                    image.sprite = icons.tripleDash;
                    break;
                case(UpgradeManager.dashUpgrade.Spider):
                    image.sprite = icons.spiderDash;
                    break;
                case(UpgradeManager.dashUpgrade.Reverse):
                    image.sprite = icons.reverseDash;
                    break;
                case(UpgradeManager.dashUpgrade.Default):
                    image.sprite = icons.none;
                    break;
            }
        }
        catch {
            return;
        }
    }
}
