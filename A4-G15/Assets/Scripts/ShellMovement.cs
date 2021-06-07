using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellMovement : MonoBehaviour
{
    private Vector3 pointB;
    private Vector3 pointA;
    public static bool movingForward = true;
    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(9,9,true);
        /*pointA = transform.position;
        pointA= new Vector3(pointA.x-3, pointA.y, pointA.z);
        pointB = transform.position;
        pointB = new Vector3(pointB.x + 3, pointB.y, pointB.z);*/
    }

    void Update()
    {
        if (movingForward)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (transform.position.x >= 25f)
        {
            movingForward = true;
        }

        if (transform.position.x <= 13f)
        {
            movingForward = false;
        }

        if(transform.position.y <= -100f)
        {
            Destroy(gameObject);
        }
    }


   /* void OnCollisionEnter(Collision collision)
    {
        movingForward = !movingForward;
    }*/
    /* Update is called once per frame
    void Update()
    {
        if (transform.position.x > pointB.x && movingForward)
        {
            moveLeft();
        }
        if (transform.position.x < pointA.x && !movingForward)
        {
            moveRight();
        }
    }
    void moveLeft()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, -90, 0);
        if(transform.position.x < pointA.x)
        {
            movingForward = !movingForward;
        }
    }
    void moveRight()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 90, 0);
        if (transform.position.x > pointB.x)
        {
            movingForward = !movingForward;
        }
    }*/
}
