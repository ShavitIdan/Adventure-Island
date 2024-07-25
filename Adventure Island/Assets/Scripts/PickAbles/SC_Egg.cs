using UnityEngine;

public class SC_Egg : MonoBehaviour
{
    public Animator animator;
    private int touchCount = 0;
    private bool isCracked = false;

    private void Awake()
    {
        

        if (animator == null)
        {
            animator = GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogError("Animator component is missing.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            touchCount++;
            HandleTouch();
        }
    }

    private void HandleTouch()
    {
        if (touchCount == 1 && !isCracked)
        {
            animator.SetTrigger("Cracked");
            isCracked = true;
        }
        else if (touchCount == 2)
        {
            SC_DropSystem.instance.DropPickable(transform.position);
            Destroy(gameObject); 
        }
    }
}
