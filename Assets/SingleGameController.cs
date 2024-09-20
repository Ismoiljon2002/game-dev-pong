using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGameController : MonoBehaviour
{
    public bool isPlayerA = false;
    public GameObject circle;
    private Rigidbody2D rb;
    private Vector2 playerMovement;
    public float paddleASpeed;
    public float paddleBSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 2f;
        switch (MainMenu.hardnessLevel)
        {
            case 0:
                paddleBSpeed = 3f;
                paddleASpeed = 7f;
                break;
            case 1:
                paddleBSpeed = 5f;
                paddleASpeed = 5f;
                break;
            case 2:
                paddleBSpeed = 15f;
                paddleASpeed = 5f;
                break;
            default:
                Debug.Log(MainMenu.hardnessLevel + " is shown in default");
                break;
        }
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
        if (circle.transform.position.y > transform.position.y + 0.5f) {
            playerMovement = new Vector2(0, 1);
        }
        else if (circle.transform.position.y < transform.position.y - 0.5f) {
            playerMovement = new Vector2(0, -1);
        }
        else {
            playerMovement = new Vector2(0, 0);
        }
    }

    private void PaddleAController()
    {
        playerMovement = new Vector2(0, Input.GetAxis("Vertical"));
    }


    private void FixedUpdate(){
        if (isPlayerA) 
            rb.velocity = playerMovement * paddleASpeed;
        else
            rb.velocity = playerMovement * paddleBSpeed;
    }

}
