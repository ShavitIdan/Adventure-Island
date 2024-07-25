using UnityEngine;

public class SC_FireObstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!SC_PlayerController.instance.GetImmune())
            {
                if (SC_PlayerController.instance.GetMount() != null)
                {
                    SC_PlayerController.instance.GetMount().Dismount();
                    SC_PlayerController.instance.SetMount(null);
                    gameObject.SetActive(false);
                }
                else
                {
                    SC_PlayerController.instance.kill();
                }
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
