using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceScooperLogic : MonoBehaviour
{

    public GameObject iceScooperParent;
    public GameObject spawnObject;
    public GameObject iceCube;
    public Vector3 objectSpawnlocation;
    public GameObject wallGate;
    public GameObject tempIceCube;

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

        isPouring = GetComponent<SCPRPourOnRotate>().isPouring;

        //wallGate.SetActive(false);

        tempIceCube.SetActive(true);

        if (grabTimer > 0)
        {

            wallGate.gameObject.SetActive(true);
        }
        else
        {

            wallGate.gameObject.SetActive(false);
        }

        if (isPouring)
        {

            spawnIce();
            wallGate.active = false;
        }
        else
        {

            wallGate.active = true;
        }
        
    }

    public void pickedUP()
    {

        grabTimer = 400;
        tempIceCube.SetActive(true);
        iceScooperParent.GetComponent<Rigidbody>().useGravity = false;
    }

    public void dropped()
    {

        iceSpawnReady = true;
        tempIceCube.SetActive(false);
        iceScooperParent.GetComponent<Rigidbody>().useGravity = true;
    }

    public void held() 
    {

        tempIceCube.SetActive(true);
    }

    public void spawnIce()
    {


            tempIceCube.SetActive(false);

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



