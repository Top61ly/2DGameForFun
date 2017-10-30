using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitState
{
    Waiting,
    Alive,
    Dead
}

public abstract class Unit: MonoBehaviour
{
    public int playerNumber;

    public UnitState unitState = UnitState.Waiting;

    public int health = 2;

    public virtual void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Dead();
    }

    protected virtual void Shoot()
    {

    }

    protected virtual void Dead()
    {
        Debug.Log(gameObject.name + " Dead");
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Unit"))
        {
            Unit unit = collision.GetComponent<Unit>();
            unit.TakeDamage(2);
        }        
    }
}
