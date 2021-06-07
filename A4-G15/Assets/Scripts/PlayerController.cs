using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController Controller;
    private Vector3 Direction;
    Vector3 playerPos;
    public float Speed = 8;
    public float JForce = 10;
    public float Gravity = -20;

    public Transform GroundCheck;
    public LayerMask GroundLayer;
    public LayerMask clickMask;
    public GameObject GOpanel;
    bool isGrounded = true;
    bool canDoubleJump = true;

    ///private float maxX;
    // float backLimit;
    //private float upperLimit;
    public Animator AnimatorA;
    public Transform Model;
   // private bool reversefreeze=false;

    Collider m_Collider;

    void Start()
    {
        playerPos = transform.position;
        //maxX = 0;
        m_Collider = GetComponent<Collider>();
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="MPlatform") { 
            var GO = GameObject.Find("Moving_Platform");
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
    }*/
    // Update is called once per frame
    void Update()
    {
        /*if (maxX < transform.position.x)
        {
            maxX = transform.position.x;

        }

        backLimit = maxX - 12f;
        upperLimit = maxX + 12f;*/
       // Debug.Log("backLimit" + backLimit);
       // Debug.Log("transform" + transform.position.x);
      

        //playerPos.x = Mathf.Clamp(transform.position.x, backLimit, upperLimit);
        //Debug.Log("playerPos" + playerPos);
       /* if (transform.position.x < backLimit)
        {
            reversefreeze = true;
            //Debug.Log("Here");
            //transform.position = playerPos;
            //transform.position = new Vector3(backLimit, transform.position.y, transform.position.z);
            //transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else {
            reversefreeze = false;
        }*/

        if (transform.position.y < -100)
        {
            PlayerManager.gameOver = true;
           GOpanel.SetActive(true);
        }
        //Debug.Log(isGrounded);


        if (!Moving_Plats.moving) { transform.SetParent(null); }

        if (transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        if (PlayerManager.gameOver && EndCastle.win == false)
        {
            SoundManager.PlaySound("Lose");
            AnimatorA.SetTrigger("dead");
            this.enabled = false;
        }
        if (PlayerManager.gameOver && EndCastle.win == true)
        {
            this.enabled = false;
            SoundManager.PlaySound("tuturu");
            Invoke("WinMusic", 0.6f);
            //Debug.Log(" with player");
            //PlayerManager.gameOver = true;
            GOpanel.SetActive(true);
        }
      
    
       
            float HInput = Input.GetAxis("Horizontal");
        //Debug.Log(HInput);
        //if (!reversefreeze)
        //{
            Direction.x = HInput * Speed;
            AnimatorA.SetFloat("Speed", Mathf.Abs(HInput));
        //}
       // else
        /*{
            if (HInput > 0)
            {
                Direction.x = HInput * Speed;
                AnimatorA.SetFloat("Speed", Mathf.Abs(HInput));
            }
            else { }
        }*/
        
        isGrounded = Physics.CheckSphere(GroundCheck.position, 0.2f, GroundLayer);
        AnimatorA.SetBool("isGrounded", isGrounded); 
        if (isGrounded)
        {
            Direction.y = -1;
            canDoubleJump = true;
            if (Input.GetButtonDown("Jump"))
            {
               // if (Moving_Plats.moving) { Direction.y = 30; }
                { Direction.y = JForce; }
            }

            if (Input.GetKey(KeyCode.LeftControl))
            {
                Direction.x = HInput * 2 * Speed;
            }

            if (Input.GetKeyDown(KeyCode.F) && PlayerManager.numberOfFireBalls > 0)
            {
                AnimatorA.SetTrigger("fireballATK");
                PlayerManager.numberOfFireBalls--;
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                if (PlayerManager.beamer)
                {
                    AnimatorA.SetTrigger("beamATK");
                }
            }

            if (Input.GetKeyDown(KeyCode.X) && PlayerManager.jumpHigh)
            {
                PlayerManager.jumpHigh = false;
                { Direction.y = 30; }
            }
        }
        else
        {
            Direction.y += Gravity * Time.deltaTime;

            if (canDoubleJump && Input.GetButtonDown("Jump"))
            {
                AnimatorA.SetTrigger("doubleJump");
                Direction.y = JForce;
                canDoubleJump = false;
            }
        }

        if (AnimatorA.GetCurrentAnimatorStateInfo(0).IsName("Fireball"))
            return;

        if(HInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(HInput,0,0));
            Model.rotation = newRotation;
        }

        if (PlayerManager.invincible)
        {
            //Debug.Log(PlayerManager.invincible);
            m_Collider.enabled = false;
            Invoke("SetBoolBack", 3f);
        }
        else
        {
           // Debug.Log(PlayerManager.invincible);
            m_Collider.enabled = true;
        }


        Controller.Move(Direction * Time.deltaTime);

        if (Input.GetMouseButtonDown(0) && PlayerManager.invincible)
        {
            //Debug.Log("We clicking");
            Vector3 clickPosition = -Vector3.one;

            //clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //clickPosition.z = clickPosition.z * 0;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, clickMask))
            {
                clickPosition = hit.point;
            }
            clickPosition.z = clickPosition.z * 0;
            clickPosition.y = clickPosition.y + 2;
            //Debug.Log(clickPosition);
            if (clickPosition.x == -1) { }
            else
            {
                transform.position = clickPosition;
             
                Physics.IgnoreLayerCollision(9, 10, true);
                PlayerManager.invincible = false; 
                Invoke("Colon", 2f);
            }
            //Destroy(GameObject.FindWithTag("Player"));
            // Instantiate(P1, clickPosition, Quaternion.identity);
        }
    }
    void WinMusic()
    {
        SoundManager.PlaySound("Win");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ST" || collision.gameObject.tag == "Enemy")
        {
            Debug.Log("InCollision with " + collision.gameObject.tag);

                if (collision.gameObject.tag == "ST")
            {
                Debug.Log(" with overhead collider");
                SoundManager.PlaySound("Jumpon");
                Destroy(collision.transform.parent.gameObject); 
                Destroy(collision.gameObject);
                PlayerManager.enemiesKilled++;
            }

            if (collision.gameObject.tag == "Enemy")
            // if (collision.gameObject.tag == "Enemy")
            {
                Debug.Log(" with box");
                if (!PlayerManager.invincible)
                {
                    SoundManager.PlaySound("Nani");
                    //PlayerManager.numberOfHearts--;
                    PlayerManager.PHealth -= 10;
                    Physics.IgnoreLayerCollision(9, 10,true);
                    Invoke("Colon", 3f);
                    //Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), collision.transform.gameObject.GetComponent<Collider>(),true);
                    //touched = true;
                    //ShellMovement.movingForward = !ShellMovement.movingForward;
                    //m_Collider.enabled = false;

                }
            }
        }
    }

    private void Colon()
    {
        Physics.IgnoreLayerCollision(9, 10, false);
        PlayerManager.invincible = false;
    }

    public void SetBoolBack()
    {
        PlayerManager.invincible = false;
    }
}
