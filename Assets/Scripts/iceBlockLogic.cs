using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceBlockLogic : MonoBehaviour
{
    public GameObject iceCube;
    public GameObject iceCubeSpawnCube;
    public Vector3 objectSpawnlocation;

    int timer = 10;
    bool useAble = false;

    // Start is called before the first frame update
    void Start()
    {


    }

    public void spawnIce()
    {

        objectSpawnlocation = iceCubeSpawnCube.GetComponent<Rigidbody>().position;

        if (useAble)
        {

            timer = 10;
            GameObject newIce = Instantiate(iceCube, objectSpawnlocation, Quaternion.identity) as GameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {

        timer -= 1;

        objectSpawnlocation = iceCubeSpawnCube.GetComponent<Rigidbody>().position;

        if (timer < 0)
        {
            useAble = true;
        }
        else
        {
            useAble = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("icePick"))
        {

            spawnIce();
            //AudioSource.PlayClipAtPoint(soundName, transform.position);
        }
        else
        {
            other.gameObject.SetActive(true);
        }
    }

}
