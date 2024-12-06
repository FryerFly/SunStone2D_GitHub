using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalRaycaster : MonoBehaviour
{
    public float beamX;
    public float beamY;

    public float length;
    public float childLength;
    public float beamProductAngle;

    public Vector3 thirdDirection;
    Vector3 direction;
    public Vector3 otherDir;

    public GameObject beamChild_GO;
    BeamChild beamChild;

    // Start is called before the first frame update
    void Start()
    {
        beamChild = beamChild_GO.GetComponent<BeamChild>();
    }

    // Update is called once per frame
    void Update()
    {
        
        beamChild_GO.transform.localPosition = new Vector3(beamX, beamY, 0);
        
        
        direction = new Vector3(beamX, beamY, 0);

        beamProductAngle = Mathf.Atan2(beamY, beamX);
        otherDir = new Vector3(Mathf.Cos(beamProductAngle), Mathf.Sin(beamProductAngle), 0).normalized;

        thirdDirection = beamChild_GO.transform.position - transform.position;

        //otherDir = new Vector3(0, 0, 45); 

        length = Mathf.Sqrt(Mathf.Pow(beamX, 2) + Mathf.Pow(beamY, 2));
        childLength = Mathf.Sqrt(Mathf.Pow(beamChild_GO.transform.position.x, 2) + Mathf.Pow(beamChild_GO.transform.position.y, 2));

        Ray drawnRay = new Ray(transform.position, thirdDirection);

        if(Physics.Raycast(drawnRay.origin, drawnRay.direction, childLength))
        {
            Debug.Log("Oi, I'm walking here");
        } 

        //Debug.DrawRay(transform.position, new Vector3(beamX, beamY, 0), Color.green);
        Debug.DrawRay(drawnRay.origin, drawnRay.direction * childLength, Color.green);
    }
}
