using UnityEngine;

/// <summary>
/// This script is used for the implementation of Level Complete, Next Level starts
/// </summary>

public class LevelCompleteController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("LevelComplete!! Unlocked Next Level!!");
        }
    }
}
