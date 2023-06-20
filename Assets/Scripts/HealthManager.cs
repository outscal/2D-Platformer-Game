using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int Health=3;

    public Image[]  hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Image img in hearts)
        {
            img.sprite =EmptyHeart;
        }
        for(int i=0;i<Health;i++)
        {
            hearts[i].sprite = FullHeart;
        }
    }
}
