using UnityEngine;

public class FlingObject : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 mousePressPosition;
    private float dragForce = 10f;
    public float maxVelocity = 25f;

    public Rigidbody2D secondCircleRigidbody;

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
    }
}