using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{

    private GameObject P1;
    public GameObject E1;
    private GameObject temp;
    private GameObject temp2;
    public GameObject BR;
    public float radius = 5.0F;
    public float power = 10.0F;
    //public GameObject skin;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", 5f);
        Physics.IgnoreLayerCollision(10,12,true);
        P1 = GameObject.FindGameObjectWithTag("Player");
        //BR.GetComponent<MeshRenderer>().enabled = true;
        //Explode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explode()
    {
        //P1 = GameObject.FindWithTag("Player");
        Vector3 playerPOS = P1.gameObject.transform.position;
        temp =  Instantiate(E1, playerPOS, Quaternion.identity);
        Vector3 explosionPos = temp.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        //Debug.Log(P1.gameObject.transform.position);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F, ForceMode.Acceleration);
               

               // P1.GetComponent<Rigidbody>().velocity = new Vector3(20, 10, 0);
                //P1.GetComponent<Rigidbody>().isKinematic = true ;
                // P1.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0F, ForceMode.Acceleration);
                //P1.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        Invoke("Detonate", 2f);

        Invoke("Explode", 9f);
    } 

    void Detonate()
    {
        //P1.GetComponent<Rigidbody>().isKinematic = false;
        //Invoke("makeItTrue", 0.7f);
        Destroy(temp);
        //E1.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        temp2 = Instantiate(BR, temp.gameObject.transform.position, Quaternion.identity);
        //BR.GetComponent<MeshRenderer>().enabled = true;
        DamageDone();
        Invoke("turnOffRadius", 1f);
    }

    void makeItTrue()
    {
        P1.GetComponent<Rigidbody>().isKinematic = true;
        P1.transform.eulerAngles = new Vector3(0, 0, 0);
    }
    void DamageDone()
    {
        float offDistance = Mathf.Abs(temp2.transform.position.x - P1.transform.position.x);
        //Debug.Log(offDistance);
        if (offDistance < 1.25f) { SoundManager.PlaySound("Nani"); PlayerManager.PHealth -= 101; } 
        else if (offDistance < 2.5f) { SoundManager.PlaySound("Nani"); PlayerManager.PHealth -= 50; }
        else if (offDistance < 4f) { SoundManager.PlaySound("Nani"); PlayerManager.PHealth -= 20; }
        else { }
    }

    void turnOffRadius()
    {
        Destroy(temp2);
    }
}
