using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PowerView : MonoBehaviour , IPowerView
{
    public GameObject slotPrefab;
    public Transform slotContainer;
    private GameObject[] slots;

    public void Initialize(int maxPower)
    {
        if (slotPrefab == null)
        {
            Debug.LogError("Slot Prefab is not assigned!");
            return;
        }

        if (slotContainer == null)
        {
            Debug.LogError("Slot Container is not assigned!");
            return;
        }

        slots = new GameObject[maxPower];
        for (int i = 0; i < maxPower; i++)
        {
            GameObject slot = Instantiate(slotPrefab, slotContainer);
            slots[i] = slot;
        }
    }

    public void UpdatePowerSlots(float currentPower, int maxPower)
    {
        if (slots == null || slots.Length != maxPower)
        {
            Debug.LogError("Slots array is not properly initialized!");
            return;
        }

        for (int i = 0; i < maxPower; i++)
        {
            slots[i].SetActive(i < currentPower);
        }
    }
}
