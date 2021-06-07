using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBlock : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("colliding");
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log(" with Player");
            PlayerManager.PHealth -= 101;
        }
    }
}
