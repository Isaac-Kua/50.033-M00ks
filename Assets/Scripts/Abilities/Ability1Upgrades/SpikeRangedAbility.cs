using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName =  "SpikeRangedAbility", menuName =  "Ability 1/Spike")]
public class SpikeRangedAbility : Ability
{
    private int count;
    private Vector2 missilePosition;
    private Vector2 missileDirection;
    private Vector2[] spikePoints;
    private Vector2 node;
    private bool blocked = false;
    private float spikeSpawnTime = 0.3f;

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
        blocked = false;
        checkModifications(parent.GetComponent<Ability1Holder>());
        if(RangeMod)
        {
            count = gameConstants.spikeMaxCount + 2;
        }else{
            count = gameConstants.spikeMaxCount;
        }
        spikePoints = new Vector2[count];
        if(SpeedMod)
        {
            spikeSpawnTime = spikeSpawnTime*0.5f;
        }

        missileDirection = parent.GetComponent<M00ks1Controller>().faceDirection;
        missilePosition = new Vector2(parent.transform.position.x, parent.transform.position.y);
        for(int i=0;i<count; i++){
            spikePoints[i] = (missilePosition + missileDirection*2f + missileDirection*(i+1)*gameConstants.spikeSpacing);
        }
        StartCoroutine(ShootCoroutine(parent));
    }

    private IEnumerator ShootCoroutine(GameObject parent)
    {
        //count -= 1;
        //missilePosition = missilePosition + missileDirection * spacing;
        Debug.Log("Shooting");
        for(int j=0;j<count;j++)
        {
            missilePosition = spikePoints[j];
            if(blocked)
            {
                if(!BypassMod){
                    yield break;
                }else{
                    blocked = false;
                }
            }
            else
            {
                GameObject missile1 = Instantiate(gameConstants.playerSpike, missilePosition, Quaternion.identity);//, parent.transform.rotation);
                missile1.GetComponent<ProjectileController>().owner = parent;
                missile1.GetComponent<PlayerSpikeController>().owner = parent;
                missile1.GetComponent<PlayerSpikeController>().RangeMod = RangeMod;
                missile1.GetComponent<PlayerSpikeController>().BypassMod = BypassMod;
                missile1.GetComponent<PlayerSpikeController>().SpeedMod = SpeedMod;
                missile1.GetComponent<PlayerSpikeController>().HeavyMod = HeavyMod;
                missile1.GetComponent<ProjectileController>().HeavyMod = HeavyMod;
                yield return new WaitForSeconds(spikeSpawnTime);
                if(missile1 == null){
                    blocked = true;
                }else{
                    blocked = missile1.GetComponent<PlayerSpikeController>().blocked;

                }
            }
        }
        yield break;

    }
}
