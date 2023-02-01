using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinamaticPlayerController : MonoBehaviour {

    public GameObject sprite;

    private CharacterController _controller;
    //private SpriteRenderer _renderer;

    public float vMax = 8;
    public float vJump = 8;
    public float gAscend = 16;

    private Vector3 _vel;

    void Start() {
        _controller = GetComponent<CharacterController>();
    }

    void Update() {
        float x = Input.GetAxisRaw("Horizontal");
        _vel.x = x * vMax;

        if (_controller.isGrounded) {
            Debug.DrawLine(transform.position + new Vector3(-1, 1, 0), transform.position + new Vector3(1, 1, 0), Color.green, 0.0f, false);
            if (Input.GetButtonDown("Jump")) {
                _vel.y = vJump;
            }

        } else {
            _vel.y -= gAscend * Time.deltaTime;
        }

        _controller.Move(_vel * Time.deltaTime);

        if (_controller.isGrounded) {
            _vel.y = -0.1f;
        }

        //Debug.DrawLine(transform.position, transform.position + _vel, Color.white, 0.0f, false);
        //Debug.DrawLine(transform.position, transform.position + _controller.velocity, Color.red, 0.2f, false);

        // rotate the sprite to suit the motion
        if (_vel != Vector3.zero) {
            float angle = -90 + Vector2.SignedAngle(Vector3.right, _vel);
            //sprite.transform.rotation = Quaternion.Euler(0, 0, angle);

            // smooths the rotation
            sprite.transform.rotation = Quaternion.Lerp(sprite.transform.rotation, Quaternion.Euler(0, 0, angle), 0.1f);
        }
    }
}
