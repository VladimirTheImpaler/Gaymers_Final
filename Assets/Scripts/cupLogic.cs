using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupLogic : MonoBehaviour
{

    public List<string> itemList = new List<string>();
    public GameObject iceScooper;

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

        if (other.gameObject.CompareTag("iceCube"))
        {

            itemList.Add("iceCube");

            other.gameObject.SetActive(false);
            //AudioSource.PlayClipAtPoint(soundName, transform.position);
        }
        else if (other.gameObject.CompareTag("kegLiquid"))
        {

            itemList.Add("kegLiquid");

            other.gameObject.SetActive(false);
            //AudioSource.PlayClipAtPoint(soundName, transform.position);
        }
        else if (other.gameObject.CompareTag("appleJuice"))
        {

            itemList.Add("appleJuice");

            other.gameObject.SetActive(false);
            //AudioSource.PlayClipAtPoint(soundName, transform.position);
        }
        else if (other.gameObject.CompareTag("iceScooper"))
        {

            itemList.Add("scoopIce");

            //iceScooper.
            iceScooper.GetComponent<iceScooperLogic>().hasIce = false;
            //AudioSource.PlayClipAtPoint(soundName, transform.position);
        }
        else
        {
            other.gameObject.SetActive(true);
        }

    }


}

