using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private static GameManager instance;
    private int score = 0;

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
