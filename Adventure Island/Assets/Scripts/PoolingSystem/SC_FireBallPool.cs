using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_FireBallPool : MonoBehaviour
{
    public static SC_FireBallPool sharedInstance;
    private List<GameObject> pooledFireBalls;
    public GameObject fireBallPrefab;
    public Transform projectilesHolder;
    public int amountToPool = 3;

    private FireballBuilder fireballBuilder;
    private FireballDirector fireballDirector;


    private void Awake()
    {
       sharedInstance = this;
       fireballBuilder = new FireballBuilder();
       fireballDirector = new FireballDirector(fireballBuilder);
    }
    void Start()
    {
        pooledFireBalls = new List<GameObject>();
        if (fireBallPrefab != null)
            for (int i = 0; i < amountToPool; i++)
                CreateFireBall();
    }

    public GameObject GetPooledFireBall()
    {
        foreach(var fireball in pooledFireBalls)
        {
            if(!fireball.activeInHierarchy)
                return fireball;
        }
        return CreateFireBall();
    }

    private GameObject CreateFireBall()
    {
        GameObject newFireBall = fireballDirector.Construct(fireBallPrefab);
        newFireBall.SetActive(false);
        if (projectilesHolder != null)
            newFireBall.transform.SetParent(projectilesHolder);
        pooledFireBalls.Add(newFireBall);
        return newFireBall;
    }

}
