using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public int funds;
    public Text score;
    public int HomingCost;
    public int ClusterCost;

    public Button HomingButton;
    public Button ClusterButton;

    public Text Homingbuttontext;
    public Text Clusterbuttontext;

    public bool HomingPurchased;
    public bool ClusterPurchased;

    public Transform Left;
    public Transform Center;
    public Transform Right;

    public GameObject normalDrag;
    public GameObject homingDrag;
    public GameObject clusterDrag;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("HomingPurchased", 0);
        //PlayerPrefs.SetInt("ClusterPurchased", 0);
        HomingCost = 10000;
        ClusterCost = 25000;
        score.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        funds = PlayerPrefs.GetInt("Highscore", 0);
        var hflag = PlayerPrefs.GetInt("HomingPurchased", 0);
        var cflag = PlayerPrefs.GetInt("ClusterPurchased", 0);
        if (hflag == 1)
        {
            HomingPurchased = true;
            homingDrag.SetActive(true);
        }
        else if (hflag == 0)
        {
            HomingPurchased = false;
            homingDrag.SetActive(false);
        }

        if (cflag == 1)
        {
            ClusterPurchased = true;
            clusterDrag.SetActive(true);
        }
        else if (cflag == 0)
        {
            ClusterPurchased = false;
            clusterDrag.SetActive(false);
        }

        CheckHoming();
        CheckCluster();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = PlayerPrefs.GetInt("Highscore", 0).ToString();

        var hflag = PlayerPrefs.GetInt("HomingPurchased", 0);
        var cflag = PlayerPrefs.GetInt("ClusterPurchased", 0);
        if (hflag == 1)
        {
            HomingPurchased = true;
            homingDrag.SetActive(true);
        }
        else if (hflag == 0)
        {
            HomingPurchased = false;
            homingDrag.SetActive(false);
        }

        if (cflag == 1)
        {
            ClusterPurchased = true;
            clusterDrag.SetActive(true);
        }
        else if (cflag == 0)
        {
            ClusterPurchased = false;
            clusterDrag.SetActive(false);
        }
    }

    public void PurchaseHoming()
    {
        if ((funds >= HomingCost) && !HomingPurchased)
        {
            HomingPurchased = true;
            Homingbuttontext.text = "Already Purchased";
            PlayerPrefs.SetInt("HomingPurchased", 1);
            funds = funds - HomingCost;
            PlayerPrefs.SetInt("Highscore", funds);
            HomingButton.interactable = false;
        }
    }

    public void PurchaseCluster()
    {
        if ((funds >= ClusterCost) && !ClusterPurchased)
        {
            ClusterPurchased = true;
            Clusterbuttontext.text = "Already Purchased";
            PlayerPrefs.SetInt("ClusterPurchased", 1);
            funds = funds - ClusterCost;
            PlayerPrefs.SetInt("Highscore", funds);
            ClusterButton.interactable = false;
        }
    }

    private void CheckHoming()
    {
        if (HomingPurchased)
        {
            Homingbuttontext.text = "Already Purchased";
            HomingButton.interactable = false;
        }
    }

    private void CheckCluster()
    {
        if (ClusterPurchased)
        {
            Clusterbuttontext.text = "Already Purchased";
            ClusterButton.interactable = false;
        }
    }

    public void Apply()
    {
        if (Left.childCount > 0 && Center.childCount > 0 && Right.childCount > 0)
        {
            var left = Left.GetChild(0).name;
            var center = Center.GetChild(0).name;
            var right = Right.GetChild(0).name;

            if (left.StartsWith("normal"))
            {
                PlayerPrefs.SetString("Left", "Normal");
            }
            else if (left.StartsWith("homing"))
            {
                PlayerPrefs.SetString("Left", "Homing");
            }
            else
            {
                PlayerPrefs.SetString("Left", "Cluster");
            }

            if (center.StartsWith("normal"))
            {
                PlayerPrefs.SetString("Center", "Normal");
            }
            else if (center.StartsWith("homing"))
            {
                PlayerPrefs.SetString("Center", "Homing");
            }
            else
            {
                PlayerPrefs.SetString("Center", "Cluster");
            }

            if (right.StartsWith("normal"))
            {
                PlayerPrefs.SetString("Right", "Normal");
            }
            else if (right.StartsWith("homing"))
            {
                PlayerPrefs.SetString("Right", "Homing");
            }
            else
            {
                PlayerPrefs.SetString("Right", "Cluster");
            }

            Debug.Log("left" + PlayerPrefs.GetString("Left"));
            Debug.Log("center" + PlayerPrefs.GetString("Center"));
            Debug.Log("right" + PlayerPrefs.GetString("Right"));
        }
    }
}
