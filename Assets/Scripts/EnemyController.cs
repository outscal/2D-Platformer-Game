using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float horizontal = 1;
    public bool turnenemy;
    private void Update()
    {   if (turnenemy)
        {
            turn();
            turnenemy = false;
        }
        movePlayerHorizontal(horizontal);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playercontroller = collision.gameObject.GetComponent<PlayerController>();
            Debug.Log(playercontroller);
            playercontroller.killPlayer();
        }
    }
    public void turn()
    {
        Debug.Log("Turn enemy");
        horizontal *= -1;
        transform.rotation = Quaternion.Euler(0, transform.rotation.y +180, 0);
    }
    private void movePlayerHorizontal(float horizontal)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontal * 3 * Time.deltaTime;
        transform.position = position;
    }
}
