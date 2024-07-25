using System.Collections;
using UnityEngine;

public class SC_BlueMount : Mount
{
    public GameObject swingAttackPrefab;
    public Transform attackPoint; 

    protected override void ActivateMount()
    {
        SC_PlayerController.instance.GetAnimator().SetBool("OnBlueMount", true);
        attackPoint = SC_PlayerController.instance.GetWeaponTransform(); 
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
        StartCoroutine(PerformSwingAttack());
    }

    private IEnumerator PerformSwingAttack()
    {
        yield return new WaitForSeconds(0.1f);

        Vector3 attackPosition = attackPoint.position;

        float direction = SC_PlayerController.instance.getPlayer().transform.eulerAngles.y == 0 ? 1 : -1;
        attackPosition.x += 0.5f * direction;

        Instantiate(swingAttackPrefab, attackPosition, Quaternion.identity);
    }

}
