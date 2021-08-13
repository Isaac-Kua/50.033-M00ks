using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovePassive : MonoBehaviour
{
    private GameConstants gameConstants;
    private float stillTimeStamp;
    public GameObject vision;
    
    private Rigidbody2D m00ksBody;
    private SpriteRenderer m00ksSprite;
    private bool ghost;

    // Start is called before the first frame update
    void Start()
    {
        gameConstants = GetComponent<UpgradeManager>().gameConstants;
        m00ksSprite = GetComponent<SpriteRenderer>();
        m00ksBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        gameConstants = GetComponent<UpgradeManager>().gameConstants;
        ghost = GetComponent<M00ksDeathHandler>().Invisible;
        if (GetComponent<UpgradeManager>().ghostMove)
        {
            if (m00ksBody.velocity != Vector2.zero)
            {
                stillTimeStamp = Time.time;
            }
            if (Time.time - stillTimeStamp > gameConstants.ghostFadeDuration)
            {
                if (!ghost)
                {
                    GetComponent<M00ksDeathHandler>().Invisible = true;
                    vision.SetActive(false);
                    ghost = GetComponent<M00ksDeathHandler>().Invisible;
                    StartCoroutine(Flicker());
                }
            }
        } else
        {
            GetComponent<M00ksDeathHandler>().Invisible = false;
            vision.SetActive(true);
        }

    }

    IEnumerator Flicker() {
        if (ghost) {
            yield return new WaitForSeconds(gameConstants.ghostFlickerDuration);
            vision.SetActive(true);
            yield return new WaitForSeconds(gameConstants.ghostApparitionDuration);
            vision.SetActive(false);
            StartCoroutine(Flicker());
        }
    }


}
