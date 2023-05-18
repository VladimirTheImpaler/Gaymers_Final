using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secretScript : MonoBehaviour
{

    public GameObject customer;

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

        if (other.gameObject.CompareTag("secretBucket"))
        {

            customer.gameObject.transform.localScale += new Vector3(20,20,0);
            other.gameObject.SetActive(false);
        }
    }
}
