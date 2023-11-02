using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class farmlandUpgradeHandler : MonoBehaviour
{
    bool soilUpgrade = false; 

    public List<GameObject> upgrades = new List<GameObject>();
    
    public int growthSpeedAdded = 0;

    public void setUpgrade1Active(){
        upgrades[0].gameObject.SetActive(true);
        growthSpeedAdded++;
    }

    public void setUpgrade2Active(){
        upgrades[1].gameObject.SetActive(true);
        growthSpeedAdded+=2;
    }

    public int getGrowthSpeed(){
        return growthSpeedAdded;
    }


}
