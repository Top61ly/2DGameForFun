using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShootTriggerable : MonoBehaviour
{
    [HideInInspector]
    public int damage = 1;
    [HideInInspector]
    public float weaponRange = 50f;

    public Transform gunEnd;

    public int playerNumber;

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

    }

    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;

        yield return shotDuration;

        laserLine.enabled = false;
    }
}
