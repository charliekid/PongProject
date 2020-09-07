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

    // Audio
    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rightPaddle = GameObject.Find("PaddleRight");
        leftPaddle = GameObject.Find("PaddleLeft");
        source = GetComponent<AudioSource>();
        for (int i = 0; i < 15; i++)
        {
            AddForce();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // When the ball passes the right paddle
        if (transform.position.x > 11)
        {
            leftScore++;
            if (leftScore == MAX_SCORE)
            {
                Debug.Log("GAME OVER!! LEFT PADDLE WINS!!!");
                Debug.Log("Final score |L:" + leftScore + " R:" + rightScore + "|");
                RestartGame();  
            }
            else
            {
                LeftScored();
            }

        }
        // When the ball passes the left paddle
        if (transform.position.x < -12)
        {
            rightScore++; 
            if (rightScore == MAX_SCORE)
            {
                Debug.Log("GAME OVER!! RIGHT PADDLE WINS!!!");
                Debug.Log("Final SCORE |L:" + leftScore + " R:" + rightScore + "|");
                RestartGame();
            }
            else
            {
                RightScored();
            }

        }
    }

    /**
     * Left player/paddle scored. This method repositions the paddle, ball,
     * and increases the score. 
     */ 
    public void LeftScored()
    {
        Debug.Log("LEFT PERSON SCORES");
        rightPaddle.transform.position = new Vector3(10, 1, 0);
        transform.position = new Vector3(9, 1, 0);
        Debug.Log("CURRENT SCORE |L:" + leftScore + " R:" + rightScore + "|");
        ResetForce();
    }
    /**
     * Right player/paddle scored. This method repositions the paddle, ball,
     * and increases the score. 
     */
    public void RightScored()
    {
        Debug.Log("RIGHT PERSON SCORES");
        leftPaddle.transform.position = new Vector3(-10, 1, 0);
        transform.position = new Vector3(-9, 1, 0);
        Debug.Log("CURRENT SCORE |L:" + leftScore + " R:" + rightScore + "|");
        ResetForce();
    }
    /**
     * This method restarts the paddles and the ball for a 
     */
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
        source.Play();
        for (int i = 0; i < 15; i++)
        {
            AddForce();
        }
    }
    /**
     * This adds force to the ball
     */
    private void AddForce()
    {
        rb.AddForce(new Vector3(1, 0, 0 * amplify));
    }
    private void ResetForce()
    {
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
