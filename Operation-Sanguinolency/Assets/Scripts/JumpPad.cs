using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 10f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Rigidbody rb))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        }
    }
}
