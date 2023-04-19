using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juicerColiderLogic : MonoBehaviour
{

    public GameObject appleJuice;
    public GameObject juicerSpawnSphere;
    public GameObject juicerHandle;
    public bool fullyCrushed = false;
    public int timer = 2;
    public Vector3 juicerSpawnSpherelocation;

    public List<string> itemList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1;

        juicerSpawnSpherelocation = juicerSpawnSphere.GetComponent<Rigidbody>().position;
        spawnJuice();

        fullyCrushed = juicerHandle.GetComponent<CrankRotation>().juicerIsJuicing;
    }

    public void spawnJuice()
    {

        if (fullyCrushed)
        {

            if (itemList.Contains("apple") && (timer < 0))
            {

                timer = 2;
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
