using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBuilder : IFireballBuilder
{
    private float speed;
    private float lifeTime;

    public void SetSpeed()
    {
        this.speed = 400;
    }
    public void SetLifeTime()
    {
        this.lifeTime = 2;
    }
    public GameObject Build(GameObject fireballPrefab)
    {
        GameObject newFireball = Object.Instantiate(fireballPrefab);
        SC_FireBall fireballComponent = newFireball.GetComponent<SC_FireBall>();
        fireballComponent.Initilize(speed, lifeTime);
        return newFireball;
    }

}
