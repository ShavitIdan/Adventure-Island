using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SC_FruitGUI : MonoBehaviour
{
    public TextMeshProUGUI fruitCountText;
    private void OnEnable()
    {
        SC_Fruit.OnFruitPickedUp += UpdateFruitCount;
    }

    private void OnDisable()
    {
        SC_Fruit.OnFruitPickedUp -= UpdateFruitCount;
    }

    private void UpdateFruitCount()
    {
        fruitCountText.text = "Fruits: " + SC_Fruit.getFruitCount().ToString();
    }
}
