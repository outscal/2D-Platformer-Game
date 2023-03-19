using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnimation : MonoBehaviour
{
    public int rotateSpeedy;

    public Vector2 start;
    public Vector2 end;
    
   // float downY=0;
    public Color colorSimple ;
    bool flag;

   
    public float timeSmmoth;
  
    private Vector3 temp ;
    private float fadePerSecond = 2.5f;
   

    // Fade Efefct Parameters ..........

    public float fadeTime = 2f; // duration of fade-out effect in seconds
    private SpriteRenderer objRenderer; // renderer component of the game object
    private Color objColor;
  
    public Material mat;
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
           // Debug.Log("Isndie Flaf");
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

     

        transform.position =  Vector3.Lerp(start, end, Time.time);
    


    }

    //   Doubt>>1
    // when we are moving and object from one point to another using Vector3.Lerp,
    // How we can  get ease in and ease out effect ?
    //   Doubt>>2
    // why always time.time is best fit  as Float t parameter in lerp Or SmoothStep etc.  Why other values Don't work here becuase when i am Using Time.time then
    // object is reachind to the edn point exactly But other time values( the variables for time i am defining myself)  not working as expected becuase with those values either  Object don't reach to the destination , 
    // and  stops in middle of Start Point and the end point  or go beyong the end point.
    // But usimng time.time object always reaches to the end point with exact value ?

}
