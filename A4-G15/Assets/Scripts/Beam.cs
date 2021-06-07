using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    //Collider m_Collider;

    void Start()
    {
        Physics.IgnoreLayerCollision(8, 11, true);
        Physics.IgnoreLayerCollision(10, 11, true);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        { 
            //Destroy(gameObject);
            Destroy(collision.gameObject);
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(40, 0, 0);
            PlayerManager.enemiesKilled++;
        }
        if (collision.gameObject.tag == "Boss")
        {
            //Debug.Log("hitting boss");
            Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider>());
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(40, 0, 0);
        }

    }
    /*void OnCollisionStay(Collision collision)
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(20, 0, 0);
    }
    void OnCollisionExit(Collision collision) 
    {
       gameObject.GetComponent<Rigidbody>().velocity = new Vector3(20, 0, 0);
    }*/
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        else
        {
            m_Collider = gameObject.GetComponent<Collider>();
            m_Collider.enabled = false;
        }
    }*/

    /* void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.tag == "D1")
         {
             Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
         }
     }*/

}
