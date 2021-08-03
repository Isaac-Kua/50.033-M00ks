using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaveController : MonoBehaviour
{
    private Rigidbody2D marioBody;
    // Start is called before the first frame update
    void Start()
    {
        marioBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown("a"))
        {
            // check velocity
            if (Mathf.Abs(marioBody.velocity.x) >  0.01) {
            }

        }

        if (Input.GetKeyDown("d"))
        {
            // check velocity
            if (Mathf.Abs(marioBody.velocity.x) >  0.01) {
            }

        }  
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (Mathf.Abs(moveHorizontal) > 0)
        {
            //make mario glow when moving
            Vector2 movement = new Vector2(moveHorizontal, 0);
            if (marioBody.velocity.magnitude < 20)
            {
                    marioBody.AddForce(movement * 10);
            }
        }
        }
}
