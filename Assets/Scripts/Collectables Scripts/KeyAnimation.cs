using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnimation : MonoBehaviour
{
    private int rotateSpeedy;

    private Vector2 start;
    private Vector2 end;

    // float downY=0;
    private Color colorSimple ;
    bool flag;


    private float timeSmmoth;

    private Vector3 temp ;
    private float fadePerSecond = 2.5f;


    // Fade Efefct Parameters ..........

    private float fadeTime = 2f; // duration of fade-out effect in seconds
    private SpriteRenderer objRenderer; // renderer component of the game object
    private Color objColor;

    private Material mat;
    void Start()
    {
        objRenderer = GetComponent<SpriteRenderer>();
        mat = objRenderer.material;
        objColor = mat.color;

        
        temp = transform.position;
                start = this.transform.position;
        end = new Vector3(transform.position.x, 0f, transform.position.z);
    }

    public void  SetFlag(bool _flag)
    {
        flag = _flag;
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

        if (flag == true)
        {
            CollectAnim();
            ColorFade();

        }
    }


    public void ColorFade()
    {
        float alpha = Mathf.Lerp(1f, 0f, Time.time / fadeTime);

       // Color newColor = new Color(objColor.r, objColor.g, objColor.b, alpha);
        Color newColor=  new Color(244/255f, 196/255f,48/255f, alpha);
     objRenderer.material.color = newColor;
       
        //mat.color = Color.red;
        // mat.color = new Color(0 / 255f, 0 / 255f, 255 / 255f, 1);
        if (alpha <= 0f) // check if the game object has faded out completely
        {
            gameObject.SetActive(false); // disable the game object to make it invisible and stop further updates
        }

    }
    public void CollectAnim()
    {
        transform.position =  Vector3.Lerp(start, end, Time.deltaTime);

    }

   

}
