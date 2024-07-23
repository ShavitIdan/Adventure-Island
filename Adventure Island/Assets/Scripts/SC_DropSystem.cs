using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_DropSystem : MonoBehaviour
{
    public GameObject[] powerUps;
    public float dropChance = 0.5f;

    public void TryDropPowerUp(Vector3 position)
    {
        if (Random.value <= dropChance)
        {
            int randomIndex = Random.Range(0, powerUps.Length);
            Instantiate(powerUps[randomIndex], position, Quaternion.identity);
        }
    }
}
