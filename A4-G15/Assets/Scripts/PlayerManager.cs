using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static int numberOfCoins;
    public static float numberOfHearts;
    public static int numberOfFireBalls;
    public static int numberOfEmerald;
    public static int numberOfJumper;
    public static int enemiesKilled;
    public static bool invincible;
    public static bool beamer;
    public static int PHealth;
    public static bool jumpHigh;

    public Slider healthBar;
    public static bool gameOver;
    public GameObject GOpanel;

    public TextMeshProUGUI daimondsTxt;
    public TextMeshProUGUI heartsTxt;
    public TextMeshProUGUI fireBallsTxt;
    public TextMeshProUGUI invincibleTxt;
    public TextMeshProUGUI beamerTxt;
    public TextMeshProUGUI activatedBeam;
    public TextMeshProUGUI jumperTxt;
    public TextMeshProUGUI killedTxt;

    // public GameObject E1;
    //public GameObject E2;

    // Start is called before the first frame update
    void Start()
    {
        numberOfCoins = 0;
        numberOfHearts = 0;
        numberOfFireBalls = 10;
        numberOfJumper = 0;
        numberOfEmerald = 0;
        enemiesKilled = 0;
        invincible = false;
        beamer = false;
        gameOver = false;
        jumpHigh = false;
        PHealth = 90;
        Physics.IgnoreLayerCollision(9,9,true);
        Physics.IgnoreLayerCollision(9, 13, true);
        // Physics.IgnoreCollision(E1.GetComponent<Collider>(), E2.GetComponent<Collider>(), true);
    }

    // Update is called once per frame
    void Update()
    {

        if (numberOfJumper > 0)
        {
            jumpHigh = true;
        }
        else
        {
            jumpHigh = false;
        }

        if(numberOfEmerald >= 5)
        {
            beamerTxt.text = "BEAM";
            activatedBeam.text = "ACTIVATED";
            beamer = true;
            Invoke("turnBeamerOff", 10f);
        }
        else
        {
            beamerTxt.text = "E: " + numberOfEmerald;
            activatedBeam.text = "";
        }

        if (invincible)
        {
            invincibleTxt.text = "SPower: ON";
        }
        else
        {
            invincibleTxt.text = "SPower: OFF";
        }
        //PHealth -= 1;
        healthBar.value = PHealth;

        if(PHealth <= 0)
        {
            gameOver = true;
            GOpanel.SetActive(true);
            PHealth = 100;
        }

        killedTxt.text = "Killed: " + enemiesKilled;
        jumperTxt.text = "J: " + numberOfJumper;
        daimondsTxt.text = "D: " + numberOfCoins;
        heartsTxt.text = "H: " + numberOfHearts;
        fireBallsTxt.text = "FB: " + numberOfFireBalls;
        //invincibleTxt.text = "S: " + invincible;
        
    }

    void turnBeamerOff()
    {
        beamer = false;
        numberOfEmerald = 0;
    }
}
