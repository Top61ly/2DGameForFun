using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitShoot : MonoBehaviour
{
    [SerializeField]
    private Bullet bullet;
    [SerializeField]
    public GameObject weaponHolder;

    private float time;
    private float coolDownTime;

    private void OnEnable()
    {
        Debug.Log("Shoot Start");
        Initialize(bullet, weaponHolder);
    }

    public void Initialize(Bullet selectedBullet,GameObject weaponHolder)
    {
        time = 0;
        coolDownTime = selectedBullet.baseCoolDown;
        bullet = selectedBullet;
        bullet.Initialize(weaponHolder);
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time>coolDownTime)
        {
            bullet.Shoot();
            time = 0;
        }
    }
}
