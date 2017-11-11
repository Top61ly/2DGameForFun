using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetScroller : MonoBehaviour {

    public float scrollSpeed;

    private Material meshMaterial;
	// Use this for initialization
	void Start ()
    {
        meshMaterial = GetComponent<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float y = Mathf.Repeat(Time.time * scrollSpeed, 1);

        Vector2 offset = new Vector2(0, y);

        meshMaterial.SetTextureOffset("_MainTex", offset);
	}
}
