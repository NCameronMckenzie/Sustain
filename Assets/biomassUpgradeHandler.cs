using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biomassUpgradeHandler : MonoBehaviour
{
    inventoryManager invMgr;
    public GameObject player;
    public GameObject upgradePopup;

    public GameObject potatoUpgradeObj;
    public GameObject caneUpgradeObj;

    public GameObject potatoBuyBtn;
    public GameObject caneBuyBtn;

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
            potatoBuyBtn.SetActive(false);
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
        if (invMgr.canAfford(100))
        {
            caneBuyBtn.SetActive(false);
            caneUpgradeObj.SetActive(true);
            invMgr.subtractCost(100);
        }
        else
        {
            Debug.Log("you can't afford that");
        }
    }
}
