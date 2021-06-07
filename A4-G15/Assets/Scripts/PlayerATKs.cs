using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerATKs : MonoBehaviour
{
    public GameObject fireBall;
    public GameObject Beam;
    public Transform fireBallPoint;
    public float fireBallSpeed = 400;
    public float BeamSpeed = 600;

   // [SerializeField] private Transform beamTip;
   // private Vector3 lookDir;
   // private float lookangle;

    /*void Update()
    {
        lookDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookangle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookangle - 90f);
        if (Input.GetMouseButtonDown(0))
        {
            BeamATK();
        }
    }*/
    public void FireBallATK()
    {
        GameObject Ball = Instantiate(fireBall, fireBallPoint.position, Quaternion.identity);
        SoundManager.PlaySound("Fireball");
        Ball.GetComponent<Rigidbody>().AddForce(fireBallPoint.forward * fireBallSpeed);
    }
     
    public void BeamATK()
    {
        GameObject BeamX = Instantiate(Beam, fireBallPoint.position, Quaternion.Euler(0, 0, 90));
        SoundManager.PlaySound("Beam");
        //BeamX.GetComponent<Rigidbody>().AddForce(fireBallPoint.forward * BeamSpeed);
        //BeamX.GetComponent<Rigidbody>().velocity = new Vector3(20, 0, 0);
        BeamX.GetComponent<Rigidbody>().AddForce(fireBallPoint.forward * BeamSpeed);
    }

}
