using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UFO : MonoBehaviour
{
    float delta = 7.5f;  // Amount to move left and right from the start point
    float speed = 0.5f;
    private Vector3 startPos;
    public static float health;
    public string LevelWin;
    void Start()
    {
        health = 2;
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        CheckWin(LevelWin);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "1")
        {
            health = health - 0.2f;
        }
    }

    private void CheckWin(string x)
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(x);
        }
    }
}
