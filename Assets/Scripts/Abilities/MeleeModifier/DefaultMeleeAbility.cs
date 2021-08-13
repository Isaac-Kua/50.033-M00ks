using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultMeleeAbility", menuName = "Melee/Default")]
public class DefaultMeleeAbility : Ability
{
    public GameObject missile;
    public float missileSpeed;
    private Vector2 missilePosition;
    private Vector2 missileDirection;
    public override void Activate(GameObject parent)
    {
        missileDirection = parent.GetComponent<M00ks1Controller>().faceDirection;
        missilePosition = new Vector2(parent.transform.position.x, parent.transform.position.y) + missileDirection * 2;
        GameObject missile1 = Instantiate(missile, missilePosition, parent.transform.rotation);

        missile1.GetComponent<Rigidbody2D>().AddRelativeForce(missileDirection * missileSpeed);
        missile1.GetComponent<NormalFistController>().player = parent;
        missile1.GetComponent<ProjectileController>().owner = parent;
        //StartCoroutine(PunchCoroutine(parent));
    }

    //private IEnumerator PunchCoroutine(GameObject parent)
    //{
    //    var endOfFrame = new WaitForEndOfFrame();
    //    for (float timer = 0; timer < activeTime; timer += Time.deltaTime)
    //    {
    //        Rigidbody2D rb = parent.GetComponent<Rigidbody2D>();
    //        rb.MovePosition(rb.position + (missileDirection * (missileSpeed / 50 * Time.deltaTime)));
    //        yield return endOfFrame;
    //    }
    //}
}
