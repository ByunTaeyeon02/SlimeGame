using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow2 : MonoBehaviour
{
    public Transform target;
    public Transform targetClone;
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    //public float newSize = 8f;
    public float minSize = 8f; // Set a minimum camera size to prevent extreme zooming in
    public float maxSize = 15f; // Set a maximum camera size to prevent extreme zooming out
    public float distanceOffset = -2.5f;

    void LateUpdate()
    {
        // Follow the target with the camera
        if (target != null && targetClone != null)
        {
            Vector3 midpoint = (target.position + targetClone.position) / 2f;
            transform.position = new Vector3(midpoint.x + offset.x, midpoint.y + offset.y, offset.z);

            // Calculate the distance between the targets
            float distance = Vector3.Distance(target.position, targetClone.position);

            // Set camera size based on the distance between targets (with clamping)
            float newSize = Mathf.Clamp(distance + distanceOffset, minSize, maxSize);
            Camera.main.orthographicSize = newSize;
        }
    }
}