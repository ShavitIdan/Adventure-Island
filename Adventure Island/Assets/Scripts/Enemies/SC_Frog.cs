using System.Collections;
using UnityEngine;

public class SC_Frog : Enemy
{
    public float jumpForce = 3f; 
    public float jumpInterval = 4f;
    public float jumpHeightMultiplier = 1f;

    private Rigidbody2D rb;
    private Transform playerTransform;
    private bool isJumping = false;
    private Animator animator;

    protected override void init()
    {
        base.init();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing.");
        }
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (playerTransform == null)
        {
            Debug.LogError("Player not found in the scene.");
        }
        StartCoroutine(JumpRoutine());
    }

    private void Update()
    {

        if (!isDead && GetPlayerInRange() &&!isJumping )
        {
            move();
        }
    }

    protected override void move()
    {
        // Move logic is handled by the coroutine
    }
    private IEnumerator JumpRoutine()
    {
        while (true)
        {
            if (!isDead && GetPlayerInRange())
            {
                yield return new WaitForSeconds(jumpInterval);
                Jump();
            }
            else
            {
                yield return null;
            }
        }
    }

    private void Jump()
    {
        if (rb != null && playerTransform != null)
        {
            isJumping = true;
            Vector2 direction = (playerTransform.position - transform.position).normalized;

            if (direction.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1); 
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1); 
            }

            Vector2 jumpVector = new Vector2(direction.x * jumpForce, jumpHeightMultiplier * jumpForce);
            rb.velocity = Vector2.zero; 
            animator.SetTrigger("Jump");
            rb.AddForce(jumpVector, ForceMode2D.Impulse);

            Debug.Log("Frog jumped towards player with force: " + jumpVector);
            StartCoroutine(ResetJump());
        }
    }

    private IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(0.5f); // Adjust based on jump duration
        isJumping = false;
    }

}
