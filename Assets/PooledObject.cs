using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public PoolIdentity parentPool;

    private void OnDisable()
    {
        parentPool.
            MakeAvailable(this.gameObject);
    }
}
