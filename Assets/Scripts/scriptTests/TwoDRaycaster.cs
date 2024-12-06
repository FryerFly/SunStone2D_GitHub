using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDRaycaster : MonoBehaviour
{
    public GameObject beamChild;
    public Vector2 rayAngle;

    Collider2D thisCollider;
    RaycastHit2D[] rayHits = new RaycastHit2D[2];

    public int rayCastInt;
    

    // Start is called before the first frame update
    void Start()
    {
        thisCollider = GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rayAngle = (beamChild.transform.position - transform.position);
        Debug.DrawRay(transform.position,rayAngle, Color.red);

        int numHits = thisCollider.Raycast(rayAngle, rayHits, ChildLength(beamChild.transform));

        if(numHits > 0 && rayHits[0].collider.CompareTag("Statue"))
        {
            Debug.DrawRay(transform.position,rayAngle, Color.green);
            Debug.Log(rayHits[0].collider.name);
            //Debug.Log(rayHits[1].collider.name);
        }
        
    }

    float ChildLength(Transform target)
    {
         float distX = Mathf.Pow(target.position.x, 2);
         float distY = Mathf.Pow(target.position.y, 2);
         float length = Mathf.Sqrt(distX + distY);

         return length;
    }
}
