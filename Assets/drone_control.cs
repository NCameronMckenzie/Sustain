using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drone_control : MonoBehaviour
{
        GameObject drone;
        public bool traveling = false;
        public bool test = true;
        public GameObject HomeObj;
        public GameObject DestObj;
        Vector3 droneHome;
        Vector3 droneDest;

    // Start is called before the first frame update
    void Start()
    {
        drone = this.gameObject;
        droneHome = HomeObj.transform.position;
        droneDest = DestObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        drone.transform.position = Vector3.Lerp(drone.transform.position, droneDest, 3 * Time.deltaTime);
        if(Vector3.Distance(drone.transform.position, droneDest) < .1f){
            droneDest = droneHome;
        }
    }
}
