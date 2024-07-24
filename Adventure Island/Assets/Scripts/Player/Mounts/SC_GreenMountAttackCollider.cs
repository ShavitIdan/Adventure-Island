using UnityEngine;

public class SC_GreenMountAttackCollider : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit by GreenMount attack.");
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.takeDamage(1);
                Debug.Log("Enemy took damage.");
            }
        }
    }
}
