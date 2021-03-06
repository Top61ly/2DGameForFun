﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Bullets/RaycastBullet")]
public class RaycastBullet : Bullet
{
    public int damage = 1;
    public float weaponRange = 50f;
    public float startWidth = 0.02f;
    public float endWidth = 0.02f;
    //the Ray mat
    public Material material;

    private RaycastShootTriggerable rcShoot;

    public override void Initialize(GameObject obj)
    {
        rcShoot = obj.GetComponent<RaycastShootTriggerable>();
        rcShoot.Initialize();        
        rcShoot.damage = damage;
        rcShoot.weaponRange = weaponRange;
        rcShoot.laserLine.material = material;
        rcShoot.laserLine.startWidth = startWidth;
        rcShoot.laserLine.endWidth = endWidth;
    }

    public override void Shoot()
    {
        rcShoot.Fire();
    }
}
