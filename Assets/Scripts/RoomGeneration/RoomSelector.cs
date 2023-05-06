using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomSelector : MonoBehaviour
{
    public RoomInstance[] roomInstances;
    RoomGenerator generator;

    // Start is called before the first frame update
    void Start()
    {
        generator = gameObject.GetComponent<RoomGenerator>();
        
    }

    public void SetFloor(int floor, float xOffset)
    {
        for (int x = 0; x < generator.floors[floor].GetLength(0); x++)
        {
            for (int y = 0; y < generator.floors[floor].GetLength(1); y++)
            {
                if (generator.floors[floor][x, y] == null)
                    continue;
                Room currentRoom = generator.floors[floor][x, y];

                GameObject room = Instantiate(roomInstances.Where(r => currentRoom.type == r.type && currentRoom.doorTop == r.top
                && currentRoom.doorBottom == r.bottom && currentRoom.doorLeft == r.left && currentRoom.doorRight == r.right).ToArray()[0].gameObject, new Vector2(x * 11.33f + xOffset, y * (8.98f)) - (generator.worldSize * new Vector2(11.33f, 8.98f)), Quaternion.identity, transform);
                if (room.GetComponent<RoomBehaviour>()!= null )
                {
                    room.GetComponent<RoomBehaviour>().floorIndex = floor;
                }
            }
        }
    }
}
