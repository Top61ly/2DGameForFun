using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleUnit : Unit
{
    public GameObject bullet;
    public Transform bulletIns;

    public float timeGap;
    private float time;

    private void Update()
    {
        time += Time.deltaTime;
        if (time > timeGap)
            Shoot();
    }

    protected override void Shoot()
    {
        Instantiate(bullet, bulletIns.position, Quaternion.identity);
        time = 0;
    }     
}
