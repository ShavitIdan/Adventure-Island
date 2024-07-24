using UnityEngine;

public class SC_RedMount : Mount
{
    public GameObject projectilePrefab;

    private Transform firePoint;

    protected override void ActivateMount()
    {
        SC_PlayerController.instance.GetAnimator().SetBool("OnRedMount", true);
        firePoint = SC_PlayerController.instance.GetWeaponTransform();
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
        ShootProjectile();
    }

    private void ShootProjectile()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            SC_RedMountProjectile redMountProjectile = projectile.GetComponent<SC_RedMountProjectile>();
            if (redMountProjectile != null)
            {
                float direction = SC_PlayerController.instance.getPlayer().transform.localScale.x;
                redMountProjectile.Shoot(direction);
            }
        }
    }
}
