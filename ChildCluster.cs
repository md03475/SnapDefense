using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ChildCluster : MonoBehaviour
{
    public static FriendlyMissile cc;

    public GameObject CCObject;
    public int speed;
    private Rigidbody2D CCBody;
    public GameObject explosionEffect;

    //public ScoreScript scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        if (cc = null)
        {
            CCObject = GameObject.FindGameObjectWithTag("4");
        }

        //speed = 5;
        CCBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        CCBody.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string activeScene = SceneManager.GetActiveScene().name;
        if (other.gameObject.tag == "Enemy")
        {
            if (activeScene == "ArcadeMode")
            {
                FindObjectOfType<ScoreScript>().value += 10;
                FindObjectOfType<ScoreScript>().StoreScore();
            }
            Instantiate(explosionEffect, transform.position, transform.rotation);
            //explosionEffect.
            FindObjectOfType<AudioManager>().Play("Gunshot");
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "boundary")
        {
            Destroy(this.gameObject);
        }
    }

    void OnEnable()
    {
        GameObject[] otherMissiles1 = GameObject.FindGameObjectsWithTag("1");

        foreach (GameObject obj in otherMissiles1)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        GameObject[] otherMissiles2 = GameObject.FindGameObjectsWithTag("2");

        foreach (GameObject obj in otherMissiles2)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        GameObject[] otherMissiles3 = GameObject.FindGameObjectsWithTag("detector");

        foreach (GameObject obj in otherMissiles3)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        GameObject[] otherMissiles4 = GameObject.FindGameObjectsWithTag("4");

        foreach (GameObject obj in otherMissiles4)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
