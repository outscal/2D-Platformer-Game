using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    [SerializeField]
    private Animator anim;
    private SpriteRenderer _playerSprite;
    // Start is called before the first frame update
    void Start()
    {
        _playerSprite = GetComponent<SpriteRenderer>();

        if(_playerSprite == null)
        {
            Debug.Log("Player sprite not available");
        }
    }

    // Update is called once per frame
    void Update()
    {

        MovementAnimation();
    }

    void MovementAnimation()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("speed", Mathf.Abs(horizontalInput));

        
        if(horizontalInput < 0)
        {
            _playerSprite.flipX = true;
        }
        else
        {
            _playerSprite.flipX = false;
        }

    }
}
