using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ResetPosition : MonoBehaviour
{
    private Vector3 startPositon;
    private void OnEnable()
    {
    }
    private void OnDisable()
    {
    }
    void Awake()
    {
        startPositon = transform.position;
    }
    public void OnResetPosition()
    {
        transform.position = startPositon;
    }
}

