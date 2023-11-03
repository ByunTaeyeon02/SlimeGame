using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    public Transform target;
    public Transform targetClone;
    public Vector3 offset = new Vector3(0f, 3f, -10f);
    public float zoomSize = 7.0f;
    public int curCam = 3;

    public float minSize = 8f; // Set a minimum camera size to prevent extreme zooming in
    public float maxSize = 15f; // Set a maximum camera size to prevent extreme zooming out
    public float distanceOffset = -2.5f;

    void LateUpdate()
    {
        // Detect keyboard input to change curCam value
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            curCam = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            curCam = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            curCam = 3;
        }

        // Follow the target with the camera based on curCam value
        if (target != null && targetClone != null)
        {
            if (curCam == 1)
            {
                transform.position = new Vector3(target.position.x + offset.x,
                                                 target.position.y + offset.y,
                                                 offset.z);
                Camera.main.orthographicSize = zoomSize;
            }
            else if (curCam == 2)
            {
                transform.position = new Vector3(targetClone.position.x + offset.x,
                                                 targetClone.position.y + offset.y,
                                                 offset.z);
                Camera.main.orthographicSize = zoomSize;
            }
            else
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
}
