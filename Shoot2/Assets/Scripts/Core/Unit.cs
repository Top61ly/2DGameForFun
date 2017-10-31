using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitState
{
    Waiting,
    Alive,
    Dead
}

public class Unit: MonoBehaviour
{
    public int playerNumber;

    public UnitState unitState = UnitState.Waiting;

    public int health = 1;

    private UnitShoot unitShoot;


    private void Start()
    {
        unitShoot = GetComponent<UnitShoot>();
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Dead();
    }    

    protected virtual void Dead()
    {
        Debug.Log(gameObject.name + " Dead");
        Destroy(gameObject);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Unit") && unitState == UnitState.Alive)
        {
            Unit unit = collision.transform.GetComponent<Unit>();
            if (unit.playerNumber == playerNumber)
                Combine(unit.transform);
            else
                TakeDamage(1);
        }
    }

    protected virtual void Combine(Transform obj)
    {
        obj.parent = transform.parent;
    }


}
