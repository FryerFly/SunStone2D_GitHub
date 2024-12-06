using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTarget : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         // Check for mouse button press
        if (Input.GetMouseButton(0))
        {
            // Raycast from the mouse position
            Vector2 mousePositionPress = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePositionPress, Vector2.zero);

            // Check if this object was hit
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging = true;
                offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

             // Release drag on mouse button up
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Move object if dragging
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;
        }
        }

        
    }

}
