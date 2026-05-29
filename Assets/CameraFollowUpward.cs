using UnityEngine;

public class CameraFollowUpward : MonoBehaviour
{
    public Transform target;
    public float yOffset = 0.58f;
    public float smoothSpeed = 0.2f;

    private float highestY;

    void Start()
    {
        if (target != null)
        {
            highestY = target.position.y + yOffset;
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        float targetY = target.position.y + yOffset - 1f; 


        if (targetY > highestY)
        {
            highestY = targetY;
        }

        Vector3 desiredPosition = new Vector3(transform.position.x, highestY - 1f, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
