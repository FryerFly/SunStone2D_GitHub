using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testWorld : MonoBehaviour
{
    public GameObject childObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = childObject.transform.position;
    }
}
