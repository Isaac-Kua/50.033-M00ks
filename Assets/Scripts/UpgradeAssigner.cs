using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAssigner : MonoBehaviour
{
    public GameObject upgrade1;
    public GameObject upgrade2;
    public GameObject upgrade3;
    public GameObject upgrade4;

    public Sprite spike;
    public Sprite kaiten;
    public Sprite knockback;
    public Sprite arrow;
    public Sprite goo;
    public Sprite magnet;
    public Sprite mine;
    public Sprite teleport;
    public Sprite miniDef;
    public Sprite shellDef;
    public Sprite unstoppableDef;
    public Sprite toughDef;
    public Sprite crawl;
    public Sprite kamikaze;
    public Sprite soulswap;
    public Sprite vengeance;

    // Start is called before the first frame update
    void Start()
    {
        AltarManager.NextStage += assignUpgrade;
    }

    // Update is called once per frame
    void assignUpgrade()
    {
        switch (GameManager.Instance.stage)
        {
            case 1:
                // Ranged ability
                upgrade1.GetComponent<UpgradeGranter>().upgrade = "spikeRange";
                upgrade1.GetComponent<SpriteRenderer>().sprite = spike;
                upgrade1.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade2.GetComponent<UpgradeGranter>().upgrade = "kaitenRange";
                upgrade2.GetComponent<SpriteRenderer>().sprite = kaiten;
                upgrade2.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade3.GetComponent<UpgradeGranter>().upgrade = "knockbackRange";
                upgrade3.GetComponent<SpriteRenderer>().sprite = knockback;
                upgrade3.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade4.GetComponent<UpgradeGranter>().upgrade = "arrowRange";
                upgrade4.GetComponent<SpriteRenderer>().sprite = arrow;
                upgrade4.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                break;
            case 2:
                // Alt ability
                upgrade1.GetComponent<UpgradeGranter>().upgrade = "goo";
                upgrade1.GetComponent<SpriteRenderer>().sprite = goo;
                upgrade1.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade2.GetComponent<UpgradeGranter>().upgrade = "magnet";
                upgrade2.GetComponent<SpriteRenderer>().sprite = magnet;
                upgrade2.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade3.GetComponent<UpgradeGranter>().upgrade = "mine";
                upgrade3.GetComponent<SpriteRenderer>().sprite = mine;
                upgrade3.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(0.5f, 0.5f);
                upgrade4.GetComponent<UpgradeGranter>().upgrade = "teleport";
                upgrade4.GetComponent<SpriteRenderer>().sprite = teleport;
                upgrade4.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(0.5f, 0.5f);
                break;
            case 3:
                // Defence upgrades
                upgrade1.GetComponent<UpgradeGranter>().upgrade = "miniDefence";
                upgrade1.GetComponent<SpriteRenderer>().sprite = miniDef;
                upgrade1.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade2.GetComponent<UpgradeGranter>().upgrade = "shellDefence";
                upgrade2.GetComponent<SpriteRenderer>().sprite = shellDef;
                upgrade2.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade3.GetComponent<UpgradeGranter>().upgrade = "toughDefence";
                upgrade3.GetComponent<SpriteRenderer>().sprite = toughDef;
                upgrade3.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade4.GetComponent<UpgradeGranter>().upgrade = "unstoppabaleDefence";
                upgrade4.GetComponent<SpriteRenderer>().sprite = unstoppableDef;
                upgrade4.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                break;
            case 4:
                // On Death effects
                upgrade1.GetComponent<UpgradeGranter>().upgrade = "crawlDeath";
                upgrade1.GetComponent<SpriteRenderer>().sprite = crawl;
                upgrade1.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade2.GetComponent<UpgradeGranter>().upgrade = "kamikazeDeath";
                upgrade2.GetComponent<SpriteRenderer>().sprite = kamikaze;
                upgrade2.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade3.GetComponent<UpgradeGranter>().upgrade = "soulswapDeath";
                upgrade3.GetComponent<SpriteRenderer>().sprite = soulswap;
                upgrade3.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                upgrade4.GetComponent<UpgradeGranter>().upgrade = "vengeanceDeath";
                upgrade4.GetComponent<SpriteRenderer>().sprite = vengeance;
                upgrade4.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(2, 2);
                break;
            case 5:
                break;
            default:
                Debug.Log("WHat stage is this?");
                break;
        }
    }
}
