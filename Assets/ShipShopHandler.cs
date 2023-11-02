using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShopHandler : MonoBehaviour
{
    public playerInventory inv;
    public int playerUnits = 0;
    public Dictionary<string, int> shopInventory = new Dictionary<string, int>();


    // Update is called once per frame
    void Start()
    {
        inv = this.gameObject.GetComponent<playerInventory>();
    }

    public void shopOpened(){
        shopInventory.Add("Upgrade1", 5);
        shopInventory.Add("Upgrade2", 10);
    }

    public void playerPurchase(string itemName){
        int cost = shopInventory[itemName];

        if(playerUnits >= cost){
            inv.deductUnits(playerUnits - cost);
            inv.addItem(itemName, 1);
        }
        else{
            Debug.Log("You do not have enough units for this item");
        }
    }
}
