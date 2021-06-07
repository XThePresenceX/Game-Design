using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    public GameObject bullet;
    private GameObject bull;
    private GameObject P1;
    public Transform shootingPoint;
    public float shotsPerSeconds;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        P1 = GameObject.FindWithTag("Player");  
    }

    // Update is called once per frame
    void Update()
    {
        float probability = Time.deltaTime * shotsPerSeconds;
        if (Random.value < probability)
        {
            Fire();
        }
    }

    void Fire()
    {
        bull = Instantiate(bullet, shootingPoint.position, Quaternion.identity);
        bull.GetComponent<Rigidbody>().velocity = (P1.gameObject.transform.position - shootingPoint.gameObject.transform.position).normalized * speed;
        //bull.GetComponent<Rigidbody>().AddForce((P1.gameObject.transform.position - bullet.gameObject.transform.position).normalized * speed);
        //bullet.gameObject.velocity = (player.position - bullet.position).normalized * constant;
        Destroy(bull, 1f);
    }

 

    /*    {
    GameObject Ball = Instantiate(fireBall, fireBallPoint.position, Quaternion.identity);
    Ball.GetComponent<Rigidbody>().AddForce(fireBallPoint.forward* fireBallSpeed);*/
}
