using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Analytics;

public class BackGroundScroller : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    public float offSet;
    private Material mat;

   void Start()
    {
        mat = GetComponent<Renderer>().material;   
    }



    void Update()
    {
        offSet += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offSet, 0));
    }
}
