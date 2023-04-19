using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 10f;
    private void Start()
    {
        Debug.Log("Sali");
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Sali");
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        

        if (rb != null)
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }
}
