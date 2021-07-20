using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GooAlternateAbility : Ability
{
    public GameObject missile;
    public float growthRate;
    public float lingerDuration;
    private Rigidbody2D rb;

    public override void Activate(GameObject parent)
    {
        rb = parent.GetComponent<Rigidbody2D>();
        GameObject missile1 = Instantiate(missile, parent.transform.position, parent.transform.rotation);
        StartCoroutine(GrowCoroutine(missile1));
    }

    private IEnumerator GrowCoroutine(GameObject gooPool)
    {
        var endOfFrame = new WaitForEndOfFrame();
        for (float timer = 0; timer < activeTime - lingerDuration; timer += Time.deltaTime)
        {
            float size = growthRate * Time.deltaTime;

            gooPool.transform.localScale *= growthRate;
            yield return endOfFrame;
        }
        yield return new WaitForSeconds(lingerDuration);
    }
}
