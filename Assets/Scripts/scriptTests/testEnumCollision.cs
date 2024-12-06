using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEnumCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something Hit me!");
        GameObject offendingObject = other.gameObject;
        Debug.Log("Bestagon is offended by " + offendingObject.name);
        enumTest enumTest_SC = offendingObject.GetComponent<enumTest>();

        Debug.Log(enumTest_SC.thisTriangle);

        if(enumTest_SC.thisTriangle == triangle.nonEuclidiean)
        {
            Debug.Log("Paralell lines will converge");
        } else {Debug.Log("paralell lines will never meet");}

    }
}
