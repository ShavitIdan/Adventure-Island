using UnityEngine;

public class SC_DropSystem : MonoBehaviour
{
    public static SC_DropSystem instance;

    public GameObject axePrefab;
    public GameObject boomerangPrefab;
    public GameObject fairyPrefab;
    public GameObject heartMountPrefab;
    public GameObject leafMountPrefab;
    public GameObject starMountPrefab;

    public float dropChance = 1f;

    private PickableFactory pickableFactory;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        pickableFactory = new PickableFactory(axePrefab,boomerangPrefab,fairyPrefab,heartMountPrefab,leafMountPrefab,starMountPrefab);
    }

    public void TryDropPickable(Vector3 position)
    {
        if (Random.value <= dropChance)
        {
            DropPickable(position);
        }
    }

    public void DropPickable(Vector3 position)
    {
        PickableType pickableType = (PickableType)Random.Range(0, System.Enum.GetValues(typeof(PickableType)).Length);
        IPickAble pickable = pickableFactory.CreatePickable(pickableType);
        if (pickable != null)
        {
            GameObject pickableGameObject = ((MonoBehaviour)pickable).gameObject;
            pickableGameObject.transform.position = position;
        }
    }


}
