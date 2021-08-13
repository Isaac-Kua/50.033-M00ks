using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeGranter : MonoBehaviour
{
    public string upgrade;

    void OnTriggerEnter2D(Collider2D col)
    {
        grantUpgrade(col);

        this.gameObject.SetActive(false);
        UpgradeSelectionManager.Instance.playerSelected(col.gameObject.GetComponent<PlayerSoulController>().playerNo);
    }

    void grantUpgrade(Collider2D other)
    {
        switch (upgrade)
        {
            // Defence upgrades
            case "miniDefence":
                other.gameObject.GetComponent<UpgradeManager>().miniDefense = true;
                break;
            case "shellDefence":
                other.gameObject.GetComponent<UpgradeManager>().shellDefense = true;
                break;
            case "unstoppableDefence":
                other.gameObject.GetComponent<UpgradeManager>().unstoppableDefense = true;
                break;
            case "toughDefence":
                other.gameObject.GetComponent<UpgradeManager>().toughDefense = true;
                break;
            // Ability 1
            case "arrowRange":
                other.gameObject.GetComponent<UpgradeManager>().ab1Upgrade = UpgradeManager.ability1Upgrade.Arrow;
                break;
            case "kaitenRange":
                other.gameObject.GetComponent<UpgradeManager>().ab1Upgrade = UpgradeManager.ability1Upgrade.Kaiten;
                break;
            case "knockbackRange":
                other.gameObject.GetComponent<UpgradeManager>().ab1Upgrade = UpgradeManager.ability1Upgrade.Knockback;
                break;
            case "spikeRange":
                other.gameObject.GetComponent<UpgradeManager>().ab1Upgrade = UpgradeManager.ability1Upgrade.SpikeRange;
                break;
            // Ability 2
            case "goo":
                other.gameObject.GetComponent<UpgradeManager>().ab2Upgrade = UpgradeManager.ability2Upgrade.Goo;
                break;
            case "magnet":
                other.gameObject.GetComponent<UpgradeManager>().ab2Upgrade = UpgradeManager.ability2Upgrade.Magnet;
                break;
            case "mine":
                other.gameObject.GetComponent<UpgradeManager>().ab2Upgrade = UpgradeManager.ability2Upgrade.Mine;
                break;
            case "teleport":
                other.gameObject.GetComponent<UpgradeManager>().ab2Upgrade = UpgradeManager.ability2Upgrade.Teleport;
                break;
            // Death upgrades
            case "crawlDeath":
                other.gameObject.GetComponent<UpgradeManager>().crawlDeath = true;
                break;
            case "kamikazeDeath":
                other.gameObject.GetComponent<UpgradeManager>().kamikazeDeath = true;
                break;
            case "soulswapDeath":
                other.gameObject.GetComponent<UpgradeManager>().soulswapDeath = true;
                break;
            case "vengeanceDeath":
                other.gameObject.GetComponent<UpgradeManager>().vengeanceDeath = true;
                break;
            // On kill upgrades
            case "explosionKill":
                other.gameObject.GetComponent<UpgradeManager>().explosionKill = true;
                break;
            case "zombieKill":
                other.gameObject.GetComponent<UpgradeManager>().zombieKill = true;
                break;
            case "hasteKill":
                other.gameObject.GetComponent<UpgradeManager>().hasteKill = true;
                break;
            case "saiyanKill":
                other.gameObject.GetComponent<UpgradeManager>().saiyanKill = true;
                break;
            // Movement upgrades
            case "juggernautMove":
                other.gameObject.GetComponent<UpgradeManager>().juggernautMove = true;
                break;
            case "wallwalkerMove":
                other.gameObject.GetComponent<UpgradeManager>().wallwalkerMove = true;
                break;
            case "shivaMove":
                other.gameObject.GetComponent<UpgradeManager>().shivaMove = true;
                break;
            case "ghostMove":
                other.gameObject.GetComponent<UpgradeManager>().ghostMove = true;
                break;
            // Utility upgrades
            case "respawnUtil":
                other.gameObject.GetComponent<UpgradeManager>().respawnUtil = true;
                break;
            case "meleeUtil":
                other.gameObject.GetComponent<UpgradeManager>().meleeUtil = true;
                break;
            case "rangedUtil":
                other.gameObject.GetComponent<UpgradeManager>().rangedUtil = true;
                break;
            case "altUtil":
                other.gameObject.GetComponent<UpgradeManager>().altUtil = true;
                break;
            // Melee abilities
            case "breakingMelee":
                other.gameObject.GetComponent<UpgradeManager>().mUpgrade = UpgradeManager.meleeUpgrade.Breaking;
                break;
            case "repelMelee":
                other.gameObject.GetComponent<UpgradeManager>().mUpgrade = UpgradeManager.meleeUpgrade.Repel;
                break;
            case "zangiefMelee":
                other.gameObject.GetComponent<UpgradeManager>().mUpgrade = UpgradeManager.meleeUpgrade.Zangief;
                break;
            case "lungeMelee":
                other.gameObject.GetComponent<UpgradeManager>().mUpgrade = UpgradeManager.meleeUpgrade.Lunge;
                break;
            // Dash upgrades
            case "phaseDash":
                other.gameObject.GetComponent<UpgradeManager>().dUpgrade = UpgradeManager.dashUpgrade.Phase;
                break;
            case "tripleDash":
                other.gameObject.GetComponent<UpgradeManager>().dUpgrade = UpgradeManager.dashUpgrade.Triple;
                break;
            case "spiderDash":
                other.gameObject.GetComponent<UpgradeManager>().dUpgrade = UpgradeManager.dashUpgrade.Spider;
                break;
            case "reverseDash":
                other.gameObject.GetComponent<UpgradeManager>().dUpgrade = UpgradeManager.dashUpgrade.Reverse;
                break;
            // Ranged upgrades
            case "rangedBullet":
                other.gameObject.GetComponent<UpgradeManager>().rangedBullet = true;;
                break;
            case "phaseBullet":
                other.gameObject.GetComponent<UpgradeManager>().phaseBullet = true;
                break;
            case "heavyBullet":
                other.gameObject.GetComponent<UpgradeManager>().heavyBullet = true;
                break;
            case "homingBullet":
                other.gameObject.GetComponent<UpgradeManager>().homingBullet = true;
                break;
            default:
                Debug.Log("No such upgrade");
                break;
        }
    }
}
