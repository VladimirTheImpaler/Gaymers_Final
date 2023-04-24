using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceScooperLogic : MonoBehaviour
{

    public GameObject spawnObject;
    public GameObject iceCube;
    public Vector3 objectSpawnlocation;
    public GameObject wallGate;

    public bool isPouring = false;
    public int grabTimer = 400;

    public GameObject wallsParent;

    public bool iceSpawnReady = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        grabTimer -= 1;

        isPouring = GetComponent<PourOnRotate>().isPouring;

        wallGate.GetComponent<MeshCollider>().enabled = false;

        if (grabTimer > 0)
        {

            wallGate.gameObject.SetActive(true);
        }
        else
        {

            wallGate.gameObject.SetActive(false);
        }
        
    }


    public void pickedUP()
    {

        grabTimer = 400;
    }

    public void dropped()
    {

        iceSpawnReady = true;
    }

    public void spawnIce()
    {

        objectSpawnlocation = spawnObject.GetComponent<Rigidbody>().position;

        if ((grabTimer > 0) && (iceSpawnReady))
        {

            GameObject newIce = Instantiate(iceCube, objectSpawnlocation, Quaternion.identity) as GameObject;
            iceSpawnReady = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("iceBucket"))
        {

            
            //AudioSource.PlayClipAtPoint(soundName, transform.position);
        }
        else
        {

            //AudioSource.PlayClipAtPoint(soundName, transform.position);
        }
    }   
    
}



