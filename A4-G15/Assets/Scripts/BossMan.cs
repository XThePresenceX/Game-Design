using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMan : MonoBehaviour
{
    private string currentState = "Idle";
    private Transform target;
    public float range = 5f;
    public Animator animator;
    public float speed = 3f;
    public float attackRange = 2f;
    public int Health;
    public int MaxHealth;
    public static bool BossAlive; 
    // Start is called before the first frame update
    void Start()
    {
        BossAlive = true;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerManager.gameOver)
        {
            animator.enabled = false;
            this.enabled = false;
        }

        float distance = Vector3.Distance(transform.position, target.position);

        if(currentState == "Idle")
        {
            if (distance < range)
                currentState = "Chase";
        }
        else if (currentState == "Chase")
        {
            animator.SetTrigger("chase");
            animator.SetBool("attacking", false);
            if (distance < attackRange)
            {
                currentState = "Attack";
            }

            if (target.position.x > transform.position.x)
            {
                transform.Translate(transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.Translate(-transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else if (currentState == "Attack")
        {
            animator.SetBool("attacking", true);
            if (distance > attackRange)
            {
                currentState = "Chase";
            }
        }
    }

    public void TakeDmg(int dmg)
    {
        Health -= dmg;
        currentState = "Chase";
        if(Health < 0)
        {
            Die();
            BossAlive = false;
            PlayerManager.enemiesKilled++;
        }
    }

    public void Die()
    {
        animator.SetTrigger("dead");

        GetComponent<CapsuleCollider>().enabled = false;
        this.enabled = false;

    }
}
