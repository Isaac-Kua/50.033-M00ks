using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class TripleDashAbility : Ability
{
    public float dashSpeed;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
	private int count = 3;
    
    public override void Activate(GameObject parent)
    {
        rb = parent.GetComponent<Rigidbody2D>();
        parent.GetComponent<M00ks1Controller>().Immunity = true;
        //Debug.Log("Dash: Triple");
        StartCoroutine(DashCoroutine(parent));
    }

    private IEnumerator DashCoroutine(GameObject parent)
    {
        count -= 1;
        var endOfFrame = new WaitForEndOfFrame();
        //Debug.Log("dashing");		
        moveDirection = parent.GetComponent<M00ks1Controller>().faceDirection;
        for(float timer = 0; timer < activeTime; timer += Time.deltaTime)
        {
            rb.MovePosition(rb.position + (moveDirection * (dashSpeed * Time.deltaTime)));
            yield return endOfFrame;
        }
        parent.GetComponent<M00ks1Controller>().Immunity = false;
		
		if (count>0) {
			StartCoroutine(DashCoroutine(parent));
		}
		
		else {count = 3;}
    }
}
