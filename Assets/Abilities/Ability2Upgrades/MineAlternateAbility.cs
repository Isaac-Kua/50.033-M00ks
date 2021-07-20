using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MineAlternateAbility : Ability
{
	public GameObject missile;
    private Vector2 missilePosition;
    private Rigidbody2D rb;

    public override void Activate(GameObject parent)
    {
        rb = parent.GetComponent<Rigidbody2D>();
        StartCoroutine(CastCoroutine(parent));
    }

    private IEnumerator CastCoroutine(GameObject parent)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(activeTime);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        GameObject missile1 = Instantiate(missile, parent.transform.position, parent.transform.rotation);
    }
}
