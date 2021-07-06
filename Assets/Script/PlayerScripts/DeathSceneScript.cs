using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Elle2D
{

    //when player touches death platform this fun will works
    public class DeathSceneScript : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collison)
        {
            if (collison.gameObject.GetComponent<PlayerController>() != null)
            {
                PlayerController playerController = collison.gameObject.GetComponent<PlayerController>();
                playerController.KillPlayer();
            }
        }
    }
}


