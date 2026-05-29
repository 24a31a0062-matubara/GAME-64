using UnityEngine;

public class DeathZoneFollow : MonoBehaviour
{
    public Transform cameraTransform;
    public float offsetY = 2f; // ÉJÉÅÉâÇÃâ∫Ç…âΩÉ}ÉXï™â∫Ç∞ÇÈÇ©

    void LateUpdate()
    {
        if (cameraTransform == null) return;

        float cameraBottomY = cameraTransform.position.y - Camera.main.orthographicSize;
        transform.position = new Vector3(
            cameraTransform.position.x,
            cameraBottomY - offsetY,
            transform.position.z
        );
    }
}
