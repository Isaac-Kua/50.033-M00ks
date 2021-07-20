using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class SpikeRangedAbility : Ability
{
    public GameObject missile;
    public int maxCount = 3;
    public float spacing = 2f;
    private int count;
    private Vector2 missilePosition;
    private Vector2 missileDirection;
    public override void Activate(GameObject parent)
    {
        count = maxCount;
        missileDirection = parent.GetComponent<M00ks1Controller>().faceDirection;
        missilePosition = new Vector2(parent.transform.position.x, parent.transform.position.y);
        StartCoroutine(ShootCoroutine(parent));
    }

    private IEnumerator ShootCoroutine(GameObject parent)
    {
        count -= 1;
        yield return new WaitForSeconds(activeTime);
        missilePosition = missilePosition + missileDirection * spacing;
        GameObject missile1 = Instantiate(missile, missilePosition, parent.transform.rotation);
		missile1.GetComponent<ProjectileController>().owner = parent;

        if (count > 0)
        {
            missilePosition = missile1.transform.position;
            StartCoroutine(ShootCoroutine(parent));
        }

        else { count = maxCount; }
    }
}
