using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Hole : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SC_PlayerController.instance.kill();

        }
    }

}
