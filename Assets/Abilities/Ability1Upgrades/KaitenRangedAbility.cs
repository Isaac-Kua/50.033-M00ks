using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName =  "KaitenRangedAbility", menuName =  "Ability 1/Kaiten")]
public class KaitenRangedAbility : Ability
{
    private Vector2 missilePosition;
    private Rigidbody2D rb;

    public bool RangeMod;
    public bool BypassMod;
    public bool SpeedMod;
    public bool HeavyMod;

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
        rb = parent.GetComponent<Rigidbody2D>();
        missilePosition = parent.transform.position;
        GameObject kaiten = Instantiate(gameConstants.kaitenPrefab, missilePosition, parent.transform.rotation);
		kaiten.GetComponent<ProjectileController>().owner = parent;
        kaiten.GetComponent<KaitenController>().RangeMod = RangeMod;
        kaiten.GetComponent<KaitenController>().BypassMod = BypassMod;
        kaiten.GetComponent<KaitenController>().SpeedMod = SpeedMod;
        kaiten.GetComponent<KaitenController>().HeavyMod = HeavyMod;

        StartCoroutine(ShootCoroutine(parent));
    }

    private IEnumerator ShootCoroutine(GameObject parent)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(activeTime);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

    }
}
