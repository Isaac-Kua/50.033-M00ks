using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =  "Icons", menuName =  "GameConstants/Icons")]
public class Icons : ScriptableObject
{
    public Sprite none;
    // Ranged ability
    public Sprite spike;
    public Sprite kaiten;
    public Sprite knockback;
    public Sprite arrow;
    // Active ability
    public Sprite goo;
    public Sprite magnet;
    public Sprite mine;
    public Sprite teleport;
    // Dash ability
    public Sprite phaseDash;
    public Sprite tripleDash;
    public Sprite spiderDash;
    public Sprite reverseDash;
    public Sprite defaultDash;
    // Melee ability
    public Sprite breaking;
    public Sprite zangief;
    public Sprite lunge;
    public Sprite repel;
    // Defensive
    public Sprite miniDef;
    public Sprite shellDef;
    public Sprite unstoppableDef;
    public Sprite toughDef;
    // On death
    public Sprite crawl;
    public Sprite kamikaze;
    public Sprite soulswap;
    public Sprite vengeance;
    // On kill
    public Sprite explosion;
    public Sprite zombie;
    public Sprite haste;
    public Sprite saiyan;
    // Movement
    public Sprite juggernaut;
    public Sprite wallwalker;
    public Sprite shiva;
    public Sprite ghost;
    // Utility
    public Sprite respawn;
    public Sprite meleeUtil;
    public Sprite rangedUtil;
    public Sprite altUtil;
    // Ranged upgrade
    public Sprite rangedBullet;
    public Sprite phaseBullet;
    public Sprite heavyBullet;
    public Sprite homingBullet;
}
