using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiGameController : MonoBehaviour
{
    public float speed;
    public bool isPlayerA = false;
    public GameObject circle;
    private Rigidbody2D rb;
    private Vector2 playerMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 2f;
        speed = MainMenu.paddleSpeed;
    }

    void Update()
    {
        if (isPlayerA)
        {
            PaddleAController();
        }
        else
        {
            PaddleBController();
        }
    }

    private void PaddleBController()
    {
        // Multi player mode
        if (Input.GetKey(KeyCode.UpArrow)) {   
            playerMovement = new Vector2(0, 1);
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            playerMovement = new Vector2(0, -1);
        }
        else {
            playerMovement = Vector2.zero;
        }
    }

    private void PaddleAController()
    {
        // Multi player mode
        if (Input.GetKey(KeyCode.W)) {
            playerMovement = new Vector2(0, 1);
        } else if (Input.GetKey(KeyCode.S)) {
            playerMovement = new Vector2(0, -1);
        } else {
            playerMovement = Vector2.zero;
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = playerMovement * speed;
    }
}
