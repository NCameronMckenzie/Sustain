using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class farmland_handler : MonoBehaviour
{
   // assign all children of farmland to an object array
        // set variables for growth speed & upgrade level
        // make method for updating growth speed for all children
        // make method for adding finished growing crops to a finished array
        // make method for harvesting finished crops
        // make method for planting crops in open spaces
               
        public GameObject EventSystem;
        
        public List<Transform> openPlots = new List<Transform>();
        public List<Transform> plots = new List<Transform>();
        public Transform corn;
        Transform chosenPlant;
        public List<Transform> finishedPlants = new List<Transform>();
        static List<Transform> allPlants = new List<Transform>();
        farmlandUpgradeHandler farmUpgrades;

        static int growthSpeed=0;

    void Start()
    {
        
       findChildren();
       farmUpgrades = this.GetComponent<farmlandUpgradeHandler>();
       chosenPlant = corn;
    }

    void updateGrowthSpeed(){
        growthSpeed = farmUpgrades.getGrowthSpeed();
    }

    static int getGrowthSpeed(){
        return growthSpeed;
    }

    public void addFinishedPlants(Transform plant){
        finishedPlants.Add(plant);
    }
    
    public void addCroptoFinished(Transform finishedCrop){
        addFinishedPlants(finishedCrop);
        
    }

    void findChildren () {
        foreach(Transform child in this.transform){
            plots.Add(child);
        }
        findOpenPlots();
    }

    void findOpenPlots(){
        foreach(Transform plot in plots){
            if(plot.GetComponent<plotHandler>().Occupied == false){
                openPlots.Add(plot);
            }
        }
    }

    public void btnPlant(){
        plantOpenPlots(openPlots, chosenPlant);
        updateGrowthSpeed();
    }

    static void plantOpenPlots(List<Transform> openPlots, Transform chosenPlant){
        foreach(Transform plot in openPlots){
            spawnPlant(chosenPlant, plot.transform.position);
            // will be moved after growing is implemented
            
        }
    }

    static void spawnPlant(Transform chosenPlant, Vector3 plotPos){
        cropHandler cropCode;
        

        Transform temp = Instantiate(chosenPlant, plotPos, Quaternion.Euler(-90,0,0));
        cropCode = temp.GetComponent<cropHandler>();
        cropCode.setGrowthInterval(getGrowthSpeed());
        temp.gameObject.SetActive(true);
        cropCode.startGrowth();
        
        addNewPlant(temp);
    }

    static void addNewPlant(Transform newplant){
        allPlants.Add(newplant);
    }

    public void btnHarvest(string itemName){
        harvestCrops(itemName);
    }

    void harvestCrops(string itemName){
        int harvestCount = 0;
        foreach(Transform plant in finishedPlants){
            Destroy(plant.gameObject);
            harvestCount++;
        }
        finishedPlants.Clear();
        givePlayerCrops(itemName, harvestCount);
    }

    void givePlayerCrops(string itemName, int harvestCount){ //for after they harvest
        EventSystem.GetComponent<playerInventory>().updateItemCount(itemName, harvestCount);
    }


}
