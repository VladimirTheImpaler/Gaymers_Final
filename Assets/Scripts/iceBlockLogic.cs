using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceBlockLogic : MonoBehaviour
{
    public GameObject iceCube;
    public Vector3 objectSpawnlocation = new Vector3(5.5f, 4.5f, 0.5f);
    public AudioClip iceSpawn_SFX;

    int timer = 10;
    bool useAble = false;

    // Start is called before the first frame update
    void Start()
    {


    }

    public void spawnIce()
    {

        if (useAble)
        {

            timer = 10;
            GameObject newIce = Instantiate(iceCube, objectSpawnlocation, Quaternion.identity) as GameObject;
            AudioSource.PlayClipAtPoint(iceSpawn_SFX, transform.position);
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
