using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMover : MonoBehaviour
{
    public GameObject target;

    public Vector3 targetPosition;
    public Vector3 lastDirection;
    public Vector3 direction;

    public Vector2 destination;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = target.transform.position;
        direction = (transform.position - targetPosition);

        destination = targetPosition;

        if(lastDirection != direction)
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.down, direction);
            Debug.Log("Aim adjusted.");
        }

        transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime);
        lastDirection = direction;
    }
}
