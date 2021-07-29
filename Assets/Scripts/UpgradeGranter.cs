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
            case "miniDefence":
                break;
            case "shellDefence":
                break;
            case "unstoppableDefence":
                break;
            case "toughDefence":
                break;
            case "arrowRange":
                other.gameObject.GetComponent<UpgradeManager>().ab1Upgrade = UpgradeManager.ability1Upgrade.Default;
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
            default:
                Debug.Log("No such upgrade");
                break;
        }
    }
}
