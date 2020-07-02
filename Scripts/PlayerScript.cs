using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
	private Animator anim;
	public float speed;
	private bool crouch;
	public bool Jump;
	public Button btn;
	private void Awake()
	{
		anim = GetComponent<Animator>();
		btn.onClick.AddListener(() => JumpButton());
	}

	private void JumpButton()
	{
		if (crouch == false)
		{
			crouch = true;
		}
	}

	private void Update()
	{ 
		anim.SetFloat("Speed", speed);
		anim.SetBool("Crouch", crouch);
		if (anim.GetBool("Crouch"))
		{
			anim.Play("Player_Crouch");
			crouch = false;
		}
		anim.SetBool("Jump", Jump);
		if (anim.GetBool("Jump"))
		{
			anim.Play("Player_Jump");
		}
	}
}
