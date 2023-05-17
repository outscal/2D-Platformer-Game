using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

public class Key_controller : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player_controller>() != null)
        {
            Increase_score score_text = GameObject.Find("Score_text").GetComponent<Increase_score>();
            score_text.update_score();
            Destroy(this.gameObject);
        }
    }
}

