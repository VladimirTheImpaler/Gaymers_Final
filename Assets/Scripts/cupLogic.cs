using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupLogic : MonoBehaviour
{

    //public Vector3 catapultLaunch = new Vector3(100.0f, 100.0f, 100.0f);
    bool hasIce = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("iceScooper"))
        {
            hasIce = true;

            //other.gameObject.SetActive(false);

            other.gameObject.transform.position = new Vector3(0, 3, 0);
            //AudioSource.PlayClipAtPoint(sliceSound, transform.position);
        }
        else
        {
            other.gameObject.SetActive(true);
        }
    }


}

