using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Fairy : PowerUp
{
    public float duration = 10f;

    public override void OnPickUp(GameObject picker)
    {
        StartCoroutine(ApplyPowerUp(picker));
    }

    private IEnumerator ApplyPowerUp(GameObject picker)
    {
       SC_PlayerController.instance.SetImmune(true);

        
        transform.SetParent(picker.transform);
        transform.localPosition = new Vector3(0.5f, 0.5f, 0);

        yield return new WaitForSeconds(duration);

      
       SC_PlayerController.instance.SetImmune(false);


        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPickUp(collision.gameObject);
        }
    }
}
