using UnityEngine;

public class SC_Movement : MonoBehaviour
{
    public float speed;
    public float jumpSpeed = 6f;
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
            transform.rotation = Quaternion.Euler(0, 0, 0); 
        else if (horizontalInput < -0.01f)
            transform.rotation = Quaternion.Euler(0, 180, 0);   

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        SC_PlayerController.instance.GetAnimator().SetBool("IsRunning", horizontalInput != 0);
        SC_PlayerController.instance.GetAnimator().SetBool("IsGrounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
