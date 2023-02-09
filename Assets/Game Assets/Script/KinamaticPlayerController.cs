using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinamaticPlayerController : MonoBehaviour {

    private enum PosState { ON_GROUND, IN_AIR };
    private enum GroundState { MOVE, DASH };
    private enum AirState { ASCEND, DESCEND, DASH };

    private PosState current_ps = PosState.ON_GROUND;
    private GroundState current_gs = GroundState.MOVE;
    private AirState current_as = AirState.ASCEND;

    private CharacterController _controller;
    private GameObject _sprite;

    public float vMax = 8;

    public float vDash = 32;
    public float tDash = 0.5f;

    public float vJump1 = 8;
    public float vJump2 = 4;
    public float hAscend1 = 2;
    public float hDescend = 1;
    public float fAir = 0.5f;

    private Vector3 _vel;
    private int facing = 1;
    private bool second_jump_avail = false;
    private bool air_dash_avail = false;

    private void Awake() {
        _controller = GetComponent<CharacterController>();
        _sprite = transform.Find("Sprite").gameObject;
    }

    void Update() {

        if (current_ps == PosState.ON_GROUND) {
            _vel.y = -0.1f;

            if (current_gs == GroundState.MOVE) {
                float x = Input.GetAxisRaw("Horizontal");
                _vel.x = x * vMax;

                if (x > 0) { facing = 1; } else if (x < 0) { facing = -1; }

                if (!IsGrounded()) {
                    StartJump(true);

                } else if (Input.GetButtonDown("Dash")) {
                    StartDash(tDash);

                } else if (Input.GetButtonDown("Jump")) {
                    StartJump();
                }

            } else if (current_gs == GroundState.DASH) {
                _vel.x = facing * vDash;

                if (Input.GetButtonDown("Jump")) {
                    CancelInvoke();
                    EndDash();
                    StartJump();
                }
            }

        } else if (current_ps == PosState.IN_AIR) {

            if (current_as == AirState.ASCEND) {
                float x = Input.GetAxisRaw("Horizontal");
                _vel.x += 60 * fAir * (x * vMax - _vel.x) * Time.deltaTime;
                _vel.x = Mathf.Clamp(_vel.x, -vMax, vMax);

                if (x > 0) { facing = 1; } else if (x < 0) { facing = -1; }
                _vel.y -= ((vJump1 * vJump1) / (2 * hAscend1)) * Time.deltaTime;

                if (_controller.velocity.y <= 0) { _vel.y = 0; }

                if (_vel.y <= 0 || !Input.GetButton("Jump")) { current_as = AirState.DESCEND; }

            } else if (current_as == AirState.DESCEND) {
                float x = Input.GetAxisRaw("Horizontal");
                _vel.x += 60 * fAir * (x * vMax - _vel.x) * Time.deltaTime;
                _vel.x = Mathf.Clamp(_vel.x, -vMax, vMax);

                if (x > 0) { facing = 1; } else if (x < 0) { facing = -1; }

                _vel.y -= ((vJump1 * vJump1) / (2 * hDescend)) * Time.deltaTime;

            } else if (current_as == AirState.DASH) {
                _vel.x = facing * vDash;
            }
            _vel.y = Mathf.Clamp(_vel.y, -vJump1, vJump1);

            if (second_jump_avail && Input.GetButtonDown("Jump")) {
                if (current_as == AirState.DASH) {
                    CancelInvoke();
                    EndAirDash();
                }

                StartSecondJump();

            } else if (air_dash_avail && Input.GetButtonDown("Dash")) {
                StartAirDash(tDash);
            }

            if (IsGrounded()) { EndJump(); }
        }

        _controller.Move(_vel * Time.deltaTime);
        Debug.DrawLine(transform.position, transform.position + _vel / 8, Color.white, 0.0f, false);

        RotateSprite();
    }

    private void StartDash(float dashTime) {
        current_gs = GroundState.DASH;
        Invoke("EndDash", dashTime);
    }

    private void EndDash() {
        current_gs = GroundState.MOVE;
    }

    private void StartJump(bool isFalling = false) {
        current_ps = PosState.IN_AIR;

        if (!isFalling) {
            current_as = AirState.ASCEND;
            _vel.y = vJump1;

        } else {
            current_as = AirState.DESCEND;
            _vel.y = 0;
        }

        second_jump_avail = true;
        air_dash_avail = true;
    }

    private void StartSecondJump() {
        second_jump_avail = false;
        current_as = AirState.ASCEND;
        _vel.y = vJump2;
    }

    private void EndJump() {
        current_ps = PosState.ON_GROUND;
    }

    private void StartAirDash(float dashTime) {
        air_dash_avail = false;
        current_as = AirState.DASH;
        Invoke("EndAirDash", dashTime);
    }

    private void EndAirDash() {
        current_as = AirState.DESCEND;
    }

    private bool IsGrounded() {
        return _controller.isGrounded;
    }

    private void RotateSprite() {
        if (_vel != Vector3.zero) {
            float angle = -90 + Vector2.SignedAngle(Vector3.right, _vel);
            _sprite.transform.rotation = Quaternion.Lerp(_sprite.transform.rotation, Quaternion.Euler(0, 0, angle), 0.05f);
        }
    }
}
