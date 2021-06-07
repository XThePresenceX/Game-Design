using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    public GameObject Spike;
    private GameObject spik;
    public float frequency = 3f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnerX();
    }

    private void SpawnerX()
    {
        spik = Instantiate(Spike, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        Invoke("SpawnerX", frequency);
    }
}
