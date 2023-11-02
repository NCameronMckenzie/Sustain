using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cropHandler : MonoBehaviour
{

    int UVcount = 0;
    int superSeedcount = 0;
    bool cropReady = false;

    public GameObject farmland;
    GameObject currentCrop;
    cropManager cropMgr;
    public farmland_handler farmMgr;

    Vector3 growthAmount = new Vector3 (.1f, .1f, .1f);

    float growingInterval = 5f;
    

    // Start is called before the first frame update

    //addsize method for a lerping growth animation
    void Start()
    {
        //StartCoroutine(LerpGrow());
        farmMgr = farmland.GetComponent<farmland_handler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void setFinished(){
        //runs after it's done growing
        farmMgr.addCroptoFinished(this.transform);
    }

    public void setGrowthInterval(int growthSpeedAdded){
        growingInterval-=growthSpeedAdded;
    }
    /*
    void addSize(){
        growing = true;
        MathLerp current size to goal 
    }
    */

    public void setFarmland(GameObject parent){
        farmland = parent;
    }

    public void startGrowth(){
        StartCoroutine(Grow());
    }

    IEnumerator Grow(){
        if(this.gameObject.transform.localScale.z < 1f){
            this.gameObject.transform.localScale += new Vector3(.2f,.2f,.2f);
            yield return new WaitForSeconds(growingInterval);
            StartCoroutine(Grow());
        }
        else{
            setFinished();
        }
    }

    /*
    IEnumerator LerpGrow(){ 
        Debug.Log("Growing");
        float time = 1;
        
        while(time < growingInterval){
             this.gameObject.transform.localScale = Vector3.Lerp(this.gameObject.transform.localScale, this.gameObject.transform.localScale + new Vector3(0,0,.2f), time / growingInterval);
             time += Time.deltaTime;
             yield return new WaitForSeconds(3f);
             if(this.gameObject.transform.localScale.z < 1f){
                Debug.Log(this.gameObject.transform.localScale.z);
                StartCoroutine(Grow());
                yield return null;
             }
             else{
                  Debug.Log("big enough");
                  yield return null;
             }
             setFinished();
             Debug.Log("Local scale" + this.gameObject.transform.localScale);
        }
    }
    */


    public void updateCrop(cropManager cm)
    {
        //cropMgr = currentCrop.GetComponent<cropManager>();
        cropMgr = cm;
    }

    

    public void harvest()
    {
        cropMgr.harvestCrops();
    }

    public void plant()
    {
        cropMgr.plantCrops();
    }

    public void loadCurrentCrop(GameObject cropref)
    {
        currentCrop = cropref;
    }
}
