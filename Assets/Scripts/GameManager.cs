using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private static GameManager instance;
    private int score = 0;
    public bool isGamePaused = false;

    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        SoundManager.Instance.Play(Sounds.BackgroundMusic);
       
    }
    // Start is called before the first frame update
    public int getPlayerScore()
    {
        return score;
    }
    public void setPlayerScore(int _increment)
    {
        score += _increment;
    }
    public void resetPlayerScore()
    {
        score = 0;
    }
}
