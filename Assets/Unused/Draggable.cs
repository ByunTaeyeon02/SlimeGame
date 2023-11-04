using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Draggable : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;
    private bool colided = false;
    /*
    private Transform dragObj = null;
    private var hit;
    private float length;

    void OnMouseEnter()
    {
        Debug.Log("inside");
        OnMouseDown();
    }

    void OnMouseExit()
    {
        Debug.Log("outside");
    }

    void Update()
    {
        //Debug.Log(isBeingHeld + "\n");
        if (isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            if (colided != true)
            {
                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
            } else
            {

            }
        }

        if (Input.GetMouseButton(0))
        {  // if left mouse button pressed...
           // cast a ray from the mouse pointer
            Vector2 ray = Input.mousePosition;
            if (!isBeingHeld)
            {  // if nothing picked yet...
               // and the ray hit some rigidbody...
                if (Physics.Raycast(ray, hit) && hit.rigidbody2D)
                {
                    dragObj = hit.transform;  // save picked object's transform
                    length = hit.distance;  // get "distance from the mouse pointer"
                }
            }
            else
            {  // if some object was picked...
               // calc velocity necessary to follow the mouse pointer
                var vel = (ray.GetPoint(length) - dragObj.position) * speed;
                // limit max velocity to avoid pass through objects
                if (vel.magnitude > maxSpeed) vel *= maxSpeed / vel.magnitude;
                // set object velocity
                dragObj.rigidbody.velocity = vel;
            }
        }
        else
        {  // no mouse button pressed
            dragObj = null;  // dragObj free to drag another object
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        colided = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        colided = false;
    }

    private void OnMouseDown()
    {
        //Debug.Log("peepeepoopoo" + "\n");
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse pressed down" + "\n");
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        Debug.Log("Mouse unpressed" + "\n");
        isBeingHeld = false;
    }
    */
}