using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bullets/ProjectileBullet")]
public class ProjectileBullet : Bullet
{
    public float projectileForce = 500f;
    public Rigidbody2D projectile;

    private ProjectileShootTriggerable launcher;

    public override void Initialize(GameObject obj)
    {
        launcher = obj.GetComponent<ProjectileShootTriggerable>();

        launcher.projectile = projectile;
        launcher.projectileForce = projectileForce;
    }

    public override void Shoot()
    {
        launcher.Launch();
    }
}
