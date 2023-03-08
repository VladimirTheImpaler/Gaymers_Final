using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            this.transform.LookAt(player.transform);

            Vector3 angles = transform.rotation.eulerAngles;
            angles.x = 0;
            angles.z = 0;

            transform.rotation = Quaternion.Euler(angles);
        }
    }
}
