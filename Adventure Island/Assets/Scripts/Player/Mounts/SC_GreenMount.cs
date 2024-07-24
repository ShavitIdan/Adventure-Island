using UnityEngine;

public class SC_GreenMount : Mount
{
    public GameObject attackRingPrefab; // The prefab for the attack ring

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
        PerformRollingAttack();
    }

    private void PerformRollingAttack()
    {
        // Instantiate the attack ring prefab at the player's position
        GameObject attackRing = Instantiate(attackRingPrefab, SC_PlayerController.instance.getPlayer().transform.position, Quaternion.identity);
        // Make the attack ring a child of the player
        attackRing.transform.SetParent(SC_PlayerController.instance.getPlayer().transform);
    }
}
