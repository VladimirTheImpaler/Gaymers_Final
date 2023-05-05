using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cherryLogic : MonoBehaviour
{

    public GameObject mainCherry;
    public GameObject cupColliderDisk;
    public GameObject cherryOnDrink;

    public bool inHand = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



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
                cupColliderDisk.GetComponent<cupLogic>().itemList.Add("cherry");

                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                cherryOnDrink.gameObject.GetComponent<MeshRenderer>().enabled = true;
                //other.gameObject.SetActive(false);
                //AudioSource.PlayClipAtPoint(soundName, transform.position);
            }
        }else if (other.gameObject.CompareTag("cherryStartCube"))
        {

            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
