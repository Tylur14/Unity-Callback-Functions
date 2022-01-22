using UnityEngine;
using UnityEngine.Events;

public class EntityRangeTrigger : MonoBehaviour
{
    [SerializeField] private string targetEntity;
    [SerializeField] private UnityEvent onEnterTrigger;
    [SerializeField] private UnityEvent onExitTrigger;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetEntity))
        {
            onEnterTrigger.Invoke();
            other.SendMessage("TakeHit");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag(targetEntity))
            onExitTrigger.Invoke();
    }
}
