using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juicerColiderLogic : MonoBehaviour
{

    public GameObject appleJuice;
    public GameObject juicerSpawnSphere;
    public bool fullyCrushed = false;
    public Vector3 objectSpawnlocation = new Vector3(2.2f, 4f, 1.4f);

    public List<string> itemList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        objectSpawnlocation = juicerSpawnSphere.GetComponent<Rigidbody>().position;
        spawnJuice();
    }

    public void spawnJuice()
    {

        if (fullyCrushed)
        {

            if (itemList.Contains("apple"))
            {
                GameObject newJuice = Instantiate(appleJuice, objectSpawnlocation, Quaternion.identity) as GameObject;
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
