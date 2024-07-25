using UnityEngine;

public enum PickableType
{
    Axe,
    Boomerang,
    Fairy,
    HeartMount,
    LeafMount,
    StarMount
}

public class PickableFactory
{
    private GameObject axePrefab;
    private GameObject boomerangPrefab;
    private GameObject fairyPrefab;
    private GameObject heartMountPrefab;
    private GameObject leafMountPrefab;
    private GameObject starMountPrefab;

    public PickableFactory(GameObject axePrefab, GameObject boomerangPrefab, GameObject fairyPrefab, 
                                GameObject heartMountPrefab, GameObject leafMountPrefab, GameObject starMountPrefab)
    {
        this.axePrefab = axePrefab;
        this.boomerangPrefab = boomerangPrefab;
        this.fairyPrefab = fairyPrefab;
        this.heartMountPrefab = heartMountPrefab;
        this.leafMountPrefab = leafMountPrefab;
        this.starMountPrefab = starMountPrefab;
    }

    public IPickAble CreatePickable(PickableType type)
    {
        GameObject pickableObject = null;

        switch (type)
        {
            case PickableType.Axe:
                pickableObject = Object.Instantiate(axePrefab);
                break;
            case PickableType.Boomerang:
                pickableObject = Object.Instantiate(boomerangPrefab);
                break;
            case PickableType.Fairy:
                pickableObject = Object.Instantiate(fairyPrefab);
                break;
            case PickableType.HeartMount:   
                pickableObject = Object.Instantiate(heartMountPrefab);
                break;
            case PickableType.LeafMount:
                pickableObject = Object.Instantiate(leafMountPrefab);
                break;
            case PickableType.StarMount:
                pickableObject = Object.Instantiate(starMountPrefab);
                break;

        }

        return pickableObject?.GetComponent<IPickAble>();
    }
}
