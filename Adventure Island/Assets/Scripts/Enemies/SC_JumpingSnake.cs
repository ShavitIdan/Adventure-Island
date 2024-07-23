using System.Collections;
using UnityEngine;

public class SC_JumpingSnake : Enemy
{
    public float jumpForce = 10f; // Vertical force of the jump
    public float horizontalSpeed = -5f; // Horizontal speed for the jump (negative to move left)
    public float jumpInterval = 2f; // Time between jumps

    private Rigidbody2D rb;
    private SnakeState currentState;
    private float stateTimer;

    private enum SnakeState
    {
        Idle,
        Jumping
    }
    protected override void init()
    {
        base.init();
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing.");
        }
        else
        {
            rb.freezeRotation = true; // Freeze rotation to prevent spinning
            Debug.Log("Rigidbody2D component found and configured.");
        }
        currentState = SnakeState.Idle;
        stateTimer = jumpInterval;
    }

    private void Update()
    {
        move();
    }

    protected override void move()
    {
        switch (currentState)
        {
            case SnakeState.Idle:
                Idle();
                break;
            case SnakeState.Jumping:
                // Jumping logic handled by physics
                break;
        }
    }

    

    private void Idle()
    {
        stateTimer -= Time.deltaTime;
        if (stateTimer <= 0)
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (rb != null)
        {
            Debug.Log("Jumping");
            rb.velocity = new Vector2(horizontalSpeed, jumpForce);
            Debug.Log("Velocity set to: " + rb.velocity);
        }
        currentState = SnakeState.Jumping;
        stateTimer = jumpInterval;
        StartCoroutine(TransitionToIdle());
    }

    private IEnumerator TransitionToIdle()
    {
        yield return new WaitForSeconds(0.5f); // Adjust based on jump duration
        currentState = SnakeState.Idle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SC_PlayerController.instance.ChangePower(-SC_PlayerController.instance.powerController.maxPower);
        }
    }
}
