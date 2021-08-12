using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =  "KnockbackRangedAbility", menuName =  "Ability 1/Knockback")]
public class KnockbackRangedAbility : Ability
{
    private Vector2 missilePosition;
    private Vector2 missileDirection;
    private Rigidbody2D rb;
    private float knockbackSpeed_copy;
    private float activeTime_copy;
    private int original_mask;

    public bool RangeMod = false;
    public bool BypassMod = false;
    public bool SpeedMod = false;
    public bool HeavyMod = false;

    void checkModifications(Ability1Holder parent)
    {
        RangeMod = parent.RangeMod;
        BypassMod = parent.BypassMod;
        SpeedMod = parent.SpeedMod;
        HeavyMod = parent.HeavyMod;
    }

    public override void Activate(GameObject parent)
    {
        checkModifications(parent.GetComponent<Ability1Holder>());
        missileDirection = parent.GetComponent<M00ks1Controller>().faceDirection;
        missilePosition = new Vector2(parent.transform.position.x, parent.transform.position.y);
        parent.GetComponent<M00ksDeathHandler>().Immunity = true;
        parent.tag = "PlayerArrow";
        rb = parent.GetComponent<Rigidbody2D>();
        original_mask = parent.layer;
        activeTime_copy = activeTime;
        knockbackSpeed_copy = gameConstants.knockbackSpeed;

        if(RangeMod){
            knockbackSpeed_copy = knockbackSpeed_copy*1.5f;
        }
        if(SpeedMod){
            activeTime_copy = activeTime_copy/1.5f;
            knockbackSpeed_copy = knockbackSpeed_copy*1.5f;
        }
        if(BypassMod){
            parent.layer  = LayerMask.NameToLayer("Danny");
        }

        // parent.GetComponent<M00ksDeathHandler>().Immunity = false;
        // parent.tag = "Player";
        // parent.layer  = LayerMask.NameToLayer("Players");
        StartCoroutine(ShootCoroutine(parent));

    }

    private IEnumerator ShootCoroutine(GameObject parent)
    {
        //yield return new WaitForSeconds(activeTime_copy);
        //missilePosition = missilePosition + missileDirection;
        //GameObject missile1 = Instantiate(missile, missilePosition, parent.transform.rotation);
        var endOfFrame = new WaitForEndOfFrame();
        for (float timer = 0; timer < activeTime_copy; timer += Time.deltaTime)
        {
            rb.MovePosition(rb.position + (missileDirection * (gameConstants.knockbackSpeed * Time.deltaTime)));
            //rb.AddForce(missileDirection*knockbackSpeed_copy*10f);
            yield return endOfFrame;
        }
        parent.GetComponent<M00ksDeathHandler>().Immunity = false;
        parent.tag = "Player";
        Debug.Log("layer change??");
        Debug.Log(parent.layer);
        parent.layer  = 7;
    }

}