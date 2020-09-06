using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    public float amplify = 20;


    GameObject rightPaddle;
    GameObject leftPaddle;

    public float leftScore = 0;
    public float rightScore = 0;
    public const float MAX_SCORE = 2;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rightPaddle = GameObject.Find("PaddleRight");
        leftPaddle = GameObject.Find("PaddleLeft");
        for(int i = 0; i < 15; i++)
        {
            AddForce();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if the ball is passed 11.15 on the x position score is to the left paddle
        // if ball is pass -40 on the x position score is  the right paddle
        if (transform.position.x > 11)
        {
            leftScore++;
            if (leftScore == MAX_SCORE)
            {
                Debug.Log("GAME OVER!! LEFT PADDLE WON!!!");
                Debug.Log("Final score |L:" + leftScore + " R:" + rightScore + "|");
                RestartGame();  
            }
            else
            {
                LeftScored();
            }

        }
        if (transform.position.x < -12)
        {
            rightScore++; 
            if (rightScore == MAX_SCORE)
            {
                Debug.Log("GAME OVER!! RIGHT PADDLE WON!!!");
                Debug.Log("Final SCORE |L:" + leftScore + " R:" + rightScore + "|");
                RestartGame();
            }
            else
            {
                RightScored();
            }

        }
    }

    public void LeftScored()
    {
        Debug.Log("LEFT PERSON SCORES");
        rightPaddle.transform.position = new Vector3(10, 1, 0);
        transform.position = new Vector3(9, 1, 0);
        Debug.Log("CURRENT SCORE |L:" + leftScore + " R:" + rightScore + "|");
        ResetForce();

    }

    public void RightScored()
    {
        Debug.Log("RIGHT PERSON SCORES");
        leftPaddle.transform.position = new Vector3(-10, 1, 0);
        transform.position = new Vector3(-9, 1, 0);
        Debug.Log("CURRENT SCORE |L:" + leftScore + " R:" + rightScore + "|");
        ResetForce();
    }
    public void RestartGame()
    {
        leftScore = 0;
        rightScore = 0;

        rightPaddle.transform.position = new Vector3(10, 1, 0);
        leftPaddle.transform.position = new Vector3(-10, 1, 0);
        transform.position = new Vector3(0, 1, 0);
        Debug.Log("New Game");
        Debug.Log("CURRENT SCORE |L:" + leftScore + " R:" + rightScore + "|");

    }
    /**
    * Changes color of the paddle when hit
    */
    void OnCollisionEnter(Collision other)
    {
        other.gameObject.GetComponent<MeshRenderer>().material.color = NewColor();
        for (int i = 0; i < 15; i++)
        {
            AddForce();
        }

    }
    private void FixedUpdate()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            AddForce();
        }*/

    }

    private void AddForce()
    {
        // goes straight down the x axis
        rb.AddForce(new Vector3(1, 0, 0 * amplify));
    }
    private void ResetForce()
    {
        // goes straight down the x axis
        //rb.AddForce(new Vector3(1, 0, 0));
        rb.isKinematic = true;
        for (int i = 0; i < 15; i++)
        {
            AddForce();
        }
        rb.isKinematic = false; 
    }
    /**
    * Returns the color when the object hits something
    * @return color - the color object
    */
    private Color NewColor()
    {
        // uses random values for RGB
        Color color = new Color(UnityEngine.Random.value,
                                UnityEngine.Random.value,
                                UnityEngine.Random.value);
        return color;
    }

}
