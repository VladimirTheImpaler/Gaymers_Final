using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scooperIceCubeDespawn : MonoBehaviour
{
    public GameObject localIceCube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("cupColliderDisk"))
        {

            localIceCube.SetActive(false);
            //AudioSource.PlayClipAtPoint(soundName, transform.position);
        }
        else
        {

            other.gameObject.SetActive(true);
        }
    }


}
