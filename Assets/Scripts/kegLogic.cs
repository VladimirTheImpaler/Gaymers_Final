using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kegLogic : MonoBehaviour
{

    public GameObject spawnSphere;
    public GameObject liquidDrop;
    public Vector3 objectSpawnlocation;
    public AudioClip kegLiquidSpawn_SFX;

    int timer = 2;

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

        timer = 2;
        //summon liquidBall
        GameObject newLiquid = Instantiate(liquidDrop, objectSpawnlocation, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(kegLiquidSpawn_SFX, transform.position);
        }
        
    }

    // Update is called once per frame
    void Update()
    {


    }
}
