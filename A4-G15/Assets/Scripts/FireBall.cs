using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public int bossDMG = 40;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            PlayerManager.enemiesKilled++;
        }
        if (other.tag == "Boss")
        {
            other.GetComponent<BossMan>().TakeDmg(bossDMG);

            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            PlayerManager.enemiesKilled++;
        }
        if (collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<BossMan>().TakeDmg(bossDMG);

            Destroy(gameObject);
        }
    }
}
