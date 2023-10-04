using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlingSlime : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 mousePressPosition;
    private float dragForce = 5f;
    public float maxVelocity = 25f;

    public Rigidbody2D bone1;
    public Rigidbody2D bone2;
    public Rigidbody2D bone3;
    public Rigidbody2D bone4;
    public Rigidbody2D bone5;
    public Rigidbody2D bone6;

    public Rigidbody2D centerBone2;
    public Rigidbody2D bone12;
    public Rigidbody2D bone22;
    public Rigidbody2D bone32;
    public Rigidbody2D bone42;
    public Rigidbody2D bone52;
    public Rigidbody2D bone62;

    public LineRenderer dashLineRenderer;
    public float dashLineWidth = 0.2f;
    public float dashLineSpacing = 0.2f;

    private void Start()
    {
        // Set up LineRenderer properties
        dashLineRenderer.positionCount = 0;
        dashLineRenderer.startWidth = dashLineWidth;
        dashLineRenderer.endWidth = dashLineWidth;
    }

    private void OnMouseDown()
    {
        initialPosition = transform.position;
        mousePressPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePressPosition.z = 0f;
    }

    private void OnMouseDrag()
    {
        Vector3 mouseCurrentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseCurrentPosition.z = 0f;

        Vector3 dragDirection = mouseCurrentPosition - initialPosition;

        DrawDashLine();
    }

    private void DrawDashLine()
    {
        Vector3[] positions = CalculateDashLinePositions();
        dashLineRenderer.positionCount = positions.Length;
        dashLineRenderer.SetPositions(positions);
    }

    private Vector3[] CalculateDashLinePositions()
    {
        Vector3[] positions = new Vector3[0];
        Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - initialPosition).normalized;
        float distance = Vector3.Distance(initialPosition, Camera.main.ScreenToWorldPoint(Input.mousePosition));

        int numberOfDashes = Mathf.FloorToInt(distance / dashLineSpacing);
        positions = new Vector3[numberOfDashes * 2];

        for (int i = 0; i < numberOfDashes; i++)
        {
            float t = i / (float)numberOfDashes;
            positions[i * 2] = Vector3.Lerp(initialPosition, Camera.main.ScreenToWorldPoint(Input.mousePosition), t);
            positions[i * 2 + 1] = Vector3.Lerp(initialPosition, Camera.main.ScreenToWorldPoint(Input.mousePosition), t + dashLineSpacing / distance);
        }

        return positions;
    }

    private void OnMouseUp()
    {
        Vector3 mouseReleasePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseReleasePosition.z = 0f;

        Vector3 dragDirection = mouseReleasePosition - initialPosition;
        Vector3 force = dragDirection * dragForce;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(force, ForceMode2D.Impulse);

        Vector2 clampedVelocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
        rb.velocity = clampedVelocity;

        Rigidbody2D[] bones = new Rigidbody2D[] { bone1, bone2, bone3, bone4, bone5, bone6 };
        for (int i = 0; i < bones.Length; i++)
        {
            bones[i].GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
            bones[i].GetComponent<Rigidbody2D>().velocity = clampedVelocity;
        }

        if (centerBone2 != null)
        {
            centerBone2.AddForce(force, ForceMode2D.Impulse);

            Vector2 clampedSecondCircleVelocity = Vector2.ClampMagnitude(centerBone2.velocity, maxVelocity);
            centerBone2.velocity = clampedSecondCircleVelocity;

            Rigidbody2D[] bones2 = new Rigidbody2D[] { bone12, bone22, bone32, bone42, bone52, bone62 };
            for (int i = 0; i < bones2.Length; i++)
            {
                bones2[i].GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
                bones2[i].GetComponent<Rigidbody2D>().velocity = clampedVelocity;
            }
        }

        dashLineRenderer.positionCount = 0;
    }
}