using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator m_Animator;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private GameObject m_Player;
    private Rigidbody2D m_Rigidbody2D;
    private Collider2D m_Collider;
    [SerializeField]
    private LayerMask jumpableLayers;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = m_Player.GetComponent<Animator>();
        m_Rigidbody2D = m_Player.GetComponent<Rigidbody2D>();
        m_Collider = m_Player.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlHorizontalMovement();
        Crouch();
        ControlJump();
    }

    private void ControlJump()
    {
        if (m_Animator != null && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded())
        {
            TranslateCharacterVertical();
            m_Animator.SetTrigger("Jump");
        }
    }

    private void ControlHorizontalMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (m_Animator != null)
        {
            if (horizontal == 0) { return; }
            m_Animator.SetFloat("Speed", Mathf.Abs(horizontal));
            float scaleX = m_Player.transform.localScale.x;
            if (horizontal < 0)
            {
                scaleX = -1 * Mathf.Abs(scaleX);
            }
            else
            {
                scaleX = Mathf.Abs(scaleX);
            }
            m_Player.transform.localScale = new Vector3(scaleX, m_Player.transform.localScale.y, m_Player.transform.localScale.z);
            TranslateCharacterHorizontal(horizontal);
        }
    }

    private void Crouch()
    {
        if (m_Animator != null)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
            {
                m_Animator.SetBool("IsCrouch", true);
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
            {
                m_Animator.SetBool("IsCrouch", false);
            }
        }
    }

    private void TranslateCharacterHorizontal(float horizontal)
    {
        Vector3 position = m_Player.transform.position;
        position.x += horizontal * Time.deltaTime * speed;
        m_Player.transform.position = position;
    }

    private void TranslateCharacterVertical()
    {
        m_Rigidbody2D.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        return BoxCastAndDraw(m_Collider.bounds.center, m_Collider.bounds.size, 0, Vector2.down, 0.01f, jumpableLayers);
        //return Physics2D.BoxCast(m_Collider.bounds.center, m_Collider.bounds.size, 0, Vector2.down, 0.4f, LayerMask.NameToLayer("Platform"));
    }

    public static void Draw(
        RaycastHit2D hitInfo,
        Vector2 origin,
        Vector2 size,
        float angle,
        Vector2 direction,
        float distance = Mathf.Infinity)
    {
        // Set up points to draw the cast.
        Vector2[] originalBox = CreateOriginalBox(origin, size, angle);

        Vector2 distanceVector = GetDistanceVector(distance, direction);
        Vector2[] shiftedBox = CreateShiftedBox(originalBox, distanceVector);

        // Draw the cast.
        Color castColor = hitInfo ? Color.red : Color.green;
        DrawBox(originalBox, castColor);
        DrawBox(shiftedBox, castColor);
        ConnectBoxes(originalBox, shiftedBox, Color.gray);

        if (hitInfo)
        {
            Debug.DrawLine(hitInfo.point, hitInfo.point + (hitInfo.normal.normalized * 0.2f), Color.yellow);
        }
    }

    /// <summary>
    ///     Casts a box against colliders in the Scene, returning the first collider to contact with it, and visualizes it.
    /// </summary>
    /// <param name="origin"> The point in 2D space where the box originates. </param>
    /// <param name="size"> The size of the box. </param>
    /// <param name="angle"> The angle of the box (in degrees). </param>
    /// <param name="direction"> A vector representing the direction of the box. </param>
    /// <param name="distance"> The maximum distance over which to cast the box. </param>
    /// <param name="layerMask"> Filter to detect Colliders only on certain layers. </param>
    /// <param name="minDepth"> Only include objects with a Z coordinate (depth) greater than or equal to this value. </param>
    /// <param name="maxDepth"> Only include objects with a Z coordinate (depth) less than or equal to this value. </param>
    /// <returns>
    ///     The cast result.
    /// </returns>
    public static RaycastHit2D BoxCastAndDraw(
        Vector2 origin,
        Vector2 size,
        float angle,
        Vector2 direction,
        float distance = Mathf.Infinity,
        int layerMask = Physics2D.AllLayers,
        float minDepth = -Mathf.Infinity,
        float maxDepth = Mathf.Infinity)
    {
        var hitInfo = Physics2D.BoxCast(origin, size, angle, direction, distance, layerMask, minDepth, maxDepth);
        Draw(hitInfo, origin, size, angle, direction, distance);
        return hitInfo;
    }

    private static Vector2[] CreateOriginalBox(Vector2 origin, Vector2 size, float angle)
    {
        float w = size.x * 0.5f;
        float h = size.y * 0.5f;
        Quaternion q = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));

        var box = new Vector2[4]
        {
            new Vector2(-w, h),
            new Vector2(w, h),
            new Vector2(w, -h),
            new Vector2(-w, -h),
        };

        for (int i = 0; i < 4; i++)
        {
            box[i] = (Vector2)(q * box[i]) + origin;
        }

        return box;
    }

    private static Vector2[] CreateShiftedBox(Vector2[] box, Vector2 distance)
    {
        var shiftedBox = new Vector2[4];
        for (int i = 0; i < 4; i++)
        {
            shiftedBox[i] = box[i] + distance;
        }

        return shiftedBox;
    }

    private static void DrawBox(Vector2[] box, Color color)
    {
        Debug.DrawLine(box[0], box[1], color);
        Debug.DrawLine(box[1], box[2], color);
        Debug.DrawLine(box[2], box[3], color);
        Debug.DrawLine(box[3], box[0], color);
    }

    private static void ConnectBoxes(Vector2[] firstBox, Vector2[] secondBox, Color color)
    {
        Debug.DrawLine(firstBox[0], secondBox[0], color);
        Debug.DrawLine(firstBox[1], secondBox[1], color);
        Debug.DrawLine(firstBox[2], secondBox[2], color);
        Debug.DrawLine(firstBox[3], secondBox[3], color);
    }

    private static Vector2 GetDistanceVector(float distance, Vector2 direction)
    {
        if (distance == Mathf.Infinity)
        {
            // Draw some large distance e.g. 5 scene widths long.
            float sceneWidth = Camera.main.orthographicSize * Camera.main.aspect * 2f;
            distance = sceneWidth * 5f;
        }

        return direction.normalized * distance;
    }


}
