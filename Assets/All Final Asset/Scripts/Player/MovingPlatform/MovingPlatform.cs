using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
  [SerializeField] private float speed;
  [SerializeField] private GameObject[] waypoint;
  [SerializeField] private AudioSource platFormSound;

  private int currentIndex = 0;
   void Start()
   {
    platFormSound.Play();
   }
   void Update()
   {
    if(Vector2.Distance(waypoint[currentIndex].transform.position,transform.position)<0.1f)
    {
        currentIndex++;
        if(currentIndex >= waypoint.Length)
        {
            currentIndex = 0;
        }
    }
    transform.position = Vector2.MoveTowards(transform.position,waypoint[currentIndex].transform.position,speed * Time.deltaTime); 
   }

}
