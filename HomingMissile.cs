using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{
    public GameObject HMissileObject;
    public GameObject explosionEffect;
    public GameObject flare;
    public GameObject flare2;

    public static HomingMissile hm;

    bool activated = false;

    public Vector3 RespawnPosition;
    public Quaternion RespawnRotation;

    public float speed;
    public int angularspeed;
    public float rotateSpeed;

    public Transform target;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("spaceship").transform;

        if (hm = null)
        {
            HMissileObject = GameObject.FindGameObjectWithTag("2");
        }

        speed = 4;

        activated = false;
        RespawnRotation = transform.rotation;
        RespawnPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        angularspeed = 4;


    }

    // Update is called once per frame
    void Update()
    {
        if (flare2 != null)
        {
            flare2.transform.position = this.transform.position;
        }
    }

    void FixedUpdate()
    {
        if (activated == true)
        {
            Aim();
            if (Input.GetMouseButtonDown(0))
            {
                SetTarget();
            }
        }
        if (target != null)
        {
            Fire();
            //activated = false;
        }
    }

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
            target = null;
            Instantiate(explosionEffect, transform.position, transform.rotation);
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
        GameObject missile = Instantiate(HMissileObject);
        missile.transform.position = RespawnPosition;
        missile.transform.rotation = RespawnRotation;
    }


    //private void SetTarget()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        if (hit.transform.tag == "Enemy")
    //        {
    //            target = hit.transform;
    //        }
    //    }
    //}

    private void SetTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                this.target = hit.collider.transform;
                flare2 = Instantiate(flare, transform.position, transform.rotation);
            }
        }
    }

    private void Fire()
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        FindObjectOfType<AudioManager>().Play("collision");
        rb.velocity = transform.up * speed;
        activated = false;
        FindObjectOfType<MissileManager>().allowActivation = true;
    }

    private void Aim()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, angularspeed * Time.deltaTime);
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




    
