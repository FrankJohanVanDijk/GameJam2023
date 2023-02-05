using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float _currentSpeed = 0;
    private float _lerpValue = 0.1f;
    private float timeMoving = 0;
    public float timeMaxSpeed = 0.3f;
    public float playerSpeed = 5;
    public float leftRightSpeed = 0;
    public float upDownSpeed = 0;
    private bool _moving = false;


    private Rigidbody _rigidbody;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.z = Input.GetAxis("Horizontal");
        movement.x = -Input.GetAxis("Vertical");
        //Look();
    }

    void Look()
    {
        if(movement != Vector3.zero)
        {
            var relative = (transform.position + movement) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 360 * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(transform.position + movement * playerSpeed * Time.fixedDeltaTime);
    }

    public void DoublePlayerSpeed()
    {
        playerSpeed *= 2;
    }
}
