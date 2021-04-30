using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteController : MonoBehaviour
{
    public GameObject newLevelComplete;
    [SerializeField] private ParticleSystem m_confetti;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.gameObject.CompareTag("Player")) 
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {        
            Debug.Log("Level Finished by Player");
            LevelManager.Instance.MarkCurrentLevelComplete();
            SoundManager.Instance.Play(Sounds.LevelComplete);
            newLevelComplete.SetActive(true);
            m_confetti.Play();
        }
    }
}
