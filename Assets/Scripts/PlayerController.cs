using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator _animator;
    [SerializeField]
    BoxCollider2D standingCollider;
    [SerializeField]
    BoxCollider2D crouchingCollider;

    private float _horizontalInput;
    private float _verticalInput;

    Vector3 scale;
    // Start is called before the first frame update
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        _animator.SetFloat("Speed", Mathf.Abs(_horizontalInput));
        _animator.SetFloat("JumpSpeed", _verticalInput);
        scale = transform.localScale;
        if(_horizontalInput < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if(_horizontalInput > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
        if (Input.GetButtonDown("Crouch"))
        {
            _animator.SetBool("isCrouching", true);
            standingCollider.enabled = false;
            crouchingCollider.enabled = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            _animator.SetBool("isCrouching", false);
            standingCollider.enabled = true;
            crouchingCollider.enabled = false;
        }

    }
}
