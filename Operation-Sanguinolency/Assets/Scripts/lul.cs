using UnityEngine;

public class lul : MonoBehaviour
{
    public float lulus = 1;
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
            rb.AddForce(transform.up * -lulus);
        }
    }
}
