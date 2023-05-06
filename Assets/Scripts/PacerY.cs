using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacerY : MonoBehaviour
{
    public float speed = 5f;
    public float yMax = 5.75f;
    public float yMin = 5.25f; //starting position
    private int direction = 1; //positive to start

    void Update()
    {
        float yNew = transform.position.x +
                    direction * speed * Time.deltaTime;
        if (yNew >= yMax)
        {
            yNew = yMax;
            direction *= -1;
        }
        else if (yNew <= yMin)
        {
            yNew = yMin;
            direction *= -1;
        }
        transform.position = new Vector3(this.gameObject.transform.position.x, yNew, this.gameObject.transform.position.z);
    }
}
