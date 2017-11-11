using System;
using System.Collections;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public event EventHandler OnPlayerDestroyed;

    public float speed;

    public float timGap;

    private float startTime;

    public GameObject bulletRb;

    Vector3 destPosition;
    SpriteRenderer sr;


    private void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {

        startTime += Time.deltaTime;
        if (startTime > timGap)
        {
            GameObject go = Instantiate(bulletRb, transform.position, Quaternion.identity) as GameObject;
            go.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 500);
            startTime = 0;
        }

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

