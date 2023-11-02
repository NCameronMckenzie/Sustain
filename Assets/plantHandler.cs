using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantHandler : MonoBehaviour
{
    public Vector3 scale;
    public Vector3 scaleaddition = new Vector3(0.01f, 0.01f, 0.1f);

    void Start()
    {
        this.transform.localScale = scaleaddition;
    }

    public void growPlant()
    {
        Debug.Log("growing");
        this.gameObject.transform.localScale += scaleaddition;
    }
}
