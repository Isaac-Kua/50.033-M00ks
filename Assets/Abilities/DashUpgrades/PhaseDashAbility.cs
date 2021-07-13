using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class PhaseDashAbility : Ability
{
    public float dashSpeed;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    
    public override void Activate(GameObject parent)
    {
        rb = parent.GetComponent<Rigidbody2D>();
        moveDirection = parent.GetComponent<M00ks1Controller>().faceDirection;
        parent.GetComponent<M00ks1Controller>().Immunity = true;
		parent.GetComponent<Collider2D>().isTrigger = true;
        Debug.Log("Dashing in DashAbility");
        StartCoroutine(DashCoroutine(parent));
    }

    private IEnumerator DashCoroutine(GameObject parent)
    {
        var endOfFrame = new WaitForEndOfFrame();
        Debug.Log("dashing");
		Debug.Log(rb.velocity.normalized);
		Debug.Log(dashSpeed);
        for(float timer = 0; timer < activeTime; timer += Time.deltaTime)
        {
            rb.MovePosition(rb.position + (moveDirection * (dashSpeed * Time.deltaTime)));
            yield return endOfFrame;
        }
		parent.GetComponent<Collider2D>().isTrigger = false;
        parent.GetComponent<M00ks1Controller>().Immunity = false;
    }
}
