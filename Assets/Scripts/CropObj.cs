using System.Collections;
using UnityEngine;

public class CropObj
{
	public string itemName;
	public int count;
	public int invSlot;


	public CropObj(string itemName){

		itemName = this.itemName;	
		count = 0;
		invSlot = 0;

	}

	public int getCount(){
		return count;
	}

	public void setCount(int newCount){
		count = newCount;
	}

	public int getSlot(){
		return invSlot;
	}

	public void setSlot(int newSlot){
		invSlot = newSlot;
		//actual vector3 movement will be handled in the inventory script
	}
}
