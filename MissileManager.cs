using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileManager : MonoBehaviour
{
    public string left;
    public string center;
    public string right;

    public Vector3 leftposition;
    public Vector3 centerposition;
    public Vector3 rightposition;

    public GameObject normal;
    public GameObject homing;
    public GameObject cluster;

    public bool allowActivation = true;

    // Start is called before the first frame update
    void Start()
    {
        left = PlayerPrefs.GetString("Left", "Normal");
        center = PlayerPrefs.GetString("Center", "Normal");
        right = PlayerPrefs.GetString("Right", "Normal");

        leftposition = new Vector3(-9.27f, -4.5f, 0f);
        centerposition = new Vector3(0f, -4.5f, 0f);
        rightposition = new Vector3(9.65f, -4.5f, 0f);

        if (left == "Normal")
        {
            GameObject left = Instantiate(normal);
            left.transform.position = leftposition;
        }
        else if (left == "Homing")
        {
            GameObject left = Instantiate(homing);
            left.transform.position = leftposition;
        }
        else
        {
            GameObject left = Instantiate(cluster);
            left.transform.position = leftposition;
        }


        if (center == "Normal")
        {
            GameObject center = Instantiate(normal);
            center.transform.position = centerposition;
        }
        else if (center == "Homing")
        {
            GameObject center = Instantiate(homing);
            center.transform.position = centerposition;
        }
        else
        {
            GameObject center = Instantiate(cluster);
            center.transform.position = centerposition;
        }


        if (right == "Normal")
        {
            GameObject right = Instantiate(normal);
            right.transform.position = rightposition;
        }
        else if (right == "Homing")
        {
            GameObject right = Instantiate(homing);
            right.transform.position = rightposition;
        }
        else
        {
            GameObject right = Instantiate(cluster);
            right.transform.position = rightposition;
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
