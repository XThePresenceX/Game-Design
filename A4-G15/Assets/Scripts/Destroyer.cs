using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float lifeDuration;

    void Start()
    {
        Destroy(gameObject, lifeDuration);
    }

}
