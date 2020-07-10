using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "AsteroidSprite(Clone)")
        {
            transform.Rotate(0, 0, 50 * Time.deltaTime); //rotates 50 degrees per second around z axis
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
