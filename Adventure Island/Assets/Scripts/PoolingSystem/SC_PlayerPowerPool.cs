using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayerPowerPool : MonoBehaviour
{

    public static SC_PlayerPowerPool sharedInstance;
    private List<GameObject> pooledPlayerPower;
    public GameObject playerPowerPrefab;
    public Transform TransformHolder;
    public int amountToPool = 16;

    //private FireballBuilder fireballBuilder;
    //private FireballDirector fireballDirector;


    private void Awake()
    {
        sharedInstance = this;
        //fireballBuilder = new FireballBuilder();
        //fireballDirector = new FireballDirector(fireballBuilder);
    }

    void Start()
    {
        pooledPlayerPower = new List<GameObject>();
        if (playerPowerPrefab != null)
            for (int i = 0; i < amountToPool; i++) ;
                //CreatepPlayerPower();
    }

    /*public GameObject GetPooledFireBall()
    {
        foreach (var fireball in pooledPlayerPower)
        {
            if (!fireball.activeInHierarchy)
                return fireball;
        }
        return CreatepPlayerPower();
    }*/

   /* private GameObject CreatepPlayerPower()
    {
        GameObject newPlayerPower = fireballDirector.Construct(playerPowerPrefab);
        newFireBall.SetActive(false);
        if (TransformHolder != null)
            newFireBall.transform.SetParent(TransformHolder);
        pooledPlayerPower.Add(newFireBall);
        return newFireBall;
    }
   */
}

