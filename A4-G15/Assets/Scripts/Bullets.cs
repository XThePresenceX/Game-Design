using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManager.PlaySound("Nani");
            PlayerManager.PHealth -= 10;
            //PlayerManager.numberOfHearts = PlayerManager.numberOfHearts - 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
