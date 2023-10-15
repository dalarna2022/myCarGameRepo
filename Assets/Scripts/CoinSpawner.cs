using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;

    public float xBound = 1.4f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawner", 0.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawner()
    {
        Vector3 coinPos = new Vector3(Random.Range(-xBound, xBound),
                                            transform.position.y,
                                            transform.position.z);

        Instantiate(coin, coinPos, transform.rotation);
    }
}
