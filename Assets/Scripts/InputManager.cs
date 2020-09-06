/**
 * So I was able to get this class to work at one point. Then I went to bed and tried
 * it again and it just didnt work. So i'm leaving this here just because. 
 * 
 * Is there a reason why this didn't work when I attached it to the InputManager Object?
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameObject rightPaddle;
    GameObject leftPaddle;
    GameObject ball;

    public float leftScore = 0;
    public float rightScore = 0;
    public const float MAX_SCORE = 3;



    // Start is called before the first frame update
    void Start()
    {
        rightPaddle = GameObject.Find("PaddleRight");
        leftPaddle = GameObject.Find("PaddleLeft");
        ball = GameObject.Find("Ball");
        
    }

    // Update is called once per frame
    void Update()
    {
        // if the ball is passed 11.15 on the x position score is to the left paddle
        // if ball is pass -40 on the x position score is  the right paddle
        if (ball.transform.position.x > 12)
        {
            Debug.Log("We are passing the right paddle");
            if (leftScore < MAX_SCORE)
            {
                LeftScored();
            }
            else
            {
                RestartGame();
            }

        }
        if (ball.transform.position.x < -12)
        {
            if (leftScore < MAX_SCORE)
            {
                RightScored();
            }
            else
            {
                RestartGame();
            }

        }
    }

    public void LeftScored()
    {
        Debug.Log("LEFT PERSON SCORES");
        leftScore++;
        rightPaddle.transform.position = new Vector3(10, 1, 0);
        ball.transform.position = new Vector3(9, 1, 0);
        Debug.Log("CURRENT SCORE |L:" + leftScore + " R:" + rightScore + "|");


    }

    public void RightScored()
    {
        Debug.Log("RIGHT PERSON SCORES");
        rightScore++;
        leftPaddle.transform.position = new Vector3(-10, 1, 0);
        ball.transform.position = new Vector3(-9, 1, 0);
        Debug.Log("CURRENT SCORE |L:" + leftScore + " R:" + rightScore + "|");
    }
    public void RestartGame()
    {
        leftScore = 0;
        rightScore = 0;

        rightPaddle.transform.position = new Vector3(10, 1, 0);
        leftPaddle.transform.position = new Vector3(-10, 1, 0);
        ball.transform.position = new Vector3(0, 1, 0);

    }
}
