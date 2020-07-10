using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class FriendlyMissile : MonoBehaviour
{
    public static FriendlyMissile fm;

    bool activated;
    public Vector3 RespawnPosition;
    public Quaternion RespawnRotation;
    public GameObject FMissileObject;
    public int speed;
    public int angularspeed;
    private Rigidbody2D FMissileBody;
    public GameObject explosionEffect;

    public GameObject flare;
    public GameObject flare2;

    public ScoreScript scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        if (fm = null)
        {
            FMissileObject = GameObject.FindGameObjectWithTag("1");
        }

        //speed = 5;
        activated = false;
        RespawnRotation = transform.rotation;
        RespawnPosition = transform.position;
        FMissileBody = GetComponent<Rigidbody2D>();
        angularspeed = 4;
    }

    bool MouseOnObject = false;
    private void OnMouseEnter()
    {
        MouseOnObject = true;
        Debug.Log("mouse");
    }
    private void OnMouseExit()
    {
        MouseOnObject = false;
        Debug.Log("mouse");
    }

    // Update is called once per frame
    void Update()
    {
        if (activated == true)
        {
            Aim();
            if (Input.GetMouseButtonDown(0) && !MouseOnObject)
            {
                Fire();
                //flare.transform.position = this.transform.position;
            }
        }
        if (flare2 != null)
        {
            flare2.transform.position = this.transform.position;
        }
    }

    //private Vector3 Vector3(int v1, int v2, float v3)
    //{
    //    throw new NotImplementedException();
    //}

    private void OnMouseDown()
    {
        if (activated == false && FindObjectOfType<MissileManager>().allowActivation == true)
        {
            activated = true;
            FindObjectOfType<MissileManager>().allowActivation = false;
        }
        else if (activated == true)
        {
            activated = false;
            FindObjectOfType<MissileManager>().allowActivation = true;
        }
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
            Respawn();
            Destroy(this.gameObject);
            Destroy(flare2);
        }
        else if (other.gameObject.tag == "boundary")
        {
            Respawn();
            Destroy(this.gameObject);
            Destroy(flare2);
        }
    }

    private void Respawn()
    {
        GameObject missile = Instantiate(FMissileObject);
        missile.transform.position = RespawnPosition;
        missile.transform.rotation = RespawnRotation;
    }

    private void Fire()
    {
        var mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = gameObject.transform.position.z;
        var mouseWorldSpace = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        gameObject.transform.LookAt(mouseWorldSpace, Camera.main.transform.forward);
        FMissileBody.velocity = transform.up * speed;
        FindObjectOfType<AudioManager>().Play("collision");
        activated = false;
        flare2 = Instantiate(flare, transform.position, transform.rotation);
        FindObjectOfType<MissileManager>().allowActivation = true;
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

    private void Aim()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, angularspeed * Time.deltaTime);
    }
}


