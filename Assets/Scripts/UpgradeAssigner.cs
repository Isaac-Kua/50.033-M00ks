using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeAssigner : MonoBehaviour
{
    public GameObject upgrade1;
    public GameObject upgrade2;
    public GameObject upgrade3;
    public GameObject upgrade4;
    public Text upgrade1Text;
    public Text upgrade2Text;
    public Text upgrade3Text;
    public Text upgrade4Text;
    public Icons icons;

    // Start is called before the first frame update
    void Start()
    {
        AltarManager.NextStage2 += assignUpgrade;
    }

    private void OnDestroy() {
        AltarManager.NextStage2 -= assignUpgrade;
    }

    // Update is called once per frame
    public void assignUpgrade()
    {
        switch (GameManager.Instance.upgradeNo)
        {
            case 1:
                // Ranged ability
                upgrade1.GetComponent<UpgradeGranter>().upgrade = "spikeRange";
                upgrade1.GetComponent<SpriteRenderer>().sprite = icons.spike;
                upgrade1.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade1Text.text = "Ice Spikes";
                upgrade2.GetComponent<UpgradeGranter>().upgrade = "kaitenRange";
                upgrade2.GetComponent<SpriteRenderer>().sprite = icons.kaiten;
                upgrade2.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade2Text.text = "Kaiten";
                upgrade3.GetComponent<UpgradeGranter>().upgrade = "knockbackRange";
                upgrade3.GetComponent<SpriteRenderer>().sprite = icons.knockback;
                upgrade3.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade3Text.text = "Knockback";
                upgrade4.GetComponent<UpgradeGranter>().upgrade = "arrowRange";
                upgrade4.GetComponent<SpriteRenderer>().sprite = icons.arrow;
                upgrade4.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(0.5f, 0.5f);
                upgrade4Text.text = "Arrow";
                break;
            case 2:
                // Ranged upgrade
                upgrade1.GetComponent<UpgradeGranter>().upgrade = "rangedBullet";
                upgrade1.GetComponent<SpriteRenderer>().sprite = icons.rangedBullet;
                upgrade1.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade1Text.text = "Increase Range";
                upgrade2.GetComponent<UpgradeGranter>().upgrade = "phaseBullet";
                upgrade2.GetComponent<SpriteRenderer>().sprite = icons.phaseBullet;
                upgrade2.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade2Text.text = "Phasing Shot";
                upgrade3.GetComponent<UpgradeGranter>().upgrade = "heavyBullet";
                upgrade3.GetComponent<SpriteRenderer>().sprite = icons.heavyBullet;
                upgrade3.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade3Text.text = "Heavy Shot";
                upgrade4.GetComponent<UpgradeGranter>().upgrade = "homingBullet";
                upgrade4.GetComponent<SpriteRenderer>().sprite = icons.homingBullet;
                upgrade4.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade4Text.text = "Speed Shot";
                break;
            case 3:
                // Alt ability
                upgrade1.GetComponent<UpgradeGranter>().upgrade = "goo";
                upgrade1.GetComponent<SpriteRenderer>().sprite = icons.goo;
                upgrade1.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade1Text.text = "Goo Pool";
                upgrade2.GetComponent<UpgradeGranter>().upgrade = "magnet";
                upgrade2.GetComponent<SpriteRenderer>().sprite = icons.magnet;
                upgrade2.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade2Text.text = "Bansho Tenin";
                upgrade3.GetComponent<UpgradeGranter>().upgrade = "mine";
                upgrade3.GetComponent<SpriteRenderer>().sprite = icons.mine;
                upgrade3.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(0.5f, 0.5f);
                upgrade3Text.text = "Stasis Mine";
                upgrade4.GetComponent<UpgradeGranter>().upgrade = "teleport";
                upgrade4.GetComponent<SpriteRenderer>().sprite = icons.teleport;
                upgrade4.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(0.5f, 0.5f);
                upgrade4Text.text = "Teleport";
                break;
            case 4:
                // Defence upgrades
                upgrade1.GetComponent<UpgradeGranter>().upgrade = "miniDefence";
                upgrade1.GetComponent<SpriteRenderer>().sprite = icons.miniDef;
                upgrade1.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade1Text.text = "Shrink Shroom";
                upgrade2.GetComponent<UpgradeGranter>().upgrade = "shellDefence";
                upgrade2.GetComponent<SpriteRenderer>().sprite = icons.shellDef;
                upgrade2.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade2Text.text = "Bristleback";
                upgrade3.GetComponent<UpgradeGranter>().upgrade = "toughDefence";
                upgrade3.GetComponent<SpriteRenderer>().sprite = icons.toughDef;
                upgrade3.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade3Text.text = "1 UP";
                upgrade4.GetComponent<UpgradeGranter>().upgrade = "unstoppableDefence";
                upgrade4.GetComponent<SpriteRenderer>().sprite = icons.unstoppableDef;
                upgrade4.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade4Text.text = "Unstoppable";
                break;
            case 5:
                // Dash abilities
                upgrade1.GetComponent<UpgradeGranter>().upgrade = "phaseDash";
                upgrade1.GetComponent<SpriteRenderer>().sprite = icons.phaseDash;
                upgrade1.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade1Text.text = "Phase Dash";
                upgrade2.GetComponent<UpgradeGranter>().upgrade = "tripleDash";
                upgrade2.GetComponent<SpriteRenderer>().sprite = icons.tripleDash;
                upgrade2.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade2Text.text = "Triple Dash";
                upgrade3.GetComponent<UpgradeGranter>().upgrade = "spiderDash";
                upgrade3.GetComponent<SpriteRenderer>().sprite = icons.toughDef;
                upgrade3.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade3Text.text = "Spider Dash";
                upgrade4.GetComponent<UpgradeGranter>().upgrade = "reverseDash";
                upgrade4.GetComponent<SpriteRenderer>().sprite = icons.unstoppableDef;
                upgrade4.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade4Text.text = "Rewind";
                break;
            case 6:
                // On Death effects
                upgrade1.GetComponent<UpgradeGranter>().upgrade = "crawlDeath";
                upgrade1.GetComponent<SpriteRenderer>().sprite = icons.crawl;
                upgrade1.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade1Text.text = "Undying";
                upgrade2.GetComponent<UpgradeGranter>().upgrade = "kamikazeDeath";
                upgrade2.GetComponent<SpriteRenderer>().sprite = icons.kamikaze;
                upgrade2.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade2Text.text = "Kamikaze";
                upgrade3.GetComponent<UpgradeGranter>().upgrade = "soulswapDeath";
                upgrade3.GetComponent<SpriteRenderer>().sprite = icons.soulswap;
                upgrade3.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade3Text.text = "Nether Swap";
                upgrade4.GetComponent<UpgradeGranter>().upgrade = "vengeanceDeath";
                upgrade4.GetComponent<SpriteRenderer>().sprite = icons.vengeance;
                upgrade4.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade4Text.text = "Vengeance";
                break;
            case 7:
                // Melee Abilities
                upgrade1.GetComponent<UpgradeGranter>().upgrade = "breakingMelee";
                upgrade1.GetComponent<SpriteRenderer>().sprite = icons.breaking;
                upgrade1.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade1Text.text = "Super Strength";
                upgrade2.GetComponent<UpgradeGranter>().upgrade = "repelMelee";
                upgrade2.GetComponent<SpriteRenderer>().sprite = icons.repel;
                upgrade2.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade2Text.text = "Deflect";
                upgrade3.GetComponent<UpgradeGranter>().upgrade = "zangiefMelee";
                upgrade3.GetComponent<SpriteRenderer>().sprite = icons.zangief;
                upgrade3.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade3Text.text = "Zangief";
                upgrade4.GetComponent<UpgradeGranter>().upgrade = "lungeMelee";
                upgrade4.GetComponent<SpriteRenderer>().sprite = icons.lunge;
                upgrade4.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade4Text.text = "Lunge";
                break;
            case 8:
                // On Kill effects
                upgrade1.GetComponent<UpgradeGranter>().upgrade = "explosionKill";
                upgrade1.GetComponent<SpriteRenderer>().sprite = icons.explosion;
                upgrade1.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade1Text.text = "Explosion";
                upgrade2.GetComponent<UpgradeGranter>().upgrade = "zombieKill";
                upgrade2.GetComponent<SpriteRenderer>().sprite = icons.zombie;
                upgrade2.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade2Text.text = "Infestation";
                upgrade3.GetComponent<UpgradeGranter>().upgrade = "hasteKill";
                upgrade3.GetComponent<SpriteRenderer>().sprite = icons.haste;
                upgrade3.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade3Text.text = "Get Excited";
                upgrade4.GetComponent<UpgradeGranter>().upgrade = "saiyanKill";
                upgrade4.GetComponent<SpriteRenderer>().sprite = icons.saiyan;
                upgrade4.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade4Text.text = "Saiyan";
                break;
            case 9:
                // Movement effects
                upgrade1.GetComponent<UpgradeGranter>().upgrade = "juggernautMove";
                upgrade1.GetComponent<SpriteRenderer>().sprite = icons.juggernaut;
                upgrade1.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade1Text.text = "Juggernaut";
                upgrade2.GetComponent<UpgradeGranter>().upgrade = "wallwalkerMove";
                upgrade2.GetComponent<SpriteRenderer>().sprite = icons.wallwalker;
                upgrade2.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade2Text.text = "Wall Walker";
                upgrade3.GetComponent<UpgradeGranter>().upgrade = "shivaMove";
                upgrade3.GetComponent<SpriteRenderer>().sprite = icons.shiva;
                upgrade3.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade3Text.text = "Shiva";
                upgrade4.GetComponent<UpgradeGranter>().upgrade = "ghostMove";
                upgrade4.GetComponent<SpriteRenderer>().sprite = icons.ghost;
                upgrade4.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade4Text.text = "Ghost";
                break;
            case 10:
                // Utility upgrades
                upgrade1.GetComponent<UpgradeGranter>().upgrade = "respawnUtil";
                upgrade1.GetComponent<SpriteRenderer>().sprite = icons.respawn;
                upgrade1.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(0.5f, 0.5f);
                upgrade1Text.text = "Faster Respawn";
                upgrade2.GetComponent<UpgradeGranter>().upgrade = "meleeUtil";
                upgrade2.GetComponent<SpriteRenderer>().sprite = icons.meleeUtil;
                upgrade2.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(0.5f, 0.5f);
                upgrade2Text.text = "Attack Speed";
                upgrade3.GetComponent<UpgradeGranter>().upgrade = "rangedUtil";
                upgrade3.GetComponent<SpriteRenderer>().sprite = icons.rangedUtil;
                upgrade3.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(0.5f, 0.5f);
                upgrade3Text.text = "More Charges";
                upgrade4.GetComponent<UpgradeGranter>().upgrade = "altUtil";
                upgrade4.GetComponent<SpriteRenderer>().sprite = icons.altUtil;
                upgrade4.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(0.5f, 0.5f);
                upgrade4Text.text = "Faster Cooldown";
                break;
            default:
                Debug.Log("WHat upgrade is this?");
                break;
        }
    }
}
