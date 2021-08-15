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
    private RaycastHit2D hitDebris;
    private float debrisDistance = 9999f;
    //private Quaterion spikeRotation;

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
        if(!BypassMod){
            hitDebris = Physics2D.Raycast(missilePosition,missileDirection);
        }
        if(hitDebris != null && hitDebris.collider != null && hitDebris.collider.tag == "Debris")
        {
            var x_val = hitDebris.point.x - missilePosition.x;
            var y_val = hitDebris.point.y - missilePosition.y;
            debrisDistance =   x_val*x_val + y_val*y_val;
        }else{
            debrisDistance = 9999f;
        }
        var spacing = gameConstants.spikeSpacing;

        for(int i=0;i<count; i++){
            var mag = 1f + (i+1)*spacing;
            mag = mag*mag;
            if(i == 0){
                if(mag>debrisDistance){
                    spikePoints[i] = (missilePosition + missileDirection*debrisDistance);
                }else{
                    spikePoints[i] = (missilePosition + missileDirection*2f + missileDirection*(i+1)*spacing);
                }
                
            }
            else
            {
                if(mag>debrisDistance){
                    blocked = true;
                }
                if(blocked && !BypassMod)
                {
                    spikePoints[i] = (missilePosition + missileDirection*2f + missileDirection*(200)*spacing);
                }
                else
                {
                    spikePoints[i] = (missilePosition + missileDirection*2f + missileDirection*(i+1)*spacing);
                }
            }
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
            GameObject missile1 = Instantiate(gameConstants.playerSpike, missilePosition, Quaternion.identity);//, parent.transform.rotation);
            missile1.GetComponent<ProjectileController>().owner = parent;
            missile1.GetComponent<PlayerSpikeController>().owner = parent;
            missile1.GetComponent<PlayerSpikeController>().RangeMod = RangeMod;
            missile1.GetComponent<PlayerSpikeController>().BypassMod = BypassMod;
            missile1.GetComponent<PlayerSpikeController>().SpeedMod = SpeedMod;
            missile1.GetComponent<PlayerSpikeController>().HeavyMod = HeavyMod;
            missile1.GetComponent<ProjectileController>().HeavyMod = HeavyMod;
            yield return new WaitForSeconds(spikeSpawnTime);
            
        }
        yield break;

    }
}
