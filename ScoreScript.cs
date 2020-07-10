using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int value;
    public Text score;

    private void Awake()
    {
        value = PlayerPrefs.GetInt("Highscore", 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        //score.text = PlayerPrefs.GetInt("Highscore", 5).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = value.ToString();
    }

    public void StoreScore()
    {
        PlayerPrefs.SetInt("Highscore", value);
        //score.text = value.ToString();
    }
}


