using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Plats : MonoBehaviour
{
    private GameObject P1;
    public Vector3 velocity;
    public static bool moving;
    /*public float speed;
    private bool move = false;
    private float triggerDistance;
    private Vector3 movementDirection;
    */
    private void Start()
    {
        moving = false;
        P1 = GameObject.FindGameObjectWithTag("Player");
        //player = Globals.GetPlayerObject();
        //triggerDistance = transform.localScale.x / 2 - movementTriggerWidth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == P1)
        {
            moving = true;
            P1.transform.SetParent(transform);
            //Rigidbody RB = P1.GetComponent<Rigidbody>();
            //RB.isKinematic = false;
           // RB.detectCollisions = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == P1)
        {
            moving = false;
            P1.transform.SetParent(null);
           // Rigidbody RB = P1.GetComponent<Rigidbody>();
            ////RB.isKinematic = true;
           // RB.detectCollisions = false;
        }
    }

    /*private void OncollisionEnter(Collision col)
    {
        if (col.gameObject == P1)
        {
            //col.collider.transform.SetParent(transform);
            P1.transform.SetParent(gameObject.transform);
            //Rigidbody RB = P1.GetComponent<Rigidbody>();
            //RB.isKinematic = false;
            // RB.detectCollisions = true;
        }
    }

    private void OncollisionExit(Collision col)
    {
        if (col.gameObject == P1)
        {
            //col.collider.transform.SetParent(null);
            P1.transform.SetParent(null);
            // Rigidbody RB = P1.GetComponent<Rigidbody>();
            ////RB.isKinematic = true;
            // RB.detectCollisions = false;
        }
    }*/

  /*  function OnCollisionEnter(hit : Collision)
    {
        if (hit.transform.tag == "Player")
        {
            hit.transform.parent = transform;
        }
    }

    function OnCollisionExit(hit : Collision)
    {
        if (hit.transform.tag == "Player")
        {
            hit.transform.parent = null;
        }
    }*/
    /*private void FixedUpdate()
     {
         if (moving)
         {
             transform.position += (velocity * Time.deltaTime);
         }
     }*/
    /*private void OnTriggerStay(Collider col)
    {
        if (col.gameObject == P1)
        {
            Vector3 playerPosition = P1.transform.position;
            Vector3 platformPosition = transform.position;

            if (Vector3.Distance(playerPosition, platformPosition) > triggerDistance)
            {
                movementDirection = playerPosition - platformPosition;
                move = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if (move)
            transform.Translate(movementDirection * speed * Time.deltaTime);

        move = false;
    }*/
}
