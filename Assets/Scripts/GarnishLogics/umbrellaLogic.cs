using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class umbrellaLogic : MonoBehaviour
{


    public GameObject mainumbrella;
    public GameObject mainumbrellaBall;
    public GameObject cupColliderDisk;
    public GameObject umbrellaOnDrink;
    public GameObject umbrellaBallOnDrink;
    public AudioClip confirmSFX;

    public List<string> itemList;

    public bool inHand = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        itemList =  cupColliderDisk.GetComponent<cupLogic>().itemList;

        if (this.GetComponent<Rigidbody>().isKinematic && !inHand)
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            mainumbrellaBall.gameObject.GetComponent<MeshRenderer>().enabled = true;
            //AudioSource.PlayClipAtPoint(soundName, transform.position);
        }
    }

    public void pickedUpObject()
    {

        inHand = true;
    }

    public void droopedObject()
    {

        inHand = false;
    }

    public void heldObject()
    {


    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("garnishCollider"))
        {
            if (!inHand)
            {
                if (!itemList.Contains("garnishCollider")) { // may need to change this to only ding when correct ingredient is added
                AudioSource.PlayClipAtPoint(confirmSFX, transform.position);
                }

                cupColliderDisk.GetComponent<cupLogic>().itemList.Add("umbrella");

                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                mainumbrellaBall.gameObject.GetComponent<MeshRenderer>().enabled = false;

                umbrellaOnDrink.gameObject.GetComponent<MeshRenderer>().enabled = true;
                umbrellaBallOnDrink.gameObject.GetComponent<MeshRenderer>().enabled = true;
                //other.gameObject.SetActive(false);
                //AudioSource.PlayClipAtPoint(soundName, transform.position);
            }
        }
    }
}
