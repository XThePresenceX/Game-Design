using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {

    public bool isAnimated = false;

    private GameObject PlayerP1;

    public bool isRotating = false;
    public bool isFloating = false;
    public bool isScaling = false;

    public Vector3 rotationAngle;
    public float rotationSpeed;

    public float floatSpeed;
    private bool goingUp = true;
    public float floatRate;
    private float floatTimer;
   
    public Vector3 startScale;
    public Vector3 endScale;

    private bool scalingUp = true;
    public float scaleSpeed;
    public float scaleRate;
    private float scaleTimer;

	// Use this for initialization
	void Start () {
        PlayerP1 = GameObject.FindGameObjectWithTag("Player");
	}
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Jumper")
        {
            //Debug.Log("Diamond updated");
            PlayerManager.jumpHigh = true;
            SoundManager.PlaySound("OMAE");
            PlayerManager.numberOfJumper++;
        }

        if (gameObject.tag == "Daimond")
        {
            //Debug.Log("Diamond updated");
            PlayerManager.numberOfCoins++;
           // SoundManager.PlaySound("OMAE");
        }
        if (gameObject.tag == "Heart")
        {
            if (PlayerManager.PHealth == 100) { }
            else
            {
                PlayerManager.PHealth += 20;
                //SoundManager.PlaySound("OMAE");
            }
        }
        if (gameObject.tag == "FireBall")
        {
            PlayerManager.numberOfFireBalls++;
             SoundManager.PlaySound("OMAE");
        }
        if (gameObject.tag == "Star")
        {
            PlayerManager.invincible = true;
            SoundManager.PlaySound("OMAE");
            //SoundManager.PlaySound("Win");

        }
        if(gameObject.tag == "HealthMax")
        {
            //PlayerManager.PHealth = 100;
            PlayerManager.numberOfEmerald++;
           // SoundManager.PlaySound("OMAE");
        }
         

        if (other.tag == "Player")
        {          
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {

        if (isAnimated)
        {
            if(isRotating)
            {
                transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);
            }

            if(isFloating)
            {
                floatTimer += Time.deltaTime;
                Vector3 moveDir = new Vector3(0.0f, 0.0f, floatSpeed);
                transform.Translate(moveDir);

                if (goingUp && floatTimer >= floatRate)
                {
                    goingUp = false;
                    floatTimer = 0;
                    floatSpeed = -floatSpeed;
                }

                else if(!goingUp && floatTimer >= floatRate)
                {
                    goingUp = true;
                    floatTimer = 0;
                    floatSpeed = +floatSpeed;
                }
            }

            if(isScaling)
            {
                scaleTimer += Time.deltaTime;

                if (scalingUp)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, endScale, scaleSpeed * Time.deltaTime);
                }
                else if (!scalingUp)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, startScale, scaleSpeed * Time.deltaTime);
                }

                if(scaleTimer >= scaleRate)
                {
                    if (scalingUp) { scalingUp = false; }
                    else if (!scalingUp) { scalingUp = true; }
                    scaleTimer = 0;
                }
            }
        }
	}

}
