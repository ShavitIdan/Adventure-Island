using UnityEngine;

public abstract class Mount : MonoBehaviour
{

    public virtual void MountUp()
    {
        ActivateMount();
    }

    public virtual void Dismount()
    {
        DeactivateMount();
        Destroy(gameObject);
    }

    public abstract string getMountName();

    protected abstract void ActivateMount();
    protected abstract void DeactivateMount();
    public abstract void Attack();
}
