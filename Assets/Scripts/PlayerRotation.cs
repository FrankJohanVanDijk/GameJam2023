using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = -Input.GetAxis("Horizontal");
        movement.z = -Input.GetAxis("Vertical");
        Look();
    }

    void Look()
    {
        if (movement != Vector3.zero)
        {
            var relative = (transform.position + movement) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 360 * Time.deltaTime);
        }
    }
}
