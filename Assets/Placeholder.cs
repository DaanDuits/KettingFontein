using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeholder : MonoBehaviour
{
    public GameObject chest;
    public bool clearedRoom;
    // Update is called once per frame
    void Update()
    {
        if (clearedRoom)
        {
            new Chest(chest, new Vector3(0, 0), Random.Range(0,3));
            clearedRoom = false;
        }
    }
}
