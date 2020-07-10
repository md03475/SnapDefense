using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner3 : MonoBehaviour
{
    public GameObject meteoride;
    public GameObject missile;
    public GameObject ufo;
    Vector2 WheretoSpawn;
    float spawnRate = 3f;
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
            ufo = GameObject.Find("UFO");
            WheretoSpawn = new Vector2(ufo.transform.position.x, transform.position.y);
            int choose = Random.Range(0, 2);
            if (choose == 0)
            {
                GameObject a = Instantiate(meteoride, WheretoSpawn, Quaternion.identity) as GameObject;
            }
            else
            {
                angle = Random.Range(160, 200);
                GameObject b = Instantiate(missile, WheretoSpawn, Quaternion.Euler(0,0,angle)) as GameObject;
            }
        }
    }
}
