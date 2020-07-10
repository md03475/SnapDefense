using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buildings : MonoBehaviour
{

    public int health;
    private static int BuildingQuantity;
    public string LevelLost;
    public GameObject destructionEffect;
    public GameObject smokeEffect;
    GameObject smokeEffect1;
    GameObject smokeEffect2;
    public GameObject hitEffect;
    GameObject hitEffect1;

    // Use this for initialization
    void Start()
    {
        if (gameObject.tag == "Small")
        {
            health = 10;
        }
        else if (gameObject.tag == "Mid")
        {
            health = 20;
        }
        else if (gameObject.tag == "Tall")
        {
            health = 30;
        }

        BuildingQuantity = 14;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if(gameObject.tag == "Mid")
            {
                Destroy(smokeEffect1);
            }
            else if (gameObject.tag == "Tall")
            {
                Destroy(hitEffect1);
            }
            Instantiate(destructionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            BuildingQuantity = BuildingQuantity - 1;
        }
        /*if (BuildingQuantity <= 0)
        {
            Destroy(gameObject);
            BuildingQuantity = BuildingQuantity - 1;
        }*/
        CheckGameOver(LevelLost);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Enemy") && ((other.gameObject.name == "AsteroidSprite(Clone)") || (other.gameObject.name == "BigAsteroidSprite(Clone)")))
        {
            takeDamage();
        }
       
    }

    public void takeDamage()
    {
        //FindObjectOfType<AudioManager>().Play("collision");

        health = health - 10;
        FindObjectOfType<AudioManager>().Play("broken");
        if ((gameObject.tag == "Mid") && (health == 10))
        {
            smokeEffect1 = Instantiate(smokeEffect, transform.position, transform.rotation);
        }
        else if ((gameObject.tag == "Tall") && (health == 20))
        {
            smokeEffect2 = Instantiate(smokeEffect, transform.position, transform.rotation);
        }
        else if ((gameObject.tag == "Tall") && (health == 10))
        {
            Destroy(smokeEffect2);
            hitEffect1 = Instantiate(hitEffect, transform.position, transform.rotation);
        }
        /*if (BuildingQuantity <= 1)
        {
            Destroy(gameObject);
            BuildingQuantity = BuildingQuantity - 1;
        }*/
    }


    private void CheckGameOver(string x)
    {
        if (BuildingQuantity <= 0)
        {
            SceneManager.LoadScene(x);
        }
    }
}


