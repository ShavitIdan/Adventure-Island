using UnityEngine;

public class SC_BlueMountAttack : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 0.3f); 
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
