using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlingSlimeSimplify : MonoBehaviour
{
    //private Vector3 initialPosition;
    private Vector3 mousePressPosition;
    private float dragForce = 5f;
    public float maxVelocity = 20f;

    public SlimeScript slime1;
    public SlimeScript slime2;

    public LineRenderer dashLineRenderer;
    public float dashLineWidth = 0.2f;
    public float dashLineSpacing = 0.2f;

    public float minDragMag = 0.1f;

    public int parNum = 0;
    public bool dragging = false;

    public CircleCollider2D pTrigger;
    public CircleCollider2D oTrigger;


    private void Start()
    {
        // Set up LineRenderer properties
        dashLineRenderer.positionCount = 0;
        dashLineRenderer.startWidth = dashLineWidth;
        dashLineRenderer.endWidth = dashLineWidth;
    }

    private void Update()
    {
        // Check for touch or mouse events
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
        }
        else if (Input.GetMouseButton(0))
        {
            OnMouseDrag();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp();
        }

        if (slime1.bones.Count > 6 && slime1.bones[6] != null)
        {
            pTrigger.transform.position = slime1.bones[6].position;
        }
        if (slime2.bones.Count > 6 && slime2.bones[6] != null)
        {
            oTrigger.transform.position = slime2.bones[6].position;
        }
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            // Do nothing if the mouse is over a UI element
            return;
        }
        dragging = true;
        mousePressPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePressPosition.z = 0f;
        //initialPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        Vector3 mouseCurrentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseCurrentPosition.z = 0f;

        Vector3 dragDirection = mouseCurrentPosition - mousePressPosition;

        DrawDashLine();
    }

    private void DrawDashLine()
    {
        if (!dragging)
            return;

        Vector3[] positions = CalculateDashLinePositions();
        dashLineRenderer.positionCount = positions.Length;
        dashLineRenderer.SetPositions(positions);
    }

    private Vector3[] CalculateDashLinePositions()
    {
        Vector3[] positions = new Vector3[0];
        Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mousePressPosition).normalized;
        float distance = Vector3.Distance(mousePressPosition, Camera.main.ScreenToWorldPoint(Input.mousePosition));

        int numberOfDashes = Mathf.FloorToInt(distance / dashLineSpacing);
        positions = new Vector3[numberOfDashes * 2];

        for (int i = 0; i < numberOfDashes; i++)
        {
            float t = i / (float)numberOfDashes;
            positions[i * 2] = Vector3.Lerp(mousePressPosition, Camera.main.ScreenToWorldPoint(Input.mousePosition), t);
            positions[i * 2 + 1] = Vector3.Lerp(mousePressPosition, Camera.main.ScreenToWorldPoint(Input.mousePosition), t + dashLineSpacing / distance);
        }

        return positions;
    }

    private void OnMouseUp()
    {
        if (!dragging)
            return;

        Vector3 mouseReleasePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseReleasePosition.z = 0f;

        Vector3 dragDirection = mouseReleasePosition - mousePressPosition;
        Vector3 force = dragDirection * dragForce;

        Vector2 clampedVelocity = dragDirection.normalized * Mathf.Min(dragDirection.magnitude * dragForce, maxVelocity);

        if (dragDirection.magnitude > minDragMag)
        {
            List<Rigidbody2D> bones = slime1.bones;
            foreach (Rigidbody2D bone in bones)
            {
                bone.AddForce(force, ForceMode2D.Impulse);
                bone.velocity = clampedVelocity;
            }

            List<Rigidbody2D> bones2 = slime2.bones;
            foreach (Rigidbody2D bone in bones2)
            {
                bone.AddForce(force, ForceMode2D.Impulse);
                bone.velocity = clampedVelocity;
            }
        }
        parNum++;
        dashLineRenderer.positionCount = 0;
        dragging = false;
    }
}
