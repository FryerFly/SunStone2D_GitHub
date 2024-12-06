using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float globalScaleFactor = 10f;
    
    //Here lies memories of what kinds of prefabs the level will hold.
    public Transform globalScale;
    public GameObject statue_prefab;
    public GameObject commandStone_prefab;
    public GameObject winPlatform;
    public GameObject winEye;

    //Level Specific Objects, Withotu this there is no difference between the actual instantiated object, and their prefabs
    public GameObject statueA_GO;
    public GameObject statueB_GO;
    public GameObject statueC_GO;

    //Here goes all the instanced winPlatforms and winEyes;
    public GameObject winPlatA_GO;
    WinPlatform winPlatA_SC;

    public GameObject winPlatB_GO;
    WinPlatform winPlatB_SC;

    /* public GameObject winPlatB_GO;
    WinPlatform winPlatB_SC; */




    // Start is called before the first frame update
    void Start()
    {
        
        /* statueA_GO = SpawnStatue("Statue A", 0, 0, 0, globalScale);
        statueB_GO = SpawnStatue("Statue B", -2, 0, 0, statueA_GO.transform.GetChild(0));
        statueC_GO = SpawnStatue("Statue C", 2, 0, 0, statueA_GO.transform.GetChild(0));

        winPlatA_GO = SpawnWinPlatform("winPlatA", 2, 2, globalScale);
        winPlatA_SC = winPlatA_GO.GetComponent<WinPlatform>();

        winPlatB_GO = SpawnWinPlatform("winPlatB", -2, -2, globalScale);
        winPlatB_SC = winPlatB_GO.GetComponent<WinPlatform>(); */


    }

    // Update is called once per frame
    void Update()
    {
        /* if(winPlatA_SC.hasStatue && winPlatB_SC.hasStatue)
        {
            Debug.Log("You win the game");
        } */
    }

    GameObject SpawnStatue(string spawnName, float xPos, float yPos, float zRot, Transform parent)
    {
        GameObject spawnedObject;
        spawnedObject = Instantiate(statue_prefab, (parent.position + new Vector3(xPos * globalScaleFactor, yPos * globalScaleFactor, 0)),Quaternion.identity, parent);
        spawnedObject.name = spawnName;
        spawnedObject.transform.Rotate(0, 0, zRot);

        return spawnedObject;
    }

    GameObject SpawnWinPlatform(string platName, float xPos, float yPos, Transform parent)
    {
        GameObject spawnedPlatform;
        spawnedPlatform = Instantiate(winPlatform, new Vector3(xPos * globalScaleFactor, yPos * globalScaleFactor, 0f), Quaternion.identity, parent);
        spawnedPlatform.name = platName;

        
        
        return spawnedPlatform;
    }

    GameObject SpawnCommandStone(string stoneName, float xPos, float yPos, Transform parent)
    {
        GameObject spawnedStone;
        spawnedStone = Instantiate(commandStone_prefab, new Vector3(xPos * globalScaleFactor, yPos * globalScaleFactor, 0f), Quaternion.identity, parent);

        return spawnedStone;
        
    }
}
