using UnityEditorInternal;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Player Controllor Awake");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collison : " + collision.gameObject.name);
    }
}