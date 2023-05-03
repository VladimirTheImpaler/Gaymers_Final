using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupLogic : MonoBehaviour
{

    public List<string> itemList = new List<string>();
    public GameObject drinkFinishZone;
    // add SFX variables here

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // MOVE THIS TO A DIFFERENT SCRIPT (CupReturn)
        if (drinkFinishZone.GetComponent<OrderCompleteLogic>().orderComplete == true) {
            // may need to unparent from hand if currently held
            // wait for a beat
            // poof effect, teleport cup to orginal position (reset velocity & rotation)
            // poof effect in front of customer, finished drink appears
        }
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
        else
        {
            //other.gameObject.SetActive(true);
        }

    }


}

