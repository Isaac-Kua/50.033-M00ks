using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaitenModifications : MonoBehaviour
{
    public bool Range;
    public bool Bypass;
    public bool Speed;
    public bool Heavy;
    public GameObject KaitenProjectile;
    // Start is called before the first frame update
    void Start()
    {
        //Sprite = KaitenProjectile.GetComponent<SpriteRenderer>();
        //Collider = KaitenProjectile.GetComponent<BoxCollider2D>();
        //tf = KaitenProjectile.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Range)
        {
            // if (tf.localScale.x < 1f)
            // {
            //     tf.localScale = Vector2(1.5f, 1.5f);
            //     Collider.size = Vector2(1.5f, 1.5f); 
            // }
        }
        if(Bypass)
        {

        }
        if(Speed)
        {

        }
        if(Heavy)
        {

        }
    }
}
