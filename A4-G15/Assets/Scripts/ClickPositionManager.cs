using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPositionManager : MonoBehaviour
{

    public LayerMask clickMask;
    public GameObject P1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = -Vector3.one;

            //clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //clickPosition.z = clickPosition.z * 0;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast( ray, out hit, 100f, clickMask))
            {
                clickPosition = hit.point;
            }
            clickPosition.z = clickPosition.z * 0;
            clickPosition.y = clickPosition.y + 2;
            Debug.Log(clickPosition);

            P1.transform.position = clickPosition;
            //Destroy(GameObject.FindWithTag("Player"));
           // Instantiate(P1, clickPosition, Quaternion.identity);
        }
    }
}
