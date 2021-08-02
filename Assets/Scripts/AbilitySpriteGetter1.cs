using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySpriteGetter1 : MonoBehaviour
{
    public int player;
    public Sprite spike;
    public Sprite arrow;
    public Sprite kaiten;
    public Sprite knockback;
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
        GameObject playerPrefab = PlayerConfigurationManager.Instance.getPlayerPrefab(player);
        UpgradeManager upgrades = playerPrefab.GetComponent<UpgradeManager>();
        switch(upgrades.ab1Upgrade){
            case(UpgradeManager.ability1Upgrade.SpikeRange):
                image.sprite = spike;
                break;
            case(UpgradeManager.ability1Upgrade.Kaiten):
                image.sprite = kaiten;
                break;
            case(UpgradeManager.ability1Upgrade.Knockback):
                image.sprite = knockback;
                break;
            case(UpgradeManager.ability1Upgrade.Default):
                image.sprite = arrow;
                break;
        }
    }
}
