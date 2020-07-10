using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject meteoride;
    public GameObject missile;
    public GameObject bigMeteoride;
    float randX;
    Vector2 WheretoSpawn;
    float spawnRate = 8f;
    float nextSpawn = 0.0f;
    int angle;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-10.55f, 10.55f);
            WheretoSpawn = new Vector2(randX, transform.position.y);
            int choose = Random.Range(0, 3);
            if (choose == 0)
            {
                GameObject a = Instantiate(meteoride, WheretoSpawn, Quaternion.identity) as GameObject;
            }
            else if (choose == 1)
            {
                GameObject c = Instantiate(bigMeteoride, WheretoSpawn, Quaternion.identity) as GameObject;
            }
            else
            {
                angle = Random.Range(160, 200);
                GameObject b = Instantiate(missile, WheretoSpawn, Quaternion.Euler(0,0,angle)) as GameObject;
            }
        }

        if (spawnRate > 1)
        {
            spawnRate -= 0.0004f;
        }

   

        //Debug.Log(spawnRate);
    }
}
