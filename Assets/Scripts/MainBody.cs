 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBody : MonoBehaviour
{
    //The future and past game objects
    public GameObject futureGhost;
    public GameObject pastGhost;

    FutureGhost futureGhost_SC;

    //the move and turn speed variables, adjust for a more readable game.
    private float moveSpeed = 10f;
    private float turnSpeed = 20f;

    
    //The variables for a sunstone beam graphics.
    public LineRenderer beamRender;
    
    //Variables and types involved in the sunbeam raycast. The beamchild is the position the beam is firing towards
    public GameObject beamChild_GO;
    BeamChild beamChild_SC;
    
    
    //Ultimate variables for all Sunbeam functionality.
    public float beamX;
    public float beamY;

    public float inBeamX;
    public float inBeamY;

    public float stoneBeamX;
    public float stoneBeamY;
    
    

    //The ray components driving the raycast, debug, and linerenderer components. The rayhit component contains the information about what is being hit.
    Ray2D statueRay;

    
    //The script of the main body, needs a compare tag operation to not get repeated non-assinged object errors.
    MainBody hitBody_SC;
    public bool isBeamedAt;
    public bool hasHit;

    //Here comes an array of objects that are currently hitting the object with their raycasts.
    public List<GameObject> beamList = new List<GameObject>();
    public int listLength;


    // Start is called before the first frame update
    void Start()
    {
        //Assigns the future and child scripts
        futureGhost_SC = futureGhost.GetComponent<FutureGhost>();
        beamChild_SC = beamChild_GO.GetComponent<BeamChild>();

        //Gets the collider needed for the Raycast function.
        thisCollider = GetComponent<Collider2D>();

        
    }

    // Update is called once per frame
    void Update()
    {

        
        AutoBeamListManager();
        BeamCalculator();
        listLength = beamList.Count;
        
        /* if(listLength != beamList.Count){BeamCalculator();}
        listLength = beamList.Count; */
        
        

        AutoTranslate();
        AutoRotate();

        AutoBeamChild();
        AutoBeam2D();
        
    }

    //This method is called by the collision between a command stone and the main body, and sends appropriate calls to the future, and past ghosts.
    //The Command Stone Protocol need a stone type, and Integer value that determines the type of stone.
    public void CommandStoneProtocol(stoneTypes inType, float magnitude)
    {
        Debug.Log("Command Protocol Active ");

        if(inType == stoneTypes.xMoveStone)
        {
            Debug.Log("translating body in X by " + magnitude);
            futureGhost_SC.CommandMove(Vector3.right, magnitude);
        }

        if(inType == stoneTypes.yMoveStone)
        {
            Debug.Log("translating body in Y by " + magnitude);
            futureGhost_SC.CommandMove(Vector3.up, magnitude);
        }

         if(inType == stoneTypes.zSpinStone)
        {
            Debug.Log("Rotating body in Z by " + magnitude);
            futureGhost_SC.CommandTurn(magnitude);
        }
        
        //What happens if a Beam Stone hits it. 
        
        else{Debug.Log("Stone Error");}

        
    }

    void OnMouseDown()
    {
        if(!futureGhost_SC.isSelected){futureGhost_SC.isSelected = true;}
        else if(futureGhost_SC.isSelected){futureGhost_SC.isSelected = false;}
  
    }

    //Automatically matches the position of the future ghost and procedurally animates towards it.
    void AutoTranslate()
    {
        transform.position = Vector2.Lerp(transform.position, futureGhost.transform.position, moveSpeed * Time.deltaTime);
        if(Vector2.Distance(transform.position, futureGhost.transform.position) < 0.1f){transform.position = futureGhost.transform.position;}
    }

    //Automatically matches the rotation of the future ghost and procedurally animates towards it.
    void AutoRotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, futureGhost.transform.rotation, turnSpeed * Time.deltaTime);
    }

    //The collider that emits the 2DRaycast. The actuall collider is assigned in the start method.
    Collider2D thisCollider;
    
    RaycastHit2D[] rayHits = new RaycastHit2D[1];
    Vector2 rayDirection;
    
    
    //This method calculates the length, direction, and hit of the 2D raycast. I needs a defined collider to emit from and a beam child to hit through.
    void AutoBeam2D()
    {
        rayDirection = (beamChild_GO.transform.position - transform.position).normalized;
        Debug.DrawRay(transform.position, rayDirection * ChildLength(beamChild_GO.transform), Color.red);

        //Acquires the number of elligible cooliders it. and puts in in the rayHits array (can maximum hit two objects.)
        int numHits = thisCollider.Raycast(rayDirection, rayHits, ChildLength(beamChild_GO.transform));

        //Compares the tag of the first item in the rayHit array. If it is a statue, and the ray hasn't hit anything else, then it will print its name and set the hasHit to true.
        if(numHits > 0 && rayHits[0].collider.CompareTag("Statue") && !hasHit)
        {
            Debug.Log(rayHits[0].collider.name);
            hitBody_SC = rayHits[0].collider.gameObject.GetComponent<MainBody>();
            hitBody_SC.beamList.Add(gameObject);


            
            hitBody_SC.isBeamedAt = true;
            hasHit = true;
        }

        else if(numHits == 0 && hasHit)
        {
            hitBody_SC.isBeamedAt = false;
            hasHit = false;
        } 
        
        //if it is not currently hitting anythig the hasHit is false and the beam goes back to red. 

        if(hasHit)//if the hasHit bool is true, then the debug beam becomes green.
        {
            Debug.DrawRay(transform.position,rayDirection * ChildLength(beamChild_GO.transform), Color.green);
        }
            
            
            
            //Figures out the distance to the child with basic Trig. Requires a child object, and that the object is in the first generation.
            float ChildLength(Transform target)
        {
            float distX = Mathf.Pow(target.localPosition.x, 2);
            float distY = Mathf.Pow(target.localPosition.y, 2);
            float length = Mathf.Sqrt(distX + distY);

            return length;
        }

    }

    void AutoBeamListManager()
    {
        for(int i = 0; i < beamList.Count; i++)
        {
            MainBody listScript;
            listScript = beamList[i].GetComponent<MainBody>();
            if(!listScript.hasHit)
            {
                beamList.Remove(beamList[i]);
            }
        }
    }

    void BeamCalculator()
    {

        for(int i = 0; i < beamList.Count; i++)
        {
            MainBody listScript;
            listScript = beamList[i].GetComponent<MainBody>();

            inBeamX += listScript.beamX;
            inBeamY += listScript.beamY;

            
        }

        
        if(listLength != beamList.Count)
        {
            Debug.Log(inBeamX);
            Debug.Log(inBeamY);
        }
        

        

    }

    void AutoBeamChild()
    {
        if(!isBeamedAt)
        {
            inBeamX = 0f;
            inBeamY = 0f;
        }
        
        beamX = inBeamX + stoneBeamX;
        beamY = inBeamY + stoneBeamY;
        
        
        beamChild_GO.transform.localPosition = new Vector2(beamX, beamY);
    }


}
