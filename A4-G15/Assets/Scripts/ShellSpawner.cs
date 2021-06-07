using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellSpawner : MonoBehaviour
{
    public GameObject Shell;
    private GameObject shels;
    public float frequency = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Spawner();
    }

    private void Spawner()
    {
        shels = Instantiate(Shell, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        Invoke("Spawner", frequency);
    }
}
