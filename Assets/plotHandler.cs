using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plotHandler : MonoBehaviour
{
    public bool Occupied = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleOccupied (){
        if(!Occupied)
            Occupied = true;
        else
            Occupied = false;
    }
}
