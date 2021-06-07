using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disablePause : MonoBehaviour
{
    void Update()
    {
        if (PlayerManager.gameOver)
        {
            gameObject.SetActive(false);
        }
    }
}
