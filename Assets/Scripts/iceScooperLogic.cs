using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceScooperLogic : MonoBehaviour
{

    public GameObject spawnObject;
    public GameObject iceCube;
    public Vector3 objectSpawnlocation;

    public bool dropped = true;
    public bool isPouring = false;
    public bool hasIce = false;
    public bool wallsActive = true;
    public int grabTimer = 0;

    public GameObject wallsParent;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        isPouring = GetComponent<PourOnRotate>().isPouring;
        spawnIce();


        if (!wallsActive)
        {
            wallsParent.SetActive(false);
        }
        else
        {
            wallsParent.SetActive(true);
        }

        if (grabTimer < 0)
        {
            wallsActive = false;
        }
        else
        {
            wallsActive = true;
        }

    }

    public void grabbed()
    {

        grabTimer = 100;
        dropped = false;
    }

    public void ungrabbed()
    {

        grabTimer = 100;
        dropped = true;
    }
    public void inHand()
    {

        grabTimer -= 1;
        dropped = true;
    }

    public void spawnIce()
    {
        if (dropped)
        {

        }
        objectSpawnlocation = spawnObject.GetComponent<Rigidbody>().position;

        GameObject newIce = Instantiate(iceCube, objectSpawnlocation, Quaternion.identity) as GameObject;
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



