using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName =  "KaitenRangedAbility", menuName =  "Ability 1/Kaiten", order =  1)]
public class KaitenRangedAbility : Ability
{
    private Vector2 missilePosition;
    private Rigidbody2D rb;

    public override void Activate(GameObject parent)
    {
        rb = parent.GetComponent<Rigidbody2D>();
        missilePosition = parent.transform.position;
        Instantiate(gameConstants.kaitenPrefab, missilePosition, parent.transform.rotation);
        StartCoroutine(ShootCoroutine(parent));
    }

    private IEnumerator ShootCoroutine(GameObject parent)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(activeTime);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

    }
}
