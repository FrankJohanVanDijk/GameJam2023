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

        if (Input.GetKeyDown(KeyCode.A))
        {
            leftRightSpeed = -1;
            _moving = true;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            leftRightSpeed = 1;
            _moving = true;
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            upDownSpeed = -1;
            _moving = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            upDownSpeed = 1;
            _moving = true;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            leftRightSpeed = 0;
            _moving = false;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            leftRightSpeed = 0;
            _moving = false;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            upDownSpeed = 0;
            _moving = false;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            upDownSpeed = 0;
            _moving = false;
        }


        if (_moving && _lerpValue < 1)
        {
            timeMoving += Time.deltaTime;
            _lerpValue = timeMoving / timeMaxSpeed;
            _currentSpeed = 0 + (playerSpeed - 0) * _lerpValue;
        }

        if (!_moving && _lerpValue > 0)
        {
            timeMoving -= Time.deltaTime;
            _lerpValue = timeMoving / timeMaxSpeed;
            _currentSpeed = 0 + (playerSpeed - 0) * _lerpValue;
        }

        //_rigidbody.velocity = new Vector3(_currentSpeed * upDownSpeed, 0, _currentSpeed * leftRightSpeed);

    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + movement * playerSpeed * Time.fixedDeltaTime);
    }

    public void DoublePlayerSpeed()
    {
        playerSpeed *= 2;
    }
}
