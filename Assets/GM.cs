using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
	public static int Score;
	public static int Lives;
	// TODO: go nuts if you want to add more stuff like health and wave and coins, etc.!

	public static void InitGame()
	{
		Score = 0;
		Lives = 4;
	}

	public static void AddScore(int points)
	{
		Score += points;
	}
}
