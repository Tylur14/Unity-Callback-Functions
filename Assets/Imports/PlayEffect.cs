using UnityEngine;

public class PlayEffect : MonoBehaviour
{
    [SerializeField] private string effect;
    //[SerializeField] private GameObject effect;
    
    public void PlayAtLocation(Vector2 pos)
    {
        var obj = 
            FindObjectOfType<Pool>().GetObject(effect);
        obj.transform.position = pos;
        obj.SetActive(true);
    }
}
