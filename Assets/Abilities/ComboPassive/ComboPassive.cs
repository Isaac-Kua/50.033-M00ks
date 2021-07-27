using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboPassive : MonoBehaviour
{
    private GameConstants gameConstants;
    private GameObject TophAura;
    private GameObject JuggernautAura;
    //public bool WidowmakerCombo = false;
    //public bool JuggernautCombo = false;

    // Start is called before the first frame update

    private bool magnusActive = false;
    private bool achmedActive = false;
    private GameObject WidowmakerTarget;
    // Start is called before the first frame update
    void Start()
    {
        gameConstants = GetComponent<UpgradeManager>().gameConstants;
        TophAura = Instantiate(gameConstants.TophAura, transform.position, transform.rotation);
        TophAura.transform.parent = transform;
        JuggernautAura = Instantiate(gameConstants.JuggernautAura, transform.position, transform.rotation);
        JuggernautAura.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        gameConstants = GetComponent<UpgradeManager>().gameConstants;
        if (GetComponent<UpgradeManager>().MagnusCombo) {
            if (!magnusActive)
            {
                GetComponent<M00ks1Controller>().speed = gameConstants.MagnusSpeed;
                magnusActive = true;
            }
        } else {
            if (magnusActive)
            {
                GetComponent<M00ks1Controller>().speed = gameConstants.M00ksMoveSpeed;
                magnusActive = false;
            }
        }
        
        if (GetComponent<UpgradeManager>().TurtleCombo)
        {
            GetComponent<Rigidbody2D>().drag = gameConstants.defaultDrag;
        }

        TophAura.transform.position = transform.position;
        if (GetComponent<UpgradeManager>().TophCombo)
        {
            TophAura.SetActive(true);
        } else {
            TophAura.SetActive(false);
        }

        if (GetComponent<UpgradeManager>().AchmedCombo)
        {
            if (!achmedActive)
            {
                achmedActive = true;
                StartCoroutine(ItsATrap());
            }
        } else {
            achmedActive = false;
        }

        if (GetComponent<UpgradeManager>().DannyCombo) {
            gameObject.layer = LayerMask.NameToLayer("Danny"); ;
        } else {
            gameObject.layer = LayerMask.NameToLayer("Players"); ;
        }


        if (GetComponent<UpgradeManager>().WidowmakerCombo)
        {
            GetComponent<LineRenderer>().enabled = true;
            LineRenderer lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, transform.position);
            Vector3 point = GetComponent<M00ks1Controller>().faceDirection;
            lineRenderer.SetPosition(1, point * gameConstants.WidowmakerRange + transform.position);
            RaycastHit2D hit = Physics2D.Raycast(transform.position+ 2*point, point * gameConstants.WidowmakerRange);
            if (hit.collider != null){
                WidowmakerTarget = hit.collider.gameObject;
                if (hit.collider.tag == "Enemy" || hit.collider.tag == "Player") {
                    StartCoroutine(ISeeYou(hit.collider.gameObject));
                }
            } 
            Debug.DrawRay(transform.position + 2*point, point* gameConstants.WidowmakerRange, Color.blue);
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
        }


        JuggernautAura.transform.position = transform.position;
        if (GetComponent<UpgradeManager>().JuggernautCombo)
        {
            JuggernautAura.SetActive(true);
        }
        else
        {
            JuggernautAura.SetActive(false);
        }


        if (GetComponent<UpgradeManager>().PacquiaoCombo)
        {
            if (GetComponent<M00ksDeathHandler>().myLives < 1 && !GetComponent<M00ksDeathHandler>().Dead)
                {
                GameObject other = GetComponent<M00ksDeathHandler>().lastHit;
                GameObject pew = Instantiate(gameConstants.WidowmakerArrow, other.transform.position, transform.rotation);
                pew.GetComponent<ProjectileController>().owner = gameObject;
            }
        }

    }

    IEnumerator ItsATrap() {
        if (achmedActive) {
            yield return new WaitForSeconds(gameConstants.AchmedDuration);
            Instantiate(gameConstants.AchmedBomb,transform.position, transform.rotation);
            StartCoroutine(ItsATrap());
        }
    }

    IEnumerator ISeeYou(GameObject poorsoul)
    {
        yield return new WaitForSeconds(gameConstants.WidowmakerChargeDuration);
        if (WidowmakerTarget == poorsoul)
        {
            GameObject pew = Instantiate(gameConstants.WidowmakerArrow, poorsoul.transform.position, transform.rotation);
            pew.GetComponent<ProjectileController>().owner = gameObject;
        }
    }
}
