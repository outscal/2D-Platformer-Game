using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
	public GameObject player;
	private Text text;
	private int collected;

    // Start is called before the first frame update
    void Start()
    {
		text = GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
		collected = player.GetComponent<PlayerController>().collected;
		
		text.text = "Score: " + collected;        
    }
}
