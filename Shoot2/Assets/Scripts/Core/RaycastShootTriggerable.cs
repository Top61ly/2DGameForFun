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

    private void Update()
    {
        laserLine.SetPosition(0, gunEnd.position);

        Vector3 destPosition = GetPosition();

        //if (playerNumber == 0)
        //    destPosition = gunEnd.position + new Vector3(weaponRange, 0, 0);
        //else
        //    destPosition = gunEnd.position + new Vector3(-weaponRange, 0, 0);

        laserLine.SetPosition(1,destPosition);
    }

    public void Fire()
    {
        StartCoroutine(ShotEffect());
    }

    private Vector3 GetPosition()
    {
        Vector3 vec = new Vector3();
        if (playerNumber == 0)
            vec = Vector3.right;
        else
            vec = -Vector3.right;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, vec,weaponRange);

        Debug.Log(hit.transform.tag);
        Debug.Log(hit.transform.GetComponent<Unit>().playerNumber);
        if (hit.collider != null && hit.collider.CompareTag("Unit")&&hit.transform.GetComponent<Unit>().playerNumber != playerNumber)
            return hit.point;
        else if (playerNumber == 0)        
            return gunEnd.position + new Vector3(weaponRange, 0, 0);

        return gunEnd.position - new Vector3(weaponRange, 0, 0);
    }

    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;

        yield return shotDuration;

        laserLine.enabled = false;
    }
}
