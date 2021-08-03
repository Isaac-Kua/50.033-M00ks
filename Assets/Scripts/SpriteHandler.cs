using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHandler : MonoBehaviour
{
    private SpriteRenderer charSprite;
    private bool faceRight = true;
    
    // Start is called before the first frame update
    void Start()
    {
        charSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        charSprite.flipX = !faceRight;
    }
}
