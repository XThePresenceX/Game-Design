using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    private Vector3 offset;
    public float maxX;

    public float smoothSpeed = 0.15f;
    void Start()
    {
        maxX = 0;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
    }

    void Update()
    {
        if (maxX < target.position.x) {
            maxX = target.position.x;
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        //if (target.position.x < maxX) { }
        //else
        {
            // transform.position = target.position + offset;
            Vector3 desiredPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        }
    }
}
