using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinorSpriteGetter : MonoBehaviour
{
    public int player;
    public Icons icons;
    private Dictionary<string, bool> upgrades;

    // Start is called before the first frame update
    void Start()
    {
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
            upgrades = playerPrefab.GetComponent<UpgradeManager>().GetUpgrades();
            foreach (Transform eachchild in transform){
                Sprite nosprite = getIcon(null);
                eachchild.gameObject.GetComponent<Image>().sprite = nosprite;
                foreach (KeyValuePair<string, bool> upgrade in upgrades){
                    if (upgrade.Value == true){
                        Sprite icon = getIcon(upgrade.Key);
                        eachchild.gameObject.GetComponent<Image>().sprite = icon;
                        upgrades.Remove(upgrade.Key);
                        break;
                    }
                }
            }
        } catch {
            foreach (Transform eachchild in transform){
                Sprite nosprite = getIcon(null);
            }
            return;
        }
    }

    Sprite getIcon(string upgrade)
    {
        switch (upgrade){
            // Defence upgrades
            case "miniDef":
                return icons.miniDef;
            case "shellDef":
                return icons.shellDef;
            case "unstoppableDef":
                return icons.unstoppableDef;
            case "toughDef":
                return icons.toughDef;
            // Death upgrades
            case "crawlDeath":
                return icons.crawl;
            case "kamikazeDeath":
                return icons.kamikaze;
            case "soulswapDeath":
                return icons.soulswap;
            case "vengeanceDeath":
                return icons.vengeance;
            // On kill upgrades
            case "explosionKill":
                return icons.explosion;
            case "zombieKill":
                return icons.zombie;
            case "hasteKill":
                return icons.haste;
            case "saiyanKill":
                return icons.saiyan;
            // Movement upgrades
            case "juggernautMove":
                return icons.juggernaut;
            case "wallwalkerMove":
                return icons.wallwalker;
            case "shivaMove":
                return icons.shiva;
            case "ghostMove":
                return icons.ghost;
            // Utility upgrades
            case "respawnUtil":
                return icons.respawn;
            case "meleeUtil":
                return icons.meleeUtil;
            case "rangedUtil":
                return icons.rangedUtil;
            case "altUtil":
                return icons.altUtil;
            // Ranged upgrades
            case "rangedBullet":
                return icons.rangedBullet;
            case "phaseBullet":
                return icons.phaseBullet;
            case "heavyBullet":
                return icons.heavyBullet;
            case "homingBullet":
                return icons.homingBullet;
            default:
                return icons.none;
        }
    }
}
