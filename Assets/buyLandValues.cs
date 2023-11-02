using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class buyLandValues : MonoBehaviour
{
    public GameObject thispopup;
    public int cost;

    public Text buyCostTxt;

    public GameObject parentStation;

    public void setParentStation(GameObject parent)
    {
        parentStation = parent;
        
    }

    public void setCost(int newcost)
    {
        buyCostTxt.text = "" + newcost;
        cost = newcost;
    }

    public void exit()
    {
        thispopup.SetActive(false);
    }

    public void buy()
    {
        parentStation.GetComponent<buyLandHandler>().buy(cost);
    }
}
