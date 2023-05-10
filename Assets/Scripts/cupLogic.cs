using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupLogic : MonoBehaviour
{

    public List<string> itemList = new List<string>();
    public AudioClip confirmSFX;
    
    // add SFX variables here

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
            if (!itemList.Contains("iceCube")) { // may need to change this to only ding when correct ingredient is added
                AudioSource.PlayClipAtPoint(confirmSFX, transform.position);
            }

            itemList.Add("iceCube");

            other.gameObject.SetActive(false);
            //AudioSource.PlayClipAtPoint(soundName, transform.position);

            
        }
        else if (other.gameObject.CompareTag("kegLiquid"))
        {
            if (!itemList.Contains("kegLiquid")) {
                AudioSource.PlayClipAtPoint(confirmSFX, transform.position);
            }

            itemList.Add("kegLiquid");

            other.gameObject.SetActive(false);
            //AudioSource.PlayClipAtPoint(soundName, transform.position);

            
        }
        else if (other.gameObject.CompareTag("appleJuice"))
        {
            if (!itemList.Contains("appleJuice")) {
                AudioSource.PlayClipAtPoint(confirmSFX, transform.position);
            }

            itemList.Add("appleJuice");

            other.gameObject.SetActive(false);
            //AudioSource.PlayClipAtPoint(soundName, transform.position);

            
        }
        else if (other.gameObject.CompareTag("iceShard"))
        {
            if (!itemList.Contains("iceShard")) {
                AudioSource.PlayClipAtPoint(confirmSFX, transform.position);
            }

            itemList.Add("iceShard");

            other.gameObject.SetActive(false);
            //AudioSource.PlayClipAtPoint(soundName, transform.position);

            
        }
        else if (other.gameObject.CompareTag("tonic"))
        {

            itemList.Add("tonic");

            other.gameObject.SetActive(false);
            //AudioSource.PlayClipAtPoint(soundName, transform.position);
        }
        else
        {
            //other.gameObject.SetActive(true);
        }

    }


}

