using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SC_PowerBar : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform slotContainer;
    public int maxPower = 15;
    public float currentPower;
    public float decreaseAmount = 1f; 
    public float decreaseTime = 2f;

    private GameObject[] slots;

    private void Start()
    {
        currentPower = maxPower;
        slots = new GameObject[maxPower];

        for (int i = 0; i < maxPower; i++)
        {
            GameObject slot = Instantiate(slotPrefab, slotContainer);
            slots[i] = slot;
        }

        StartCoroutine(DecreasePowerOverTime());
    }

    private IEnumerator DecreasePowerOverTime()
    {
        while (currentPower > 0)
        {
            yield return new WaitForSeconds(decreaseTime);
            ChangePower(-decreaseAmount);
        }

        Debug.Log("Player is dead");
        // Add your player death logic here
    }

    public void ChangePower(float amount)
    {
        currentPower += amount;
        currentPower = Mathf.Clamp(currentPower, 0, maxPower);

        UpdatePowerSlots();
    }

    private void UpdatePowerSlots()
    {
        for (int i = 0; i < maxPower; i++)
        {
            if (i < currentPower)
            {
                slots[i].SetActive(true);
            }
            else
            {
                slots[i].SetActive(false);
            }
        }
    }
}

