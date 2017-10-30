using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShootTriggerable : Triggerable
{
    [HideInInspector]
    public int damage = 1;
    [HideInInspector]
    public float weaponRange = 50f;

    public Transform gunEnd;    

    [HideInInspector]
    public LineRenderer laserLine;

    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);

    public void Initialize()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    public void Fire()
    {
        StartCoroutine(ShotEffect());

        laserLine.SetPosition(0, gunEnd.position);

        Vector3 destPosition = new Vector3();

        if (playerNumber == 0)
            destPosition = gunEnd.position + new Vector3(weaponRange, 0, 0);
        else
            destPosition = gunEnd.position + new Vector3(-weaponRange, 0, 0);

        laserLine.SetPosition(1,destPosition);

    }

    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;

        yield return shotDuration;

        laserLine.enabled = false;
    }
}
