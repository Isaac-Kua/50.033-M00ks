using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySpriteGetter2 : MonoBehaviour
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
            switch(upgrades.ab2Upgrade){
                case(UpgradeManager.ability2Upgrade.Goo):
                    image.sprite = icons.goo;
                    break;
                case(UpgradeManager.ability2Upgrade.Magnet):
                    image.sprite = icons.magnet;
                    break;
                case(UpgradeManager.ability2Upgrade.Teleport):
                    image.sprite = icons.teleport;
                    break;
                case(UpgradeManager.ability2Upgrade.Mine):
                    image.sprite = icons.mine;
                    break;
                case(UpgradeManager.ability2Upgrade.Default):
                    image.sprite = icons.none;
                    break;
            }
        }
        catch {
            return;
        }
    }
}
