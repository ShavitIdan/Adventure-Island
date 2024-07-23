using System.Collections;
using UnityEngine;

public class SC_FireSnake : Enemy
{
    public GameObject fireballPrefab; // Prefab of the fireball
    public Transform firePoint; // Point from which the fireball will be shot
    public float shootInterval = 2f; // Time between shots

    private FireSnakeState currentState;
    private float stateTimer;
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
        currentState = FireSnakeState.Idle;
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
            yield return new WaitForSeconds(shootInterval);
            Shoot();
        }
    }

    private void Shoot()
    {
        if (fireballPrefab != null && firePoint != null)
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
                scFireball.Shoot(direction );
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SC_PlayerController.instance.ChangePower(-SC_PlayerController.instance.powerController.maxPower);
        }
    }
}
