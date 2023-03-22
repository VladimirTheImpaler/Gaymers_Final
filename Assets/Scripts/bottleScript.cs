using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleScript : MonoBehaviour
{

    public GameObject liquidDrop;
    public GameObject bottleSpawnSphere;
    public Vector3 objectSpawnlocation = new Vector3(5f, 5f, 5f);

    //int timer = 10;

    // Start is called before the first frame update
    void Start()
    {


    }

    public void spawnBall()
    {

        //timer -= 1;

        //if (timer < 0)
        //{

            //timer = 10;
            //summon liquidBall
            GameObject newLiquid = Instantiate(liquidDrop, bottleSpawnSphere.GetComponent<Rigidbody>().position, Quaternion.identity) as GameObject;
        //}

    }

    // Update is called once per frame
    void Update()
    {


    }
}
