using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCamAspect : MonoBehaviour
{
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
}
