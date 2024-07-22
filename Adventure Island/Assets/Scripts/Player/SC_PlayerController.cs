using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayerController : MonoBehaviour
{
    static public SC_PlayerController instance;
    public GameObject player;
    public SC_PowerBar powerBar;
    private Animator anim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        anim = player.GetComponent<Animator>();
    }
 
    public void ChangePower(float amount)
    {
        powerBar.ChangePower(amount);
    }
    public Animator GetAnimator()
    {
        return anim;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
