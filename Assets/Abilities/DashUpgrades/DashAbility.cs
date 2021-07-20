using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class DashAbility : Ability
{
    public float dashSpeed;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    
    public override void Activate(GameObject parent)
    {
        rb = parent.GetComponent<Rigidbody2D>();
        moveDirection = parent.GetComponent<M00ks1Controller>().faceDirection;
        parent.GetComponent<M00ksDeathHandler>().Immunity = true;
        //Debug.Log("Dashing in DashAbility");
        StartCoroutine(DashCoroutine(parent));
    }

    private IEnumerator DashCoroutine(GameObject parent)
    {
        var endOfFrame = new WaitForEndOfFrame();
        //Debug.Log("dashing");
        for(float timer = 0; timer < activeTime; timer += Time.deltaTime)
        {
            rb.MovePosition(rb.position + (moveDirection * (dashSpeed * Time.deltaTime)));
            yield return endOfFrame;
        }
        parent.GetComponent<M00ksDeathHandler>().Immunity = false;
    }
}
