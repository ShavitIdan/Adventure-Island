using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Spider : Enemy
{
    private int currentWaypointIndex = 0;
    private bool movingUp = true;

    protected override void init()
    {
        base.init();
    }

    protected override void move()
    {
        if (waypoints.Length > 1)
        {
            Transform targetWaypoint = waypoints[currentWaypointIndex];
            Vector3 direction = (targetWaypoint.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                if (movingUp)
                {
                    currentWaypointIndex++;
                    if (currentWaypointIndex >= waypoints.Length)
                    {
                        currentWaypointIndex = waypoints.Length - 1;
                        movingUp = false;
                    }
                }
                else
                {
                    currentWaypointIndex--;
                    if (currentWaypointIndex < 0)
                    {
                        currentWaypointIndex = 0;
                        movingUp = true;
                    }
                }
            }
        }
    }

    protected override void attack()
    {

    }
}
