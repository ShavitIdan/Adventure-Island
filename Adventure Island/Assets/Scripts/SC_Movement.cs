using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Movement : MonoBehaviour
{
    public float speed = 5;
    private float direction;
    public float jumpSpeed = 100f;
    private bool isGrounded = false;
    private Rigidbody2D rigid;
    public LayerMask groundLayer;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        direction = Input.GetAxis("Horizontal");
        if (direction != 0 && rigid != null)
        {
            rigid.velocity = new Vector2(direction * speed, rigid.velocity.y);

            if (direction > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else transform.localScale = new Vector3(-1, 1, 1);
        }

        isGrounded = transform.IsGrounded(groundLayer);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
            }
        }
    }

    public float GetSpeed()
    {
        return speed;
    }
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpSpeed));
    }
}
