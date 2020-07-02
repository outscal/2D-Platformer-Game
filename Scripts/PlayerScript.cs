using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	private Animator anim;
	public float speed;
	private void Awake()
	{
		anim = GetComponent<Animator>();
	}
	private void Update()
	{ 
		anim.SetFloat("Speed", speed);
	}
}
