using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class KaitenRangedAbility : Ability
{
    public GameObject missile;
    public float growthRate;
    public float lingerDuration;
    private Vector2 missilePosition;
    private Rigidbody2D rb;

    public override void Activate(GameObject parent)
    {
        rb = parent.GetComponent<Rigidbody2D>();
        missilePosition = parent.transform.position;
        GameObject missile1 = Instantiate(missile, missilePosition, parent.transform.rotation);
        StartCoroutine(ShootCoroutine(parent));
        StartCoroutine(GrowCoroutine(missile1));
    }

    private IEnumerator ShootCoroutine(GameObject parent)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(activeTime);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    private IEnumerator GrowCoroutine(GameObject kaiten)
    {
        var endOfFrame = new WaitForEndOfFrame();
        //Debug.Log("dashing");
        for (float timer = 0; timer < activeTime - lingerDuration; timer += Time.deltaTime)
        {
            float size = growthRate * Time.deltaTime;

            kaiten.transform.localScale *= growthRate;
            yield return endOfFrame;
        }
        yield return new WaitForSeconds(lingerDuration);
        Destroy(kaiten);
    }
}
