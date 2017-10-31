using System;
using System.Collections;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public event EventHandler OnPlayerDestroyed;

    public float speed;

    Vector3 destPosition;
    SpriteRenderer sr;


    void Update()
    {
#if UNITY_IPHONE
        
        if (Input.touchCount>0)
        {
            destPosition = Input.GetTouch(0).position;
#endif

#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            destPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
#endif 
            Vector2 direction =  (destPosition - transform.position).normalized;

            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}

