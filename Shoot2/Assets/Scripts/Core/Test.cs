using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private Bullet bullet;
    [SerializeField]
    public GameObject weaponHolder;

    private void Start()
    {
        Initialize(bullet, weaponHolder);
    }

    public void Initialize(Bullet selectedBullet,GameObject weaponHolder)
    {
        bullet = selectedBullet;
        bullet.Initialize(weaponHolder);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            bullet.Shoot();
    }
}
