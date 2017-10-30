using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : ScriptableObject
{
    public string name = "New Bullet";

    public AudioClip sound;

    public float baseCoolDown = 1.0f;

    public abstract void Initialize(GameObject obj);
    public abstract void Shoot();
}
