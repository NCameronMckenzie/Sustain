using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cropDelivery : MonoBehaviour
{
    public GameObject player;
    inventoryManager invMgr;

    public GameObject CornConfirmUI;

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
        CornConfirmUI.SetActive(true);
    }

    public void closeUI()
    {
        CornConfirmUI.SetActive(false);
    }

    public void DeliverCorn()
    {
        invMgr.soldCorn();
    }
}
