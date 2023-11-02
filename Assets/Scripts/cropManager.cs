using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cropManager : MonoBehaviour
{
    public GameObject player;
    inventoryManager invMgr;

    public GameObject plantBtn;
    public GameObject harvestBtn;

    public GameObject cropParent;

    // UV LIGHT GROUP //
    public Transform UVLightParent;
    //GameObject[] uvLights;
    //int activeUVCount = 0;

    // CROP INFO //
    int UVcount = 0;
    int superSeedcount = 0;
    bool cropReady = false;

    public GameObject UIContainer;

    // BUTTONS //
    public Button buyUV;
    public Button buySSeeds;
    public Button exitBtn;

    // TEXT //
    public Text title;
    public Text upgrades;

    // COST //
    public int UVcost;
    public int SScost;

    bool empty = false;



    // Start is called before the first frame update
    void Start()
    {
        invMgr = player.GetComponent<inventoryManager>();
        cropParent = this.transform.Find("corn_stalks").gameObject;
        //uvLights = new GameObject[12];
        //int temp = 0;
        /*
        foreach (Transform child in UVLightParent)
        {
            uvLights[temp] = child.gameObject;
            temp++;
        }
        */
    }


    void OnMouseDown()
    {
        UIContainer.GetComponent<cropHandler>().updateCrop(this);
        load();
    }

    void load()
    {
        UIContainer.SetActive(true);
        if (empty)
        {
            plantBtn.SetActive(true);
        }
        else if (cropReady)
        {
            harvestBtn.SetActive(true);
        }
    }

    public void exit()
    {
        UIContainer.SetActive(false);
    }
    public void doneGrowing()
    {
        cropReady = true;
        //Debug.Log("done growing");
        harvestBtn.SetActive(true);
    }


    public void harvestCrops()
    {
        if (cropReady)
        {
            cropParent.GetComponent<GrowControl>().harvestCrops();
            invMgr.harvestedCrop();
            empty = true;
            cropReady = false;
            harvestBtn.SetActive(false);
            plantBtn.SetActive(true);
        }
    }

    public void plantCrops()
    {
        cropParent.GetComponent<GrowControl>().plantCrops();
        plantBtn.SetActive(false);
        empty = false;

    }

    /*
    public void purchaseUV()
    {
        if (invMgr.canAfford(UVcost) && !fullUVCheck())
        {
            addUV();
        }
    }

    bool fullUVCheck()
    {
        if(activeUVCount < 11)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void addUV()
    {
        uvLights[activeUVCount].SetActive(true);
        activeUVCount++;
    }
    */
}
