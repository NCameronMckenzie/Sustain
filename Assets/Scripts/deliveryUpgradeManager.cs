using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deliveryUpgradeManager : MonoBehaviour
{
    inventoryManager invMgr;
    public GameObject player;
    public GameObject upgradePopup;

    public GameObject potatoUpgradeObj;
    public GameObject caneUpgradeObj;

    void Start()
    {
        invMgr = player.GetComponent<inventoryManager>();
    }

    void OnMouseDown()
    {
        loadUI();
    }

    void loadUI()
    {
        upgradePopup.SetActive(true);
    }

    public void closeUI()
    {
        upgradePopup.SetActive(false);
    }

    public void purchasePotatoUpgrade()
    {
        if (invMgr.canAfford(10))
        {
            potatoUpgradeObj.SetActive(true);
            invMgr.subtractCost(10);
        }
        else
        {
            Debug.Log("you can't afford that");
        }
    }

    public void purchaseCaneUpgrade()
    {
        if (invMgr.canAfford(10))
        {
            caneUpgradeObj.SetActive(true);
            invMgr.subtractCost(10);
        }
        else
        {
            Debug.Log("you can't afford that");

        }
    }
}
