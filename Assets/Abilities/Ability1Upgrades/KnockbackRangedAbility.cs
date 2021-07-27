using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =  "KnockbackRangedAbility", menuName =  "Ability 1/Knockback")]
public class KnockbackRangedAbility : Ability
{
    private Vector2 missilePosition;
    private Vector2 missileDirection;
    private Rigidbody2D rb;
    public override void Activate(GameObject parent)
    {
        missileDirection = parent.GetComponent<M00ks1Controller>().faceDirection;
        missilePosition = new Vector2(parent.transform.position.x, parent.transform.position.y);
        parent.GetComponent<M00ksDeathHandler>().Immunity = true;
        parent.tag = "PlayerArrow";
        rb = parent.GetComponent<Rigidbody2D>();
        StartCoroutine(ShootCoroutine(parent));
    }

    private IEnumerator ShootCoroutine(GameObject parent)
    {
        yield return new WaitForSeconds(activeTime);
        //missilePosition = missilePosition + missileDirection;
        //GameObject missile1 = Instantiate(missile, missilePosition, parent.transform.rotation);
        var endOfFrame = new WaitForEndOfFrame();
        for (float timer = 0; timer < activeTime; timer += Time.deltaTime)
        {
            rb.MovePosition(rb.position + (missileDirection * (gameConstants.knockbackSpeed * Time.deltaTime)));
            yield return endOfFrame;
        }
        parent.GetComponent<M00ksDeathHandler>().Immunity = false;
        parent.tag = "Player";
    }

}