using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trial : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MPlatform")
        {
            var GO = GameObject.Find("Moving_Platform");//whatever the name of your moving platform is
            var GO1 = GameObject.Find("Player");
            print("parented to platform");
            GO1.transform.parent = GO.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MPlatform")
        {
            var GO = GameObject.Find("Moving_Platform");
            var GO1 = GameObject.Find("Player");
            print("UNparented to platform");
            GO1.transform.parent = null;
        }
    }
}
