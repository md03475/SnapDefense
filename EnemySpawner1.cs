using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemySpawner1 : MonoBehaviour
{

    public GameObject meteoride;
    public GameObject bigMeteoride;
    public string LevelWin;
    float randX;
    Vector2 WheretoSpawn;
    float spawnRate = 5f;
    float nextSpawn = 0.0f;
    int total = 15;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time > nextSpawn) & (total>0))
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-10.55f, 10.55f);
            WheretoSpawn = new Vector2(randX, transform.position.y);
            int choose = Random.Range(0, 2);
            if (choose == 0)
            {
                GameObject a = Instantiate(meteoride, WheretoSpawn, Quaternion.identity) as GameObject;
            }
            else
            {
                GameObject c = Instantiate(bigMeteoride, WheretoSpawn, Quaternion.identity) as GameObject;
            }
            total = total - 1;
            
        }

        CheckWin(LevelWin);



        //Debug.Log(spawnRate);
    }
    private void CheckWin(string x)
    {
        if (total <= 0)
        {
            SceneManager.LoadScene(x);
        }
    }
}
