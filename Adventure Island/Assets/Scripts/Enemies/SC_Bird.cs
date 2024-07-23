using UnityEngine;

public class SC_Bird : Enemy
{
    public float tileHeight = 1f; 
    public float verticalSpeed = 1f;

    private float upperBound;
    private float lowerBound;
    private BirdState currentState;

    private enum BirdState
    {
        MovingUp,
        MovingDown
    }
    protected override void init()
    {
        base.init();
        upperBound = transform.position.y + tileHeight;
        lowerBound = transform.position.y - tileHeight;
        currentState = BirdState.MovingUp;
    }

    private void Update()
    {
        move();
    }

    protected override void move()
    {
        MoveLeft();
        VerticalMovement();
    }

   
    private void MoveLeft()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void VerticalMovement()
    {
        switch (currentState)
        {
            case BirdState.MovingUp:
                MoveUp();
                break;
            case BirdState.MovingDown:
                MoveDown();
                break;
        }
    }

    private void MoveUp()
    {
        transform.position += Vector3.up * verticalSpeed * Time.deltaTime;

        if (transform.position.y >= upperBound)
        {
            transform.position = new Vector3(transform.position.x, upperBound, transform.position.z);
            currentState = BirdState.MovingDown;
        }
    }

    private void MoveDown()
    {
        transform.position += Vector3.down * verticalSpeed * Time.deltaTime;

        if (transform.position.y <= lowerBound)
        {
            transform.position = new Vector3(transform.position.x, lowerBound, transform.position.z);
            currentState = BirdState.MovingUp;
        }
    }
}
