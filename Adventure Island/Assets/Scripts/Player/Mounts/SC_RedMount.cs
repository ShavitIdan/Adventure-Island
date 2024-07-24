using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_RedMount : Mount
{
    protected override void ActivateMount()
    {

        SC_PlayerController.instance.GetAnimator().SetBool("OnRedMount", true);
    }

    protected override void DeactivateMount()
    {

        SC_PlayerController.instance.GetAnimator().SetBool("OnRedMount", false);
    }

    public override string getMountName()
    {
        return "OnRedMount";
    }
    public override void Attack()
    {
        SC_PlayerController.instance.GetAnimator().SetTrigger("AttackTrigger");
    }
}
