using UnityEngine;

public class SC_FireObstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!SC_PlayerController.instance.GetImmune())
            {
                SC_PlayerController.instance.kill();
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
