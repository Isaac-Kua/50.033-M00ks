using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeSpriteGetter : MonoBehaviour
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
            switch(upgrades.mUpgrade){
                case(UpgradeManager.meleeUpgrade.Breaking):
                    image.sprite = icons.breaking;
                    break;
                case(UpgradeManager.meleeUpgrade.Zangief):
                    image.sprite = icons.zangief;
                    break;
                case(UpgradeManager.meleeUpgrade.Lunge):
                    image.sprite = icons.lunge;
                    break;
                case(UpgradeManager.meleeUpgrade.Repel):
                    image.sprite = icons.repel;
                    break;
                case(UpgradeManager.meleeUpgrade.Default):
                    image.sprite = icons.none;
                    break;
            }
        } catch {
            image.sprite = icons.none;
            return;
        }
    }
}
