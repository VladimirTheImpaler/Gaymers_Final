using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juicerColiderLogic : MonoBehaviour
{

    public GameObject appleJuice;
    public GameObject juicerSpawnSphere;
    public bool fullyCrushed = false;
    public Vector3 juicerSpawnSpherelocation;

    public List<string> itemList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        juicerSpawnSpherelocation = juicerSpawnSphere.GetComponent<Rigidbody>().position;
        spawnJuice();
    }

    public void spawnJuice()
    {

        if (fullyCrushed)
        {

            if (itemList.Contains("apple"))
            {
                GameObject newJuice = Instantiate(appleJuice, juicerSpawnSpherelocation, Quaternion.identity) as GameObject;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("apple"))
        {

            //add the item to list
            itemList.Add("apple");

            other.gameObject.SetActive(false);
            //AudioSource.PlayClipAtPoint(soundName, transform.position);
        }
        else
        {
            //other.gameObject.SetActive(true);
        }
    }

}
