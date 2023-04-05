using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerResize : MonoBehaviour
{

    public GameObject playerParent;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        transform.localScale = new Vector3(3.5f,3.5f,3.5f);
    }
}
