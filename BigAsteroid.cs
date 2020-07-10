using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAsteroid : MonoBehaviour
{
    public GameObject child;
    Vector2 WheretoSpawn1;
    Vector2 WheretoSpawn2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime); //rotates 50 degrees per second around z axis
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "1") || (other.gameObject.tag == "2") || (other.gameObject.tag == "detector") || (other.gameObject.tag == "4"))
        {
            WheretoSpawn1 = new Vector2(transform.position.x + 1, transform.position.y+1);
            WheretoSpawn2 = new Vector2(transform.position.x - 1, transform.position.y+1);
            Destroy(gameObject);
            GameObject a = Instantiate(child, WheretoSpawn1, Quaternion.identity) as GameObject;
            GameObject b = Instantiate(child, WheretoSpawn2, Quaternion.identity) as GameObject; 
        }
        else if (other.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
