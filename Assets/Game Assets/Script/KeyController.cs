using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {

    public GameObject scoreManager;

    private void OnTriggerEnter2D(Collider2D collision) {
        scoreManager.GetComponent<ScoreManager>().AddScore(1);
        Destroy(gameObject);
    }
}
