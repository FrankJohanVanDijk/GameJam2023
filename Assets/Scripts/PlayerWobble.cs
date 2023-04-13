using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWobble : MonoBehaviour
{
    public float wobbleSpeed = 5;
    public float heightMultiplier = 1f;
    float timeAlive = 0;
    float orgY;
    // Start is called before the first frame update
    void Start()
    {
        orgY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime * wobbleSpeed;
        Vector3 newPos = transform.position;
        newPos.y = orgY + Mathf.Sin(timeAlive) * heightMultiplier;
        transform.position = newPos;
    }
}
