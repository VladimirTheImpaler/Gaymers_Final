using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceScooperLogic : MonoBehaviour
{

    public bool respawnButton;
    public int respawnTimer = 0;

    public List<GameObject> cubeList = new List<GameObject>();
    public List<Vector3> cubePosList = new List<Vector3>();

    public bool hasIce = false;
    public bool isPouring = false;

    public GameObject iceScoop;

    public GameObject cube0;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;
    public GameObject cube5;
    public GameObject cube6;
    public GameObject cube7;
    public GameObject cube8;

    public Vector3 iceScoopPos;

    public Vector3 cube0Pos = new Vector3(-0.4470001f, 0.2969999f, 0.2009997f);
    public Vector3 cube1Pos = new Vector3(-0.6399f, 0.4219f, 0.2254f);
    public Vector3 cube2Pos = new Vector3(-0.399f, 0.3552f, 0.399f);
    public Vector3 cube3Pos = new Vector3(-0.611f, 0.3419997f, 0.564f);
    public Vector3 cube4Pos = new Vector3(-0.512f, 0.17f, 0.9f);
    public Vector3 cube5Pos = new Vector3(-0.4f, 0.3177f, 0.8312f);
    public Vector3 cube6Pos = new Vector3(-0.409f, 0.3129998f, 0.632f);
    public Vector3 cube7Pos = new Vector3(-0.5799f, 0.3099998f, 0.395f);
    public Vector3 cube8Pos = new Vector3(-0.604f, 0.3239998f, 0.757f);


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

        cubePosList.Add(cube0Pos);
        cubePosList.Add(cube1Pos);
        cubePosList.Add(cube2Pos);
        cubePosList.Add(cube3Pos);
        cubePosList.Add(cube4Pos);
        cubePosList.Add(cube5Pos);
        cubePosList.Add(cube6Pos);
        cubePosList.Add(cube7Pos);
        cubePosList.Add(cube8Pos);
    }

    // Update is called once per frame
    void Update()
    {
        iceScoopPos = GetComponent<Rigidbody>().position;
        isPouring = GetComponent<PourOnRotate>().isPouring;
        respawnTimer += 1;

        if (respawnButton)
        {
            respawnIce();
        }

        if (respawnTimer == 0)
        {

            respawnIce();
            hasIce = false;
        }


        if (hasIce)
        {

            for (int i = 0; i < cubeList.Count; i++)
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

        if (isPouring)
        {

            respawnTimer = -200;

            for (int i = 0; i < cubeList.Count; i++)
            {
                cubeList[i].GetComponent<Rigidbody>().isKinematic = false;
                cubeList[i].GetComponent<Rigidbody>().useGravity = true;
            }

        }

        //Delete Ice that falls below the bar
        for (int i = 0; i < cubeList.Count; i++)
        {
            if (cubeList[i].GetComponent<Rigidbody>().position.y < 0)
            {

                //cubeList[i].SetActive(false);
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
    

    public void respawnIce()
    {


        for (int i = 0; i < cubeList.Count; i++)
        {

            cubeList[i].GetComponent<Rigidbody>().isKinematic = true;
            cubeList[i].GetComponent<Rigidbody>().useGravity = false;

            cubeList[i].transform.position = cubePosList[i] + iceScoopPos;
        }
    }
}



