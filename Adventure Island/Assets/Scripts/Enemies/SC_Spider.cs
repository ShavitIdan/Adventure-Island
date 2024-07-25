using System.Collections;
using UnityEngine;

public class SpiderEnemy : Enemy
{
    public float tileHeight = 1f; 
    public float waitTime = 2f; 

    private float upperBound;
    private float lowerBound;
    private SpiderState currentState;
    private float stateTimer;

    private enum SpiderState
    {
        MovingUp,
        MovingDown,
        Idle
    }


    protected override void init()
    {
        base.init();
        upperBound = transform.position.y + tileHeight;
        lowerBound = transform.position.y - tileHeight;
        currentState = SpiderState.MovingUp;
        stateTimer = 0f;
    }

    private void Update()
    {
            move();
    }
         
    protected override void move()
    {
        switch (currentState)
        {
            case SpiderState.MovingUp:
                MoveUp();
                break;
            case SpiderState.MovingDown:
                MoveDown();
                break;
            case SpiderState.Idle:
                Idle();
                break;
        }
    }


    private void MoveUp()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        if (transform.position.y >= upperBound)
        {
            transform.position = new Vector3(transform.position.x, upperBound, transform.position.z);
            currentState = SpiderState.Idle;
            stateTimer = waitTime;
        }
    }

    private void MoveDown()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y <= lowerBound)
        {
            transform.position = new Vector3(transform.position.x, lowerBound, transform.position.z);
            currentState = SpiderState.Idle;
            stateTimer = waitTime;
        }
    }

    private void Idle()
    {
        stateTimer -= Time.deltaTime;
        if (stateTimer <= 0)
        {
            currentState = currentState == SpiderState.Idle && transform.position.y == upperBound
                ? SpiderState.MovingDown
                : SpiderState.MovingUp;
        }
    }
}