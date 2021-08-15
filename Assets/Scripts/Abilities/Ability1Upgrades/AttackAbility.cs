using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArrowRangedAbility", menuName = "Ability 1/Arrow")]
public class AttackAbility : Ability
{
    public GameObject missile;
    public float missileSpeed;
    private Vector2 missilePosition;
    private Vector2 missileDirection;
    private float missileSpeed_copy;	
    private Quaternion angle = new Quaternion(0, 0, 0, 0);
    
    public bool RangeMod = false;
    public bool BypassMod = false;
    public bool SpeedMod = false;
    public bool HeavyMod = false;

    void checkModifications(Ability1Holder parent)
    {
        RangeMod = parent.RangeMod;
        BypassMod = parent.BypassMod;
        SpeedMod = parent.SpeedMod;
        HeavyMod = parent.HeavyMod;
    }

    public override void Activate(GameObject parent)
    {
        checkModifications(parent.GetComponent<Ability1Holder>());

        if(RangeMod){
            missileSpeed_copy = missileSpeed*2f;
        }else{
            missileSpeed_copy = missileSpeed;
        }


        missileDirection = parent.GetComponent<M00ks1Controller>().faceDirection;
        missilePosition = new Vector2(parent.transform.position.x, parent.transform.position.y) + missileDirection*3;
		Vector3 eulerAngle = new Vector3(0, 0, Vector2.SignedAngle(Vector2.right, missileDirection));
		angle.eulerAngles = eulerAngle;
        GameObject missile1 = Instantiate(missile, missilePosition, parent.transform.rotation);
        missile1.transform.rotation = angle;
        if(BypassMod){
            if(missile1!=null){
                missile1.layer  = LayerMask.NameToLayer("Danny");
            }
        }
        missile1.GetComponent<Rigidbody2D>().AddForce(missileDirection*missileSpeed_copy);
		missile1.GetComponent<ProjectileController>().owner = parent;
        missile1.GetComponent<ProjectileController>().HeavyMod = HeavyMod;
    }
}
