using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyLandHandler : MonoBehaviour
{
    public GameObject player;
    inventoryManager invMgr;

    public GameObject buyPopUp;

    public GameObject landObj;

    double currentcredits = 0;
    public int cost = 0;


    void Start()
    {
        invMgr = player.GetComponent<inventoryManager>();
    }

    void OnMouseDown()
    {
        currentcredits = invMgr.returnCredits();
        buyPopUp.GetComponent<buyLandValues>().setParentStation(this.gameObject);
        buyPopUp.GetComponent<buyLandValues>().setCost(cost);
        loadUI();
    }

    void loadUI()
    {
        buyPopUp.SetActive(true);
    }

    public void exit()
    {
        buyPopUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buy(int cost)
    {
        if(currentcredits < cost)
        {
            Debug.Log("You can't afford this");
        }
        else
        {
            invMgr.subtractCost(cost);
            spawnLand();
        }
    }

    void spawnLand()
    {
        this.gameObject.SetActive(false);
        landObj.SetActive(true);
    }
}
