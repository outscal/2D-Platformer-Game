using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnimation : MonoBehaviour
{
    public int rotateSpeedy;

    public Vector2 temp;
    float startY =0;
    float downY=0;
    public Color color = Color.white;
    void Start()
    {
        temp = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         rotateSpeedy += 2;
        if (rotateSpeedy >= 360)
        {
            rotateSpeedy = 0;
        }
           
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, rotateSpeedy, 0f ));

        
    }

    public void CollectAnim()
    {
        //color.a = 0f;
        startY= temp.y + 5f;
        float y = Mathf.SmoothStep(temp.y, startY,1);
        // Update the position of the object to the new Y position
        transform.position = new Vector3(transform.position.x,y, transform.position.z);
       
      
    }

    //   IEnumerator  AnimKeyUpDown()
    //{
    //    yield return new WaitForSeconds(0.2f);

    //    downY = startY - 1f;
    //    color.a = 0.8f;
    //    // Debug.Log("downY>>" + downY);
    //    transform.position = new Vector3(transform.position.x, downY, transform.position.z);
    //    Debug.Log("Down>>" + transform.position);
    //    startY = 0;
    //    downY = 0;
    //}
}
