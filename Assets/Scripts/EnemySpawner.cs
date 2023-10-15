using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    public float xBound = 1.6f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawner", 0.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawner()
    {
        Vector3 enemyPos = new Vector3(Random.Range(-xBound, xBound),
                                            transform.position.y,
                                            transform.position.z);

        Instantiate(enemy, enemyPos, transform.rotation);
    }
}
