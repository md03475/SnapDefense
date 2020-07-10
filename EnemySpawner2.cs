using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemySpawner2 : MonoBehaviour
{

    public GameObject missile;
    float randX;
    Vector2 WheretoSpawn;
    float spawnRate = 3.5f;
    float nextSpawn = 0.0f;
    int total = 20;
    public string LevelWin;
    int angle;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time > nextSpawn) & (total > 0))
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-10.55f, 10.55f);
            WheretoSpawn = new Vector2(randX, transform.position.y);
            angle = Random.Range(160, 200);
            GameObject b = Instantiate(missile, WheretoSpawn, Quaternion.Euler(0,0,angle)) as GameObject;
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
