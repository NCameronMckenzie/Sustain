using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvSlotHandler : MonoBehaviour
{
     public Sprite image;
     public bool occupied = false;
     public Vector3 position;
     public int count;

     public void setImage(string spriteName){
        //locate an image out of the image database and assign that image
        // make image on UI object this sprite
     }

     public void setOccupied(bool isOccupied){
          occupied = isOccupied;
     }

     public bool getOccupied(){
          return occupied;
     }

     public void setCount(int newCount){
          count = newCount;
          //update UI text to new Count
     }

     public Vector3 getPosition(){
          return position;
     }




}
