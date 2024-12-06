using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue_PA : MonoBehaviour
{
    public Vector3 currentPosition;
    public Vector3 newPosition;

    public float moveSpeed = 3f;

    public float destinationX;
    public float currentX;
    public float startX;
    

    public float destinationY;
    public float currentY;
    public float startY;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        //ProceduralMove();

        //smoothly updates the position of the statue when the newPosition vector3 is changed.
        PositionUpdate();

        

        
    }

    void ProceduralMove()
    {
        if(transform.localPosition.x < newPosition.x){transform.Translate(1 * Time.deltaTime * moveSpeed, 0, 0);}
        else if (transform.localPosition.x > newPosition.x){transform.Translate(-1 * Time.deltaTime * moveSpeed, 0, 0);}
        if(transform.localPosition.y < newPosition.y){transform.Translate(0, 1 * Time.deltaTime * moveSpeed, 0);}
        else if(transform.localPosition.y > newPosition.y){transform.Translate(0, -1 * Time.deltaTime * moveSpeed, 0);}
    }

    //This makes the position change gradually over time as a function of its desitnation coordinates and moveSpeed variable. 
    void PositionUpdate()
    {
        //Wihout this it cannot move in the X axis
        if(!Mathf.Approximately(transform.localPosition.x, newPosition.x))
        {
            destinationX = newPosition.x;
            currentX = Mathf.MoveTowards(currentX, destinationX, moveSpeed * Time.deltaTime);

            transform.localPosition = new Vector3 (currentX, currentY, 0);
            Debug.Log(currentX);
        }

        //Without this it cannot move in the Y axis.
        if(!Mathf.Approximately(transform.localPosition.y, newPosition.y))
        {
            destinationY = newPosition.y;
            currentY = Mathf.MoveTowards(currentY, destinationY, moveSpeed * Time.deltaTime);
            
            transform.localPosition = new Vector3 (currentX, currentY, 0);
            Debug.Log(currentY);
        }
        
    }
}
