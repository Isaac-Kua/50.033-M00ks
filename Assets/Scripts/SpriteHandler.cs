using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHandler : MonoBehaviour
{
    private Rigidbody2D charBody;
    private SpriteRenderer charSprite;
    private bool faceRight = true;
    
    // Start is called before the first frame update
    void Start()
    {
        charBody = GetComponent<Rigidbody2D>();
        charSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (charBody.velocity.x < 0)
        {
            faceRight = false;
        }
        else if (charBody.velocity.x > 0)
        {
            faceRight = true;
        }
        charSprite.flipX = faceRight;
    }
}
