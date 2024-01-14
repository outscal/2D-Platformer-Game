using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private RectTransform[] Hearts= new RectTransform[3];
    [SerializeField] public int health;   
    // Start is called before the first frame update
    void Start()
    {
        foreach(RectTransform tr in Hearts)
        {
            tr.gameObject.SetActive(true);
        }
        health = 3;
    }

    public void LooseHealth()
    {
        Hearts[health-1].gameObject.SetActive(false);
        health -= 1;
    }
}
