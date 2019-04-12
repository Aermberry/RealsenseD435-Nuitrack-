using UnityEngine;

public class LerpRotation : MonoBehaviour {

    [SerializeField] float sphereRadius = 0.12f;
    [SerializeField] Transform targetTr;
    [SerializeField] float speed = 10.0f;
    [SerializeField] Vector3 rotOffset;

    public Vector3 targetPosition;

    Vector3 newPosition;

    void Update()
    {
        newPosition = Vector3.Lerp(newPosition, targetTr.position, Time.deltaTime * speed);
        transform.LookAt(newPosition);
        transform.rotation *= Quaternion.Euler(rotOffset);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(targetTr.position, sphereRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(newPosition, sphereRadius);
    }
}
