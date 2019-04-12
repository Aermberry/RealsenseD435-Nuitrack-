using UnityEngine;

public class RigidbodyFollower : MonoBehaviour
{
    [SerializeField] Transform target;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(target.position);
        rb.MoveRotation(target.rotation);
    }
}