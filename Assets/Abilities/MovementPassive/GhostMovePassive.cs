using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovePassive : MonoBehaviour
{
    public GameConstants gameConstants;
    private float stillTimeStamp;

    private Rigidbody2D m00ksBody;
    private SpriteRenderer m00ksSprite;
    private bool ghost;

    // Start is called before the first frame update
    void Start()
    {
        m00ksSprite = GetComponent<SpriteRenderer>();
        m00ksBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<UpgradeManager>().ghostMove)
        {
            ghost = GetComponent<M00ksDeathHandler>().Invisible;
            if (m00ksBody.velocity != Vector2.zero)
            {
                stillTimeStamp = Time.time;
            }
            if (Time.time - stillTimeStamp > gameConstants.ghostFadeDuration)
            {
                if (!ghost)
                {
                    GetComponent<M00ksDeathHandler>().Invisible = true;
                    m00ksSprite.enabled = false;
                    ghost = GetComponent<M00ksDeathHandler>().Invisible;
                    StartCoroutine(Flicker());
                }
            }
        } else
        {
            GetComponent<M00ksDeathHandler>().Invisible = false;
            m00ksSprite.enabled = true;
        }

    }

    IEnumerator Flicker() {
        if (ghost) {
            yield return new WaitForSeconds(gameConstants.ghostFlickerDuration);
            m00ksSprite.enabled = true;
            yield return new WaitForSeconds(gameConstants.ghostApparitionDuration);
            m00ksSprite.enabled = false;
            StartCoroutine(Flicker());
        }
    }


}
