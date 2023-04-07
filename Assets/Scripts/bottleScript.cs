using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleScript : MonoBehaviour
{

    public GameObject spawnSphere;
    public GameObject liquidDrop;
    public Vector3 objectSpawnlocation;
    public bool isPouring = false;

    int timer = 10;

    // Start is called before the first frame update
    void Start()
    {


    }

    public void spawnBall()
    {

        objectSpawnlocation = spawnSphere.GetComponent<Rigidbody>().position;
        timer -= 1;

        if (timer < 0)
        {

            timer = 10;
            //summon liquidBall
            GameObject newLiquid = Instantiate(liquidDrop, objectSpawnlocation, Quaternion.identity) as GameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {


        isPouring = GetComponent<PourOnRotate>().isPouring;

        if (isPouring) {
            spawnBall();
        }
        
    }

}