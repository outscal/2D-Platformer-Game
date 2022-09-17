using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CollisionEnums>(out CollisionEnums collisionEnum))
        {
            if(collisionEnum.colliderTag == ColliderTags.PLAYER)
            {
                SceneLoader.LoadNextScene();
            }
        }
    }
}
