using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupLogic : MonoBehaviour
{

    //public string cupList = {"air"};

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

            //add ice to cuplist if it doesnt already have it

            other.gameObject.SetActive(false);
            //AudioSource.PlayClipAtPoint(soundName, transform.position);
        }
        else if (other.gameObject.CompareTag("kegLiquid"))
        {

            //add liquid to cuplist if it doesnt already have it

            other.gameObject.SetActive(false);
            //AudioSource.PlayClipAtPoint(soundName, transform.position);
        }
        else if (other.gameObject.CompareTag("iceCube"))
        {

            //add liquid to cuplist if it doesnt already have it

            other.gameObject.SetActive(false);
            //AudioSource.PlayClipAtPoint(soundName, transform.position);
        }
        else
        {
            other.gameObject.SetActive(true);
        }
    }


}

