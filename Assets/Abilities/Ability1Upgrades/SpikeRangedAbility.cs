using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName =  "SpikeRangedAbility", menuName =  "Ability 1/Spike")]
public class SpikeRangedAbility : Ability
{
    public GameObject missile;
    public int maxCount = 3;
    public float spacing = 2f;
    private int count;
    private Vector2 missilePosition;
    private Vector2 missileDirection;
    private Vector2[] spikePoints;
    private Vector2 node;
    //private Quaterion spikeRotation;

    public bool RangeMod = false;
    public bool BypassMod = false;
    public bool SpeedMod = false;
    public bool HeavyMod = false;
    public bool stop = false;

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
        if(RangeMod)
        {
            count = maxCount + 2;
        }else{
            count = maxCount;
        }
        spikePoints = new Vector2[count];
        if(SpeedMod)
        {
            activeTime = activeTime*0.5f;
        }
        for(int i=0;i<count; i++){
            spikePoints[i] = (missilePosition + missileDirection * spacing * i);
        }
        missileDirection = parent.GetComponent<M00ks1Controller>().faceDirection;
        missilePosition = new Vector2(parent.transform.position.x+1.5f, parent.transform.position.y+1.5f);
        StartCoroutine(ShootCoroutine(parent));
    }

    private IEnumerator ShootCoroutine(GameObject parent)
    {
        //count -= 1;
        //missilePosition = missilePosition + missileDirection * spacing;
        for(int j=0;j<count;j++){
            missilePosition = spikePoints[j];
            GameObject missile1 = Instantiate(missile, missilePosition, parent.transform.rotation);
            missile1.GetComponent<ProjectileController>().owner = parent;
            missile1.GetComponent<PlayerSpikeController>().RangeMod = RangeMod;
            missile1.GetComponent<PlayerSpikeController>().BypassMod = BypassMod;
            missile1.GetComponent<PlayerSpikeController>().SpeedMod = SpeedMod;
            missile1.GetComponent<PlayerSpikeController>().HeavyMod = HeavyMod;
            yield return new WaitForSeconds(activeTime);
        }

        



        // if(count > 0 & missile1 != null)
        // {
        //     missilePosition = missile1.transform.position;
        //     StartCoroutine(ShootCoroutine(parent));
        // }
        // else { count = maxCount; stop = false;}
    }
}
