using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    public Transform target;
    public Transform targetClone;
    public Vector3 offset = new Vector3(2f, 3f, -10f);
    public float zoomSize = 7.0f;
    public int curCam = 3;

    public float minSize = 8f; // Set a minimum camera size to prevent extreme zooming in
    public float maxSize = 15f; // Set a maximum camera size to prevent extreme zooming out
    public float distanceOffset = -2.5f;

    public float camSpeed = 1.5f;
    public float maxOffsetX = 10.0f;
    private Vector3 lastTargetPosition;
    private Vector3 lastTargetClonePosition;

    public float targetAspectRatio = 16f / 9f;
    void Start()
    {
        // Calculate the target aspect ratio
        float currentAspectRatio = (float)Screen.width / Screen.height;

        // Calculate the desired field of view to match the target aspect ratio
        float fov = GetComponent<Camera>().fieldOfView;
        float desiredFov = fov * (targetAspectRatio / currentAspectRatio);

        // Set the field of view to match the target aspect ratio
        GetComponent<Camera>().fieldOfView = desiredFov;
    }

    public void SetCurCam(int newCam)
    {
        curCam = newCam;
    }

    private void LateUpdate()
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
    }

    void FixedUpdate()
    {
        // Follow the target with the camera based on curCam value
        if (target != null && targetClone != null)
        {   
            /*
            // Calculate the direction based on position changes between frames
            Vector3 targetVelocity = (target.position - lastTargetPosition) / Time.fixedDeltaTime;
            Vector3 targetCloneVelocity = (targetClone.position - lastTargetClonePosition) / Time.fixedDeltaTime;

            // Determine the sign of the x-component of the velocity direction
            float xSign = 0;
            if (targetVelocity.x > 0.5 || targetCloneVelocity.x > 0.5)
            {
                xSign = Mathf.Sign(targetVelocity.x);
                if (curCam == 2)
                {
                    xSign = Mathf.Sign(targetCloneVelocity.x);
                }
            }

            // Set offset.x based on the velocity direction (3 if moving forward, -3 if moving backward)
            float xOffset = xSign > 0 ? 3f : -3f;

            // Update the last positions for the next frame calculation
            lastTargetPosition = target.position;
            lastTargetClonePosition = targetClone.position; */

            if (curCam == 1)
            {
                /*
                Vector3 targetPosition = new Vector3(target.position.x + xOffset + +offset.x,
                                                     target.position.y + +offset.y,
                                                     offset.z);

                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * camSpeed);
                */

                transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x + offset.x,
                                                    target.position.y + offset.y, offset.z) , Time.deltaTime * camSpeed);
                
                Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, zoomSize, Time.deltaTime * camSpeed);
            }
            else if (curCam == 2)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(targetClone.position.x + offset.x,
                                                  targetClone.position.y + offset.y, offset.z), Time.deltaTime * camSpeed);
                //Camera.main.orthographicSize = zoomSize;
                Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, zoomSize, Time.deltaTime * camSpeed);
            }
            else
            {
                Vector3 midpoint = (target.position + targetClone.position) / 2f;
                transform.position = Vector3.Lerp(transform.position, new Vector3(midpoint.x + offset.x, midpoint.y + offset.y, offset.z), 
                                                                                  Time.deltaTime * camSpeed);

                // Calculate the distance between the targets
                float distance = Vector3.Distance(target.position, targetClone.position);

                // Set camera size based on the distance between targets (with clamping)
                float newSize = Mathf.Clamp(distance + distanceOffset, minSize, maxSize);
                Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, newSize, Time.deltaTime * camSpeed);
            }
        }
    }
}
