using UnityEngine;

public class SC_RedMountProjectile : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 2f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void Shoot(float direction)
    {
        rb.velocity = new Vector2(speed * direction, 0);
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * direction;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.takeDamage(1); 
            }
            Destroy(gameObject); 
        }
    }
}
