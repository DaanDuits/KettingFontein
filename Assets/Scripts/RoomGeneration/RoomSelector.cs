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

    public void SetRooms()
    {
        for (int x = 0; x < generator.rooms.GetLength(0); x++)
        {
            for (int y = 0; y < generator.rooms.GetLength(1); y++)
            {
                if (generator.rooms[x, y] == null)
                    continue;
                Room currentRoom = generator.rooms[x, y];

                Instantiate(roomInstances.Where(r => currentRoom.type == r.type && currentRoom.doorTop == r.top
                && currentRoom.doorBottom == r.bottom && currentRoom.doorLeft == r.left && currentRoom.doorRight == r.right).ToArray()[0].gameObject, new Vector2(x * 11.33f, y * (8.98f)) - (generator.worldSize * new Vector2(11.33f, 8.98f)), Quaternion.identity, transform);
            }
        }
    }
}
