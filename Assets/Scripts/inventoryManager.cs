using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryManager : MonoBehaviour
{
    public int corn = 0;
    public int powerstored = 0;
    public double credits = 0;
    public double energy = 0;

    // UI COMPONENTS //

    public Text cornTxt;
    public Text potatoTxt;
    public Text caneTxt;
    public Text creditsTxt;
    public Text energyTxt;


    // ----------- UI UPDATES -----------

    void updateUI()
    {
        updateCredits();
        updateCorn();
    }

    void updateCredits()
    {
        creditsTxt.GetComponent<Text>().text = "" + credits;
    }

    void updateCorn()
    {
        cornTxt.GetComponent<Text>().text = "" + corn;
    }

    void updateEnergy()
    {
        energyTxt.GetComponent<Text>().text = energy + " Wh";
    }

    public double returnCredits()
    {
        return credits;
    }
    // ----------- SELLING CODE -----------

    public void soldCorn() // REMOVE FROM INV 
    {
        double corncredits = (corn / 100f);
        addCredits(corncredits);
        corn = 0;
        updateUI();
    }



    // ----------- HARVESTING CODE ----------- 

    public void harvestedCrop()
    {
        corn += 72;
        updateUI();
    }

    public void addCredits(double newcredits)
    {
        credits += newcredits;
        updateUI();
    }

    // ----------- BIOMASS CODE ----------- 

    public void convertCorn()
    {
        generateBiomassEnergy(corn);
    }

    void generateBiomassEnergy(int time)
    {
        for(int i = 0; i < time; i++)
        {
            energy += 0.25;
            updateEnergy();
        }
    }


    // ----------- SPENDING CODE ----------- 

    public void subtractCost(double cost)
    {
        credits -= cost;
        updateUI();
    }

    public bool canAfford(double cost)
    {
        if(credits < cost)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
