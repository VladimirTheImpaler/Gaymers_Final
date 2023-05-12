using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleScript : MonoBehaviour
{

    public GameObject spawnSphere;
    public GameObject liquidDrop;
    public Vector3 objectSpawnlocation;
    public AudioClip liquidSpawn_SFX;

    public bool isPouring = false;
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
            AudioSource.PlayClipAtPoint(liquidSpawn_SFX, transform.position);
        }

    }

    // Update is called once per frame
    void Update()
    {

        isPouring = GetComponent<PourOnRotate>().isPouring;

        if (isPouring) 
        {
            spawnBall();
        }
        
    }

}