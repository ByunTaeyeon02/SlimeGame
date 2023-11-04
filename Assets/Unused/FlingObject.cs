using UnityEngine;
using UnityEngine.UI;

public class FlingObject : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 mousePressPosition;
    private float dragForce = 5f;
    public float maxVelocity = 25f;

    public Rigidbody2D secondCircleRigidbody;

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

        // Limit the velocity of the first circle object
        Vector2 clampedVelocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
        rb.velocity = clampedVelocity;

        if (secondCircleRigidbody != null)
        {
            secondCircleRigidbody.AddForce(force, ForceMode2D.Impulse);
            Vector2 clampedSecondCircleVelocity = Vector2.ClampMagnitude(secondCircleRigidbody.velocity, maxVelocity);
            secondCircleRigidbody.velocity = clampedSecondCircleVelocity;
        }

        dashLineRenderer.positionCount = 0;
    }
}