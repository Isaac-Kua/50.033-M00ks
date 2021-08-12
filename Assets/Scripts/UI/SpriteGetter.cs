using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteGetter : MonoBehaviour
{
    public int player;
    public Icons icons;
    private Sprite playerSprite;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        if (player < GameManager.Instance.totalPlayers) {
            playerSprite = PlayerConfigurationManager.Instance.getPlayerSprite(player);
            image.sprite = playerSprite;
        }
        else {
            image.sprite = icons.none;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
