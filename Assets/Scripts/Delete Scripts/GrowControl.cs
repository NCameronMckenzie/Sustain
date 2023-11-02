using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowControl : MonoBehaviour
{
    public GameObject stationComp;
    public GameObject [] crops;
    int growcount = 0;

    void Start()
    {
        crops = new GameObject[72];
        int temp = 0;
        foreach (Transform child in transform)
        {
            crops[temp] = child.gameObject;
            temp++;
        }

        StartCoroutine("GrowCropLoop");
        
    }

    public void plantCrops()
    {
        growcount = 0;
        for (int i = 0; i <= 71; i++)
        {
            crops[i].SetActive(true);
            crops[i].transform.localScale = new Vector3(0, 0, 0);
        }
        StartCoroutine("GrowCropLoop");

    }

    IEnumerator GrowCropLoop()
    {
        

        if (growcount <= 20)
        {
            growCrops();
            growcount++;
            yield return new WaitForSeconds(2f);
            StartCoroutine("GrowCropLoop");
        }
        else
        {
            stationComp.GetComponent<cropManager>().doneGrowing();
        }

    }

    void growCrops()
    {
        for(int i = 0; i <= 71; i++)
        {
            crops[i].GetComponent<plantHandler>().growPlant();
        }
    }
    /*
    public void plantCrops()
    {
        for (int i = 0; i <= 71; i++)
        {
            crops[i].SetActive(true);
        }
        StartCoroutine("GrowCropLoop");
    }
    */
    public void harvestCrops()
    {
        for (int i = 0; i <= 71; i++)
        {
            crops[i].transform.localScale = new Vector3(0, 0, 0);
            crops[i].SetActive(false);
        }
    }
}
