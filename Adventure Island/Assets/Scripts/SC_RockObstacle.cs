using UnityEngine;

public class SC_RockObstacle : MonoBehaviour
{
    public int powerValue = 3;

    public void TakeDamage()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if (!SC_PlayerController.instance.GetImmune())
            {
                SC_PlayerController.instance.ChangePower(powerValue * -1);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
