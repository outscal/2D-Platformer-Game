using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
	[SerializeField] private GameObject player;
	private Text text;
	private int collected;

    void Start()
    {
		text = GetComponent<Text>(); 
    }

    void Update()
    {
		collected = player.GetComponent<PlayerController>().collected;
		
		text.text = "Score: " + collected;        
    }
}
