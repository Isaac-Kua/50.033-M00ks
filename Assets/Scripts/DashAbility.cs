using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DashAbility : Ability
{
    public float dashSpeed;
    private Coroutine dash = null;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    
    public override void Activate(GameObject parent)
    {
        rb = parent.GetComponent<Rigidbody2D>();
        moveDirection = parent.GetComponent<PlayerMovement>().moveDirection;
        Debug.Log("Dashing in DashAbility");
        StartCoroutine(DashCoroutine());
    }

    private IEnumerator DashCoroutine()
    {
        var endOfFrame = new WaitForEndOfFrame();
        Debug.Log("dashing");
        for(float timer = 0; timer < activeTime; timer += Time.deltaTime)
        {
            rb.MovePosition(rb.position + (moveDirection * (dashSpeed * Time.deltaTime)));
            yield return endOfFrame;
        }
        dash = null;
    }
}
