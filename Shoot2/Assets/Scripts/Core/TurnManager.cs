using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TurnManager : MonoBehaviour
{
    public Boundary boundary;
    public GameObject bullet;
    public Transform bulletParent;
    public int startNumber;

    public float timeGap;
    public float timeGapCloud;

    private float time;
    
    private void Start()
    {
        time = 0;
    }

    public void StartTurn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("1");
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time>timeGap)
        {
            time = 0;
            GenerateBullets(startNumber,bullet);
        }
    }
  
    void GenerateBullets(int totalNumbers,GameObject go)
    {
        for (int i = 0; i < totalNumbers; i++)
        {
            float x = UnityEngine.Random.Range(boundary.minX, boundary.maxX);
            float y = UnityEngine.Random.Range(boundary.minY, boundary.maxY);
            float k = y / x;
            float fX, fY;
            if (Mathf.Abs(k) < 0.57)
            {
                fX = x > 0 ? boundary.maxX : boundary.minX;
                fY = fX * k;
               
            }
            else
            {
               fY = y > 0 ? boundary.maxY : boundary.minY;
               fX = fY / k;               
            }
            Instantiate(go, new Vector3(fX, fY, 0), Quaternion.identity, bulletParent);
         
        }
    }

    void SetColor(GameObject go)
    {
        int i = UnityEngine.Random.Range(0, 2);
        go.GetComponent<SpriteRenderer>().color = GetColor(i);
    }

    Color GetColor(int i)
    {
        switch (i)
        {
            case 0:
                return Color.red;
           
            case 1:
                return Color.black;
          
            default:
                return Color.blue;
        }         
    }
    float RandomFloat(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }
}

[System.Serializable]
public class Boundary
{
    public float minX, maxX, minY, maxY;
}
