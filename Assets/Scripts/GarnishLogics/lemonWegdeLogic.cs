using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lemonWegdeLogic : MonoBehaviour
{

    public GameObject mainLemon;
    public GameObject cupColliderDisk;
    public GameObject lemonOnDrink;
    public AudioClip confirmSFX;

    public bool inHand = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (this.GetComponent<Rigidbody>().isKinematic && !inHand)
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
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

                cupColliderDisk.GetComponent<cupLogic>().itemList.Add("lemon");

                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                lemonOnDrink.gameObject.GetComponent<MeshRenderer>().enabled = true;
                //other.gameObject.SetActive(false);
                //AudioSource.PlayClipAtPoint(soundName, transform.position);
            }
        }
    }
}
