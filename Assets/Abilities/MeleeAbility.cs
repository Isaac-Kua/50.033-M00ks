using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class MeleeAbility : Ability
{
    // Start is called before the first frame update
    public GameObject Melee;
    private Vector2 meleePosition;
    private Vector2 meleeDirection;
    private Coroutine melee = null;

    public override void Activate(GameObject parent)
    {
        meleeDirection = parent.GetComponent<M00ks1Controller>().faceDirection;
        meleePosition = new Vector2(parent.transform.position.x, parent.transform.position.y) + meleeDirection*3;
        GameObject Melee1 = Instantiate(Melee, meleePosition, parent.transform.rotation);
        StartCoroutine(MeleeCoroutine(Melee1));
    }

    private IEnumerator MeleeCoroutine(GameObject Melee1)
    {
        var endOfFrame = new WaitForEndOfFrame();
        Debug.Log("dashing");
        for(float timer = 0; timer < activeTime; timer += Time.deltaTime)
        {
            yield return endOfFrame;
        }
        Destroy(Melee1);
        melee = null;
    }
}
