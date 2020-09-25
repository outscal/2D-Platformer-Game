using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Animator animator;
   private void Awake() {
      Debug.Log("Player Controller awake");
   }
   // private void OnCollisionEnter2D(Collision2D collision) {
   //    Debug.Log("Collision: " + collision.gameObject.name);
   // }

   private void Update() {
      float speed = Input.GetAxisRaw("Horizontal");
     
   }
  
}

