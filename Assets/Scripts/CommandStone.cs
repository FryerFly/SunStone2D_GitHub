using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandStone : MonoBehaviour
{
    
    //These are all the major editable variables for the command stone to function. They get called in the CommandStone Protocol to create movement.
    public stoneTypes thisStone = stoneTypes.nullStone;
    public float magnitude;
    public float direction;
    public float xValue;
    public float yValue;
    
    

    
    // holds a boolean value whether or not the object is being dragged. 
    public bool isDragging = false;
    
    //A vector offset to make the object drag on the correct zDepth and XY coordinate. 
    private Vector2 offset;

    //Holds the SpriteRenderer memory so that StoneMorph can function and the graphic can be changed based on enum type.
    SpriteRenderer stoneSprite;

    // Start is called before the first frame update
    void Start()
    {
        //Accesses the sprite renderer, without this the stoneMorph method will not be able to change the stone color.
        stoneSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //DragMove();
        
        if(Input.GetMouseButtonUp(0)){isDragging = false;}
        //if(!isDragging){stoneSprite.color = new Vector4(1, 0, 0, 1);}

        StoneMorph();

        
        
    }

    void OnMouseDrag()
    {
        stoneSprite.color += Color.white * Time.deltaTime;
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mouseScreenPosition;
        isDragging = true;

    }

    
    // StoneMorph is a simple graphic changing method that changes how the sprite is rendered, each element can be replaced with a Vector4 for more accurate and appealing color rendering.
    void StoneMorph()
    {
        if(thisStone == stoneTypes.nullStone){stoneSprite.color = Color.white;}
        if(thisStone == stoneTypes.xMoveStone){stoneSprite.color = Color.red;}
        if(thisStone == stoneTypes.yMoveStone){stoneSprite.color = Color.green;}
        if(thisStone == stoneTypes.zSpinStone){stoneSprite.color = Color.blue;}
        if(thisStone == stoneTypes.beamStone){stoneSprite.color = Color.yellow;}
        
    }


    // This method is called automatically by Unity when another object enters this trigger
    // Make sure one of the objects has a Rigidbody2D
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.CompareTag("Statue"))
        {
        
        // The 'other' parameter contains information about the triggering object
        // Get the GameObject that entered the trigger
        GameObject triggeringObject = other.gameObject;
        MainBody mainbody = triggeringObject.GetComponent<MainBody>();

        // Log the name of the triggering object for debugging
        Debug.Log("Triggered by: " + triggeringObject.name);

        //futureObject_SC.CommandMove(Vector3.right, 20);
        mainbody.CommandStoneProtocol(thisStone, magnitude);
        gameObject.SetActive(false);

        }
        
        
        
           
    }

}

//This enumeration holds the various stone types. Without this no statue movement or CommandStone interaction or graphic change will occur.
//This enumeration is above class level so that it can be accessed by every script, without calling on any individual Command Stone.
public enum stoneTypes 
{
    nullStone,
    xMoveStone,
    yMoveStone,
    zSpinStone,
    beamStone,
    
}
