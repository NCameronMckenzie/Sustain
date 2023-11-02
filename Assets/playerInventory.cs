using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerInventory : MonoBehaviour
{

    //UI Components
    public int playerUnits = 0;
    public Transform inventoryPanel;
    public GameObject text;
    int cornCount = 0;
    int carrotCount = 0;
    public Dictionary <string, int> inventory = new Dictionary<string, int>();
    public Dictionary <string, bool> cropSlots = new Dictionary<string, bool>();
    bool[] occupiedInv  = new bool[15];

    int money = 0;

    // -- INVENTORY UPDATE --



    // BUY/ADD ITEM

    public void updateItemCount(string itemName, int count){
        Debug.Log(itemName + " " + count);
        if(inventory.ContainsKey(itemName)){
            int temp = (inventory[itemName] + count);
            inventory[itemName] = temp;
            itemUIUpdate(itemName, temp);
        }
        else{
            inventory.Add(itemName, count);
            Debug.Log("f " + inventory[itemName]);
            itemUIUpdate(itemName, count);
        }
    }

    public void addItem(string itemName, int count){
        inventory.Add(itemName, count);
        getOpenSlot();
    }

    public void deductUnits(int subtractUnits){
        playerUnits -= subtractUnits;
    }

    //  SELL/REMOVE ITEM 

    public void sellItem (string itemName, int sellCount){
        if(inventory.ContainsKey(itemName)){
            int temp = (inventory[itemName] - sellCount);
            inventory[itemName] = temp;
            itemUIUpdate(itemName, temp);
        }
        else {
            Debug.Log("BUG: Item is not in player inventory");
        }
    }

    public void removeItem(string itemName){
        inventory.Remove(itemName);
    }

    

   


    // -- UI UPDATE --

    public void itemUIUpdate(string itemName, int count){
        // sets item count on UI    
        //not even rn smh
        findInvItem(itemName).GetChild(0).GetComponent<Text>().text = count.ToString(); 

        // set item count in inventory

        
        //move item to slot position
    }

    private Transform findInvItem (string itemName){
        foreach(Transform child in inventoryPanel){
            if(child.name == itemName){
                Debug.Log("found");
                return child;
            }
        }
        //create Item with name and add it to inventoryPanel
        //run set item location(itemname, checkOpenSlot)
        return null;
    }

    void loadItemObject(){            //instantiate item child of Open Slot

    }

    int getOpenSlot(){
        int nearestOpen=0;
        for(int i = 0; i < occupiedInv.Length - 1; i++){
            if(occupiedInv[i] == true){
                nearestOpen = i-1;
            }
        }
        return nearestOpen;
    }

    void getSlotLoc(int nearestOpen){

    }
    

    

   
}