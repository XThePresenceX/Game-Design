using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarterPP : MonoBehaviour
{
    public static int SceneNumber;

    void Start()
    {
        if(SceneNumber == 0)
        {
            StartCoroutine(MainMenu ());
        }
    }

    IEnumerator MainMenu()
    {
        yield return new WaitForSeconds(5);
        SceneNumber = 1;
        SceneManager.LoadScene(1);
    }

}
