using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float speed;
    public float respawnTime = 5f;
    private Vector3 deathPosition;
    protected bool isDead = false;
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2D;
    public SC_DropSystem dropSystem;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
        dropSystem = GetComponent<SC_DropSystem>();
        init();
    }

    protected virtual void init()
    {
        Debug.Log("Enemy initialized.");
    }


    protected abstract void move();

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!SC_PlayerController.instance.GetImmune())
            {
                SC_PlayerController.instance.kill();
            }
            else
            {
                takeDamage(1);
            }
        }
    }

    public virtual void takeDamage(float damage)
    {
        if (!isDead)
        {
            
            die();
        }
        
    }

    protected virtual void die()
    {
        Debug.Log("Enemy died.");
        deathPosition = transform.position;
        isDead = true;
        spriteRenderer.enabled = false;
        collider2D.enabled = false;

        dropSystem?.TryDropPowerUp(deathPosition);
        StartCoroutine(RespawnTimer());
    }
    private IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(respawnTime);
        Respawn();
    }

    private void Respawn()
    {
        Debug.Log("Enemy respawned.");
        transform.position = deathPosition;
        isDead = false;
        spriteRenderer.enabled = true;
        collider2D.enabled = true;
        init();
    }
}
