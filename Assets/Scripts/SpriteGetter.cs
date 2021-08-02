using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteGetter : MonoBehaviour
{
    public int player;
    private Sprite playerSprite;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = PlayerConfigurationManager.Instance.getPlayerSprite(player);
        image = GetComponent<Image>();
        image.sprite = playerSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
