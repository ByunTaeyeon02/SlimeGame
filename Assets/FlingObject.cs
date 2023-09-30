using UnityEngine;

public class FlingObject : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 mousePressPosition;
    private float dragForce = 10f;

    private void OnMouseDown()
    {
        initialPosition = transform.position;
        mousePressPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePressPosition.z = 0f;
    }

    private void OnMouseUp()
    {
        Vector3 mouseReleasePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseReleasePosition.z = 0f;

        Vector3 dragDirection = mouseReleasePosition - mousePressPosition;
        Vector3 force = dragDirection * dragForce;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}