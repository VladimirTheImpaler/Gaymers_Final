using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceScooperLogic : MonoBehaviour
{

    public GameObject spawnObject;
    public GameObject iceCube;
    public Vector3 objectSpawnlocation;
    public GameObject wallGate;
    public GameObject tempIceCube;
    public GameObject iceScooper;

    public bool isPouring = false;

    public GameObject wallsParent;

    public bool iceSpawnReady;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        isPouring = GetComponent<SCPR_PourOnRotate>().isPouring;

        wallGate.GetComponent<MeshCollider>().enabled = false;
        
    }


    public void pickedUP()
    {

        iceScooper.GetComponent<Rigidbody>().useGravity = false;
        tempIceCube.gameObject.SetActive(true);
        iceSpawnReady = true;
    }

    public void dropped()
    {

        iceScooper.GetComponent<Rigidbody>().useGravity = true;
        tempIceCube.gameObject.SetActive(false);
        iceSpawnReady = true;
    }

    public void spawnIce()
    {

        tempIceCube.gameObject.SetActive(false);

        objectSpawnlocation = spawnObject.GetComponent<Rigidbody>().position;

        if (iceSpawnReady && isPouring)
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



