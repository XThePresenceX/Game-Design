using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCastle : MonoBehaviour
{
    public static bool win = false;

    void Start()
    {
        win = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("colliding");
        if (collision.gameObject.tag == "Player" && BossMan.BossAlive == false)
        {
            win = true;
           // SoundManager.PlaySound("tuturu");
           // Invoke("WinMusic",0.6f);
            //Debug.Log(" with player");
            PlayerManager.gameOver = true;
            //GOpanel.SetActive(true);
        }
    }
    void WinMusic()
    {
        SoundManager.PlaySound("Win");
    }
}
