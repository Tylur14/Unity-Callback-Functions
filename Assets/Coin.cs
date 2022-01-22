using UnityEngine;

public class Coin : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 moveDir;
    
    private void FixedUpdate()
    {
        transform.position += 
            moveDir * moveSpeed * Time.deltaTime;
    }

    public void TakeHit()
    {
        GetComponent<PlayEffect>().
            PlayAtLocation(this.transform.position);
        this.gameObject.SetActive(false);
    }
}
