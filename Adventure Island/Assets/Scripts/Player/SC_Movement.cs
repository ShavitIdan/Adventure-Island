using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Movement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    
    private bool grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        SC_PlayerController.instance.GetAnimator().SetBool("IsRunning", horizontalInput != 0);
        SC_PlayerController.instance.GetAnimator().SetBool("IsGrounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        SC_PlayerController.instance.GetAnimator().SetTrigger("Jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

}
