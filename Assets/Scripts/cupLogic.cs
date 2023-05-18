using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupLogic : MonoBehaviour
{
    public GameObject cupColliderDisk;

    public List<string> itemList = new List<string>();
    public AudioClip confirmSFX;
    public GameObject iceMaterial;
    public GameObject kegMaterial;
    public GameObject appleMaterial;
    public GameObject iceShardMaterial;
    public GameObject tonicMaterial;

    private List<string> purpleIce = new List<string>() { "kegLiquid" , "iceCube" , "appleJuice" };
    private List<string> liquidApple = new List<string>() { "appleJuice" , "tonic" , "iceCube" };
    private List<string> cubeJuice = new List<string>() { "iceCube" , "shavedIce" , "appleJuice" };
    private List<string> appleSmoothie = new List<string>() { "appleJuice" , "shavedIce" , "kegLiquid" };
    private List<string> kegTonic = new List<string>() { "kegLiquid" , "tonic" , "shavedIce" };
    private List<string> everythingSmoothie = new List<string>() { "tonic" , "kegLiquid" , "appleJuice" , "shavedIce" };

    // add SFX variables here

    // Start is called before the first frame update
    void Start()
    {

        itemList.Add("kegLiquid");
        itemList.Add("appleJuice");
        itemList.Add("iceCube");
        itemList.Add("shavedIce");
        itemList.Add("tonic");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setMaterialOff()
    {

        iceMaterial.SetActive(false);
        kegMaterial.SetActive(false);
        appleMaterial.SetActive(false);
        iceShardMaterial.SetActive(false);
        tonicMaterial.SetActive(false);
    }
    
    private bool isCorrectIngredient(string ingredient, string drink) {

        if (drink == "purpleIce") {
            if (purpleIce.Contains(ingredient)) {
                return true;
            } else {
                return false;
            }
        }
        if (drink == "liquidApple") {
            if (liquidApple.Contains(ingredient)) {
                return true;
            } else {
                return false;
            }
        }
        if (drink == "cubeJuice") {
            if (cubeJuice.Contains(ingredient)) {
                return true;
            } else {
                return false;
            }
        }
        if (drink == "appleSmoothie") {
            if (appleSmoothie.Contains(ingredient)) {
                return true;
            } else {
                return false;
            }
        }
        if (drink == "kegTonic") {
            if (kegTonic.Contains(ingredient)) {
                return true;
            } else {
                return false;
            }
        }
        if (drink == "everythingSmoothie") {
            if (everythingSmoothie.Contains(ingredient)) {
                return true;
            } else {
                return false;
            }
        }
        else {
            return false;
        }
         // have lists of all ingredients (no garnishes)
         // check garnishes in another script
    }
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("iceCube"))
        {
            if (!itemList.Contains("iceCube") && isCorrectIngredient("iceCube", GetComponent<CustomerController>().randomOrderableItem)) {
                AudioSource.PlayClipAtPoint(confirmSFX, transform.position);
            }

            itemList.Add("iceCube");

            other.gameObject.SetActive(false);

            setMaterialOff();
            iceMaterial.SetActive(true);
        }
        else if (other.gameObject.CompareTag("kegLiquid"))
        {
            if (!itemList.Contains("kegLiquid") && isCorrectIngredient("kegLiquid", GetComponent<CustomerController>().randomOrderableItem)) {
                AudioSource.PlayClipAtPoint(confirmSFX, transform.position);
            }

            itemList.Add("kegLiquid");

            other.gameObject.SetActive(false);

            setMaterialOff();
            kegMaterial.SetActive(true);
        }
        else if (other.gameObject.CompareTag("appleJuice"))
        {
            if (!itemList.Contains("appleJuice") && isCorrectIngredient("appleJuice", GetComponent<CustomerController>().randomOrderableItem)) {
                AudioSource.PlayClipAtPoint(confirmSFX, transform.position);
            }

            itemList.Add("appleJuice");

            other.gameObject.SetActive(false);

            setMaterialOff();
            appleMaterial.SetActive(true);
        }
        else if (other.gameObject.CompareTag("shavedIce"))
        {
            if (!itemList.Contains("shavedIce") && isCorrectIngredient("shavedIce", GetComponent<CustomerController>().randomOrderableItem)) {
                AudioSource.PlayClipAtPoint(confirmSFX, transform.position);
            }

            itemList.Add("shavedIce");

            other.gameObject.SetActive(false);

            setMaterialOff();
            iceShardMaterial.SetActive(true);
        }
        else if (other.gameObject.CompareTag("tonic"))
        {
            if (!itemList.Contains("tonic") && isCorrectIngredient("tonic", GetComponent<CustomerController>().randomOrderableItem)) {
                AudioSource.PlayClipAtPoint(confirmSFX, transform.position);
            }

            itemList.Add("tonic");

            other.gameObject.SetActive(false);

            setMaterialOff();
            tonicMaterial.SetActive(true);
        }
        else
        {
            //other.gameObject.SetActive(true);
        }

    }


}

