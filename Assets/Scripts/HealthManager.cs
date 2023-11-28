using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public static int Health = 3;
    public Image[] hearts;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Update is called once per frame
    void Update()
    {
        foreach(Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for(int i= 0; i< Health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }
}
