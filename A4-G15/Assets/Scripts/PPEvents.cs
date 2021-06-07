using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PPEvents : MonoBehaviour
{
    public TextMeshProUGUI PP;
    //public GameObject pauseButton;
    bool Paused = false;
    private GameObject yourButton;
    void Start()
    {
        Paused = false;
    }
    void Update()
    {
        if(PlayerManager.gameOver) 
        {
            Pause();
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Practice()
    {
        SceneManager.LoadScene(2);
    }

    public void Level1()
    {
        SceneManager.LoadScene(3);
    }

    public void Level2()
    {
        SceneManager.LoadScene(4);
    }

    public void Level3()
    {
        SceneManager.LoadScene(5);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void QuitMM()
    {
        SceneManager.LoadScene(1);
    }

    public void More()
    {
        SceneManager.LoadScene(6);
    }

    public void Pause()
    {
        if (Paused)
        {
            Time.timeScale = 1;
            Paused = false;
            PP.text = "Pause";
        }
        else
        {
            Time.timeScale = 0;
            Paused = true;
            PP.text = "Resume";
        }
    }


}
