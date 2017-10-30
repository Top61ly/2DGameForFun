using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShootTriggerable : Triggerable
{
    [HideInInspector]
    public Rigidbody2D projectile;
    public Transform bulletSpawn;   

    [HideInInspector]
    public float projectileForce = 250f;

    public void Launch()
    {
        Rigidbody2D cloneBullet = Instantiate(projectile, bulletSpawn.position, transform.rotation) as Rigidbody2D;

        if (playerNumber == 0)
            cloneBullet.AddForce(bulletSpawn.transform.right * projectileForce);
        else
            cloneBullet.AddForce(-bulletSpawn.transform.right * projectileForce);
    }
}
