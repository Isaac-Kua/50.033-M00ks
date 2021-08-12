using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySpriteGetter1 : MonoBehaviour
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
            switch(upgrades.ab1Upgrade){
                case(UpgradeManager.ability1Upgrade.SpikeRange):
                    image.sprite = icons.spike;
                    break;
                case(UpgradeManager.ability1Upgrade.Kaiten):
                    image.sprite = icons.kaiten;
                    break;
                case(UpgradeManager.ability1Upgrade.Knockback):
                    image.sprite = icons.knockback;
                    break;
                case(UpgradeManager.ability1Upgrade.Arrow):
                    image.sprite = icons.arrow;
                    break;
                case(UpgradeManager.ability1Upgrade.Default):
                    image.sprite = icons.none;
                    break;
            }
        }
        catch {
            return;
        }
    }
}
