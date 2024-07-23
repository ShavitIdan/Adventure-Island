using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PowerUp : MonoBehaviour, IPickAble
{
    public abstract void OnPickUp(GameObject picker);
}
