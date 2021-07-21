using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggernautMovePassive : MonoBehaviour
{
    public GameConstants gameConstants;
    private float motionTimeStamp;
    private Rigidbody2D m00ksBody;
    private GameObject bubble;
    private bool jugg;
    // Start is called before the first frame update
    void Start()
    {
        m00ksBody = GetComponent<Rigidbody2D>();
        jugg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<UpgradeManager>().juggernautMove)
        {
            if (m00ksBody.velocity == Vector2.zero)
            {
                motionTimeStamp = Time.time;
            }

            if (Time.time - motionTimeStamp > gameConstants.juggernautRampDuration)
            {
                if (!jugg)
                {
                    jugg = true;
                    GetComponent<M00ks1Controller>().speed *= gameConstants.juggernautRatio;
                    bubble = Instantiate(gameConstants.juggernautBubble, transform.position, transform.rotation);
                    bubble.GetComponent<ProjectileController>().owner = gameObject;
                    bubble.transform.localScale = bubble.transform.localScale * gameConstants.juggernautSize;
                    bubble.transform.parent = gameObject.transform;
                }
            }
            else if (jugg)
            {
                Destroy(bubble);
                GetComponent<M00ks1Controller>().speed /= gameConstants.juggernautRatio;
                jugg = false;
            }
        }
    }
}
