﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
    public float speed = 30;

    private Rigidbody2D rigidBody;

    private AudioSource AudioSource;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * speed;

	}
	void OnCollisionEnter2D(Collision2D col)
    {
        //leftpaddle or rightpaddle
        if ((col.gameObject.name == "LeftPaddle" )||
            (col.gameObject.name == "RightPaddle"))
        {
            HandlePaddleHit(col);

        }

        //wallbottom or walltop
        if ((col.gameObject.name == "WallBottom") ||
           (col.gameObject.name == "WallTop"))
        {
            SoundManger.Instance.PlayOneShot
            (SoundManger.Instance.WallBloop);

        }
        //leftgoal or rightgoal
        if ((col.gameObject.name == "LeftGoal") ||
           (col.gameObject.name == "RightGoal"))
        {
            SoundManger.Instance.PlayOneShot
            (SoundManger.Instance.GoalBloop);

            // TODO Update Score UI
            if(col.gameObject.name == "LeftGoal")
            {
                IncreaseTextUIScore("RightScoreUI");
            }

            if (col.gameObject.name == "RightGoal")
            {
                IncreaseTextUIScore("LeftScoreUI");
            }

            //Move the ball to the center of the screen
            transform.position = new Vector2(0, 0);

        }
    }
    void HandlePaddleHit(Collision2D col)
    {
        float y = BallHitPaddleWhere(transform.position,
            col.transform.position,
            col.collider.bounds.size.y);
        Vector2 dir = new Vector2();

        if(col.gameObject.name == "LeftPaddle")
        {
            dir = new Vector2(1, y).normalized;
        }

        if (col.gameObject.name == "RightPaddle")
        {
            dir = new Vector2(-1, y).normalized;
        }

        rigidBody.velocity = dir * speed ;

        SoundManger.Instance.PlayOneShot
            (SoundManger.Instance.HitPaddleBloop); 
    }

    float BallHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }
    void IncreaseTextUIScore(string TextUIName)
    {
        var TextUIComp = GameObject.Find
            (TextUIName).GetComponent < Text>();

        int score = int.Parse(TextUIComp.text);

        score++;

        TextUIComp.text = score.ToString();
    }
}
