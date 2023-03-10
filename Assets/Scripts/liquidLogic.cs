using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liquidLogic : MonoBehaviour
{

    public int life = 50000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.life -= 1;

        if (this.life < 0)
        {

            this.life = 0;
            this.gameObject.SetActive(false);
        }

    }
}
