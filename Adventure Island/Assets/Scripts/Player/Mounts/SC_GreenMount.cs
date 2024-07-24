using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_GreenMount : Mount
{
    protected override void ActivateMount()
    {

        SC_PlayerController.instance.GetAnimator().SetBool("OnGreenMount", true);
    }

    protected override void DeactivateMount()
    {

        SC_PlayerController.instance.GetAnimator().SetBool("OnGreenMount", false);
    }

    public override string getMountName()
    {
        return "OnGreenMount";
    }
    public override void Attack()
    {
        SC_PlayerController.instance.GetAnimator().SetTrigger("AttackTrigger");
    }
}
