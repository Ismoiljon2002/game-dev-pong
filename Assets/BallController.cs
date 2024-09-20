using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallController : MonoBehaviour
{
    public float initialSpeed;
    public float speedIncrease = 0.2f;
    public Text playerText; 
    public Text opponentText; 
    private int hitCounter;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 2f);
        initialSpeed = MainMenu.ballSpeed;
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, initialSpeed + (speedIncrease * hitCounter));
    }

    private void StartBall()
    {
        rb.velocity = new Vector2(1, 0) * (initialSpeed + speedIncrease * hitCounter);
    }

    private void RestartBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        hitCounter = 0;
        Invoke("StartBall", 2f);
    }

    private void PlayerBounce(Transform obj)
    {
        hitCounter++;

        Vector2 ballPosition = transform.position;
        Vector2 playerPosition = obj.position;

        float xDirection = transform.position.x > 0 ? -1 : 1;
        float yDirection = (ballPosition.y - playerPosition.y) / obj.GetComponent<Collider2D>().bounds.size.y;

        if (yDirection == 0)
        {
            yDirection = 0.25f;
        }

        rb.velocity = new Vector2(xDirection, yDirection) * (initialSpeed + (speedIncrease * hitCounter));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "PaddleA" || other.gameObject.name == "PaddleB")
        {
            PlayerBounce(other.transform);
        } else if (other.gameObject.name == "LeftObstacle" || other.gameObject.name == "RightObstacle") {

            Vector2 ballPosition = transform.position;
            Vector2 playerPosition = other.transform.position; 

            float xDirection = transform.position.x > 0 ? -1 : 1;
            float yDirection = (ballPosition.y - playerPosition.y) / other.transform.GetComponent<Collider2D>().bounds.size.y;

            if (yDirection == 0)
            {
                yDirection = 0.25f;
            }

            rb.velocity = new Vector2(xDirection, yDirection) * (initialSpeed + (speedIncrease * hitCounter));

            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (transform.position.x > 0)
        {
            RestartBall();
            playerText.text = (int.Parse(playerText.text) + 1).ToString();
        }
        else if (transform.position.x < 0)
        {
            RestartBall();
            opponentText.text = (int.Parse(opponentText.text) + 1).ToString();
        }
    }
}
