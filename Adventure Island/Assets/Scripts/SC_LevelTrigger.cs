using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_LevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SC_LevelManager.instance.NextLevel();
        }
    }
}
