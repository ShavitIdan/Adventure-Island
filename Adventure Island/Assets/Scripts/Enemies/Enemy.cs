using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float speed;

    private void Awake()
    {
        init();
    }

    protected virtual void init()
    {
        Debug.Log("Enemy initialized.");
    }


    protected abstract void move();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SC_PlayerController.instance.kill();
        }
    }

    public void takeDamage(float damage)
    {
        die();
    }

    protected virtual void die()
    {
        Debug.Log("Enemy died.");
        gameObject.SetActive(false);
    }
}
