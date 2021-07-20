using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RepelMeleeAbility : Ability
{
    public GameObject missile;
    public float missileSpeed;
    private Vector2 missilePosition;
    private Vector2 missileDirection;
    public override void Activate(GameObject parent)
    {
        missileDirection = parent.GetComponent<M00ks1Controller>().faceDirection;
        missilePosition = new Vector2(parent.transform.position.x, parent.transform.position.y) + missileDirection*3;
        GameObject missile1 = Instantiate(missile, missilePosition, parent.transform.rotation);
        missile1.GetComponent<Rigidbody2D>().AddRelativeForce(missileDirection*missileSpeed);
		missile1.GetComponent<NormalFistController>().player = parent;
		missile1.GetComponent<ProjectileController>().owner = parent;
    }
}
