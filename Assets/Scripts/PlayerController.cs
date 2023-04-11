using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public Vector2 crouchedColliderScale = new Vector2(0.9171886f, 1.328003f);
    public Vector2 crouchedColliderOffset = new Vector2(-0.11f, 0.59f);
    private BoxCollider2D _collider;
    private Vector2 _standingColliderScale, _standingColliderOffset;
    private bool _isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _standingColliderScale = _collider.size;
        _standingColliderOffset = _collider.offset;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool crouch = Input.GetKey(KeyCode.LeftControl);

        if(crouch)
        {
            _collider.size = crouchedColliderScale;
            _collider.offset = crouchedColliderOffset;
        }
        else
        {
            _collider.size = _standingColliderScale;
            _collider.offset = _standingColliderOffset;
        }

        animator.SetBool("Crouch", crouch);

        animator.SetFloat("Speed", Mathf.Abs(speed));
        animator.SetFloat("Vertical", Mathf.Abs(vertical));

        Vector3 scale = transform.localScale;

        if (speed < 0){
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if(speed > 0){
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if (vertical > 0 && !_isJumping)
        {
            Debug.Log(vertical);
            animator.SetTrigger("Jump");
            _isJumping = true;
        }

        if(_isJumping)
            _isJumping = !animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Jump");
    }
}
