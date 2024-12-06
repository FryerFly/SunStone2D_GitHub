using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FutureGhost : MonoBehaviour
{
    //The future and past game objects
    public GameObject presentBody;
    public GameObject pastGhost;

    public bool isSelected;
    
    
    public float stepDistance = 1f;
    public float turnStep = 15f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isSelected)
        {
            if(Input.GetKeyDown("1")){CommandMove(Vector3.up, 20f);}
            
            if(Input.GetKeyDown("w")){transform.Translate(Vector3.up * stepDistance);}
            if(Input.GetKeyDown("a")){transform.Translate(Vector3.left * stepDistance);}
            if(Input.GetKeyDown("s")){transform.Translate(Vector3.down * stepDistance);}
            if(Input.GetKeyDown("d")){transform.Translate(Vector3.right * stepDistance);}

            if(Input.GetKeyDown("e")){transform.Rotate(Vector3.forward * -turnStep);};
            if(Input.GetKeyDown("q")){transform.Rotate(Vector3.forward * turnStep);};

            if(Input.GetKeyDown(KeyCode.Backspace)) 
            {
                transform.position = pastGhost.transform.position;
                transform.rotation = pastGhost.transform.rotation;
            }
        }
        
    }

    public void CommandMove(Vector3 direction, float magnitude)
    {
        transform.Translate(direction * magnitude);
    }

    public void CommandTurn(float magnitude)
    {
        transform.Rotate(Vector3.forward * magnitude);
    }
}
