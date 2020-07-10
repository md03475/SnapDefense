 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MissileBatteries : MonoBehaviour
{
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        health = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(health);
        if (health <= 0)
        {
            Destroy(gameObject);
            
        }
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
        health = health - 0.05f;
    }
}
