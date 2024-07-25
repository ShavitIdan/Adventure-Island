using System.Collections;
using UnityEngine;

public class SC_FireSnake : Enemy
{
    public GameObject fireballPrefab;
    public Transform firePoint;
    public float shootInterval = 2f;
    private Animator animator;
    public enum FireSnakeState
    {
        Idle,
        Shooting
    }


    protected override void init()
    {
        base.init();
        if (fireballPrefab == null)
        {
            Debug.LogError("Fireball prefab is missing.");
        }
        if (firePoint == null)
        {
            Debug.LogError("Fire point is missing.");
        }
        animator = GetComponent<Animator>();
        StartCoroutine(ShootingRoutine());
    }

    protected override void move()
    {
        // Move logic handled by coroutines
    }

    private IEnumerator ShootingRoutine()
    {
        while (true)
        {
            if (!isDead && GetPlayerInRange())
            {
                yield return new WaitForSeconds(shootInterval);
                Shoot();
            }
            else
            {
                yield return null;
            }
        }
    }

    private void Shoot()
    {
        if (!isDead && fireballPrefab != null && firePoint != null)
        {
            GameObject fireBall = SC_FireBallPool.sharedInstance.GetPooledFireBall();
            fireBall.transform.position = firePoint.position;
            fireBall.SetActive(true);

            SC_FireBall scFireball = fireBall.GetComponent<SC_FireBall>();
            if (scFireball != null)
            {
                float direction = 1;
                if (transform != null)
                    direction = transform.localScale.x > 0 ? -1 : 1;
                animator.SetTrigger("AttackTrigger");
                scFireball.Shoot(direction );
            }
        }
    }

}
