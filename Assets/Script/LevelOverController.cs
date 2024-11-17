using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOverController : MonoBehaviour
{
    public GameObject levelComplete;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            AudioManager.Instance.Play(SoundType.GameComplete);
            levelComplete.SetActive(true);
            LevelManager.Instance.MarkedLevelComplete();
        }
    }
}
