using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_AxePool : MonoBehaviour
{
    public static SC_AxePool sharedInstance;
    private List<GameObject> pooledAxes;
    public GameObject axePrefab;
    public Transform projectilesHolder;
    public int amountToPool = 5;

    private AxeBuilder axeBuilder;
    private AxeDirector axeDirector;


    private void Awake()
    {
        sharedInstance = this;
        axeBuilder = new AxeBuilder();
        axeDirector = new AxeDirector(axeBuilder);
    }
    void Start()
    {
        pooledAxes = new List<GameObject>();
        if (axePrefab != null)
            for (int i = 0; i < amountToPool; i++)
                CreateAxe();
    }

    public GameObject GetPooledAxe()
    {
        foreach (var axe in pooledAxes)
        {
            if (!axe.activeInHierarchy)
                return axe;
        }
        return CreateAxe();
    }

    private GameObject CreateAxe()
    {
        GameObject newAxe = axeDirector.Construct(axePrefab);
        newAxe.SetActive(false);
        if (projectilesHolder != null)
            newAxe.transform.SetParent(projectilesHolder);
        pooledAxes.Add(newAxe);
        return newAxe;
    }

}
