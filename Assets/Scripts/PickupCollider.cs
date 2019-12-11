using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCollider : MonoBehaviour
{
    private Vector3 screenSpace;
    private Vector3 offset;
    private bool isHeld = false;
    private Rigidbody rb;
    private int maxReach = 2;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMouseDown()
    {
        if (Vector3.Distance(Camera.main.transform.position, this.transform.position) > maxReach)
        {
            return;
        }
        isHeld = true;
        screenSpace = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));

        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    public void OnMouseUp()
    {
        drop();
    }


    public void OnMouseDrag()
    {
        if (isHeld)
        {
            var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
            var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
            transform.position = curPosition;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (isHeld)
        {
            if (collision.contactCount > 1)
            {
                drop();
            }
        }
    }

    private void drop()
    {
        isHeld = false;
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;
    }
}
