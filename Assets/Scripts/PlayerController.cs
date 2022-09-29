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
    bool isCrouching;
    // Start is called before the first frame update
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Jump");
        Debug.Log("Jump : " + _verticalInput);
        _animator.SetFloat("Speed", Mathf.Abs(_horizontalInput));
        //Debug.Log("Vertical Input :" + _verticalInput);

        PlayerLookAt(_horizontalInput);
        if (_verticalInput > 0 && !isCrouching)
        {
           // Debug.Log("Jump Again");
            _animator.SetBool("isJumping", true);
        }
        else
        {
            _animator.SetBool("isJumping", false);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            isCrouching = true;
            CrouchAnimationm(isCrouching);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            isCrouching = false;
            CrouchAnimationm(isCrouching);
        }

    }
    void CrouchAnimationm(bool _isCrouching)
    {
        _animator.SetBool("isCrouching", isCrouching);
        standingCollider.enabled = !isCrouching;
        crouchingCollider.enabled = isCrouching;
    }
    void PlayerLookAt(float _horizontalInput)
    {
        scale = transform.localScale;
        if (_horizontalInput < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (_horizontalInput > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
}
