using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceScooperLogic : MonoBehaviour
{

    public List<GameObject> cubeList = new List<GameObject>();
    public bool hasIce = false;
    public bool isPouring = false;
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

        cubeList.Add(cube0);
        cubeList.Add(cube1);
        cubeList.Add(cube2);
        cubeList.Add(cube3);
        cubeList.Add(cube4);
        cubeList.Add(cube5);
        cubeList.Add(cube6);
        cubeList.Add(cube7);
        cubeList.Add(cube8);
    }

    // Update is called once per frame
    void Update()
    {

        cube4.GetComponent<Rigidbody>().isKinematic = false;
        cube4.GetComponent<Rigidbody>().useGravity = true;

        if (hasIce)
        {

            for(int i = 0; i < cubeList.Count; i++)
            {
                cubeList[i].SetActive(true);
            }
        }
        else
        {

            for (int i = 0; i < cubeList.Count; i++)
            {
                cubeList[i].SetActive(false);
            }
        }

        isPouring = GetComponent<PourOnRotate>().isPouring;

        if (isPouring)
        {

            for (int i = 0; i < cubeList.Count; i++)
            {
                cubeList[i].GetComponent<Rigidbody>().isKinematic = false;
                cubeList[i].GetComponent<Rigidbody>().useGravity = true;
            }
            
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
