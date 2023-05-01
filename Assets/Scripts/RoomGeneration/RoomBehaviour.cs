using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    public GameObject freeChest, commonChest, rareChest, epicChest, legendaryChest;
    // Start is called before the first frame update
    void Start()
    {
        int isChest = Random.Range(0, 101);
        if (isChest <= 40)
        {
            int value = Random.Range(0, 101);
            if (value <= 15)
                Instantiate(freeChest, transform);
            else if (value > 15 && value <= 25)
                Instantiate(legendaryChest, transform);
            else if (value > 25 && value <= 60)
                Instantiate(commonChest, transform);
            else if (value > 60 && value <= 75)
                Instantiate(epicChest, transform);
            else if (value > 75 && value <= 100)
                Instantiate(rareChest, transform);
        }
        else if (isChest > 40 && isChest <= 50)
            Debug.Log("Workbench");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
