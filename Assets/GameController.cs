using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float speed = 5f;
    public bool isPlayerA = false;
    public GameObject circle;
    private Rigidbody2D rb;
    private Vector2 playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 2f;
    }

    // Update is called once per frame
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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerMovement = new Vector2(0, 1);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            playerMovement = new Vector2(0, -1);
        }
        else
        {
            playerMovement = Vector2.zero; // Stop movement if no key is pressed
        }
    }

    private void PaddleAController()
    {
        // Multi player mode
        if (Input.GetKey(KeyCode.W))
        {
            playerMovement = new Vector2(0, 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerMovement = new Vector2(0, -1);
        }
        else
        {
            playerMovement = Vector2.zero; // Stop movement if no key is pressed
        }
    }

    private void FixedUpdate()
    {
        // Apply movement without multiplying by speed again
        rb.velocity = playerMovement * speed;
    }
}
