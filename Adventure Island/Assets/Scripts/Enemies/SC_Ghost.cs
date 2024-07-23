using System.Collections;
using UnityEngine;

public class SC_Ghost : Enemy
{
    public float followSpeed = 1f; 

    private Transform playerTransform;

    protected override void init()
    {
        base.init();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (playerTransform == null)
        {
            Debug.LogError("Player not found in the scene.");
        }
    }

    private void Update()
    {
        if (!isDead)
        {
            move();
        }
    }

    protected override void move()
    {
        if (playerTransform != null)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.position += direction * followSpeed * Time.deltaTime;
        }
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isDead && SC_PlayerController.instance.GetImmune())
            {
                die();
            }
            else
                SC_PlayerController.instance.kill();
        }
        
    }

    public override void takeDamage(float damage)
    {
        Debug.Log("Ghost is immune.");
    }
}
