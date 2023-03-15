using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceBlockLogic : MonoBehaviour
{
    public GameObject iceCube;

    int timer = 100;
    bool useAble = false;

    // Start is called before the first frame update
    void Start()
    {


    }

    public void spawnIce()
    {

        if (useAble)
        {

            timer = 100;
            GameObject newIce = Instantiate(iceCube, new Vector3(5.5f, 4.5f, 0f), Quaternion.identity) as GameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {

        timer -= 1;

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
