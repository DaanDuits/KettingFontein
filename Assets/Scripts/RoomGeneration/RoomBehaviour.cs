using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    public enum RoomType
    {
        Empty,
        FreeChest,
        CommonChest,
        RareChest,
        EpicChest,
        LegendaryChest,
        Workbench
    }

    public RoomType type;
    // Start is called before the first frame update
    void Start()
    {
        int isChest = Random.Range(0, 101);
        if (isChest <= 45)
        {
            int value = Random.Range(0, 101);
            if (value <= 10)
                type = RoomType.FreeChest;
            else if (value > 10 && value <= 20)
                type = RoomType.LegendaryChest;
            else if (value > 20 && value <= 60)
                type = RoomType.CommonChest;
            else if (value > 60 && value <= 75)
                type = RoomType.EpicChest;
            else if (value > 75 && value <= 100)
                type = RoomType.RareChest;
        }
        else if (isChest > 45 && isChest <= 55)
            type = RoomType.Workbench;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
