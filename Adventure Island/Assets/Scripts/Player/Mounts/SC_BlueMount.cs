using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BlueMount : Mount
{
    protected override void ActivateMount()
    {
        
        SC_PlayerController.instance.GetAnimator().SetBool("OnBlueMount", true);
    }

    protected override void DeactivateMount()
    {
        
        SC_PlayerController.instance.GetAnimator().SetBool("OnBlueMount", false);
    }

    public override string getMountName()
    {
        return "OnBlueMount";
    }
    public override void Attack()
    {
        SC_PlayerController.instance.GetAnimator().SetTrigger("AttackTrigger");
    }
}

