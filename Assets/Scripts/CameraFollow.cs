using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float cameraStableLeftRange;
    [SerializeField] float cameraStableRightRange;
    [SerializeField] float cameraFollowSpeed;
    [SerializeField] float cameraAdjustingSpeed;

    [SerializeField] float cameraOffset;

    Vector3 cameraPosition;

    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        cameraPosition = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
        {
            float targetX;
            if (player.transform.position.x <= cameraStableLeftRange)
            {
                targetX = player.transform.position.x - cameraOffset;
                cameraPosition.x = Mathf.Lerp(cameraPosition.x, targetX, Time.deltaTime * cameraFollowSpeed);
            }
            else if (player.transform.position.x >= cameraStableRightRange)
            {
                targetX = player.transform.position.x + cameraOffset;
                cameraPosition.x = Mathf.Lerp(cameraPosition.x, targetX, Time.deltaTime * cameraFollowSpeed);
            }
            else
            {
                targetX = player.transform.position.x + cameraOffset;
                cameraPosition.x = Mathf.Lerp(cameraPosition.x, targetX, Time.deltaTime * cameraAdjustingSpeed);
            }
            transform.position = cameraPosition;
        }
    }
}
