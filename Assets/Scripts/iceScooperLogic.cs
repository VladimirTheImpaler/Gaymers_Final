using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceScooperLogic : MonoBehaviour
{

    public bool hasIce = false;
    public GameObject cube0;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;
    public GameObject cube5;
    public GameObject cube6;
    public GameObject cube7;
    public GameObject cube8;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (hasIce)
        {

            cube0.SetActive(true);
            cube1.SetActive(true);
            cube2.SetActive(true);
            cube3.SetActive(true);
            cube4.SetActive(true);
            cube5.SetActive(true);
            cube6.SetActive(true);
            cube7.SetActive(true);
            cube8.SetActive(true);
        }
        else
        {

            cube0.SetActive(false);
            cube1.SetActive(false);
            cube2.SetActive(false);
            cube3.SetActive(false);
            cube4.SetActive(false);
            cube5.SetActive(false);
            cube6.SetActive(false);
            cube7.SetActive(false);
            cube8.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("iceBucket"))
        {

            hasIce = true;
            //AudioSource.PlayClipAtPoint(soundName, transform.position);
        }
        else if (other.gameObject.CompareTag("cupColliderDisk"))
        {

            //AudioSource.PlayClipAtPoint(soundName, transform.position);
        }
        else
        {
        
            other.gameObject.SetActive(true);
        }
    }

}
