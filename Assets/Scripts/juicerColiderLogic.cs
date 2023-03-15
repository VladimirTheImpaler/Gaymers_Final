using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juicerColiderLogic : MonoBehaviour
{

    public GameObject appleJuice;
    public bool fullyCrushed = false;

    public List<string> itemList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        spawnJuice();
    }

    public void spawnJuice()
    {

        if (fullyCrushed)
        {

            if (itemList.Contains("apple"))
            {
                GameObject newJuice = Instantiate(appleJuice, new Vector3(2.2f, 4f, 1.4f), Quaternion.identity) as GameObject;
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
            other.gameObject.SetActive(true);
        }
    }

}
