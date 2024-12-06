using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncientStatue : MonoBehaviour
{
    //Holds the memory of the statue base
    GameObject statueBase;
    Statue_PA baseMover;

    //Holds the relative X and Y value, without this the program cannot differntiate between world position, local position, and internal positioning. 
    public float relativeX;
    public float relativeY;
    public float relativeZ; //relativeZ is a rotation.

    //holds the new relative positions to compare it to, to achieve the desired movement. 

    public float newRelativeX;
    public float newRelativeY;
    public float newRelativeZ; // relativeZ is a rotation value.

    //Holds stateLevel variables. The rotation values might be moved from this level to a lower one.
    

    //These variables are needed for the position update function to work. 
    //They hold a series of current, new, and starting X,Y coordinates that it uses for its approximately comparisons.
    
    private Vector3 currentPosition;
    public Vector3 newPosition;
    
    public float turnSpeed = 20f;
    public float moveSpeed = 1f;

    public float destinationX;
    public float currentX;
    public float startX;
    

    public float destinationY;
    public float currentY;
    public float startY; 



    // Start is called before the first frame update
    void Start()
    {
        //Without these the statue manager will not have accsess to the statue object which it moves.
        statueBase = transform.GetChild(1).gameObject;
        baseMover = statueBase.GetComponent<Statue_PA>();
    }

    // Update is called once per frame
    void Update()
    {
        TestInput();
        AutoTranslate();
    
        
        
    }

    void TestInput()
    {
        

        
        if(Input.GetKeyUp("space")){transform.Translate(10, 0, 0);}
        
        //Gives me basic translation based wasd functionality.
        if(Input.GetKey("w")){transform.Translate(0, 1 * moveSpeed * Time.deltaTime, 0);}
        if(Input.GetKey("s")){transform.Translate(0, -1 * moveSpeed * Time.deltaTime, 0);}
        if(Input.GetKey("a")){transform.Translate(1 * moveSpeed * Time.deltaTime, 0, 0);}
        if(Input.GetKey("d")){transform.Translate(-1 * moveSpeed * Time.deltaTime, 0, 0);}

        //Rotates the manager across the Z axis.
        if(Input.GetKey("q")){transform.Rotate(0, 0, 1 * turnSpeed * Time.deltaTime);}
        if(Input.GetKey("e")){transform.Rotate(0, 0, -1 * turnSpeed * Time.deltaTime);}

        
    }

    

    void AutoTranslate()
    {
        if(!Mathf.Approximately(relativeY, newRelativeY))
        {
            if(relativeY < newRelativeY)
            {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
                relativeY += moveSpeed * Time.deltaTime;
            }
            else if(relativeY > newRelativeY)
            {
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
                relativeY -= moveSpeed * Time.deltaTime;
            }
        }
        
        
        
    }

    //This makes the position change gradually over time as a function of its desitnation coordinates and moveSpeed variable. 
    /* void PositionUpdate()
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
        
    } */

    
}
