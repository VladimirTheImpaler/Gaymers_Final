using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class broomLogic : MonoBehaviour
{

    public GameObject juicerFreezeBlock;

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

        if (other.gameObject.CompareTag("appleJuice"))
        {

            juicerFreezeBlock.GetComponent<juicerFreezeBlockLogic>().numLiquid -=1;
        }
    }
}
