using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public GameObject player;

    //public GameObject cam;

    public Vector3 offset;

    public int speed;

    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position + offset, speed * Time.deltaTime);
    }
}
