using UnityEngine;

public class SC_DetectionRange : MonoBehaviour
{
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
        if (enemy == null)
        {
            Debug.LogError("Enemy component not found in parent.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.SetPlayerInRange(true, collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.SetPlayerInRange(false, null);
        }
    }
}
