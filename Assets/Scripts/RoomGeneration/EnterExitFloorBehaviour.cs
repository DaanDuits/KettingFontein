using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterExitFloorBehaviour : MonoBehaviour
{
    RoomGenerator generator;
    public int dir;
    public bool toBossRoom;

    private void Start()
    {
        generator = GameObject.Find("FloorGenerator").GetComponent<RoomGenerator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && generator.floorIndex + dir >= 0 && generator.floorIndex + dir <= 15)
        {
            collision.GetComponent<PlayerMovement>().camFollowPlayer = toBossRoom;
            if (dir >= 0)
            {
                Vector3 roomPos = generator.GetRoomPosition(generator.floorIndex + dir) ;
                Camera.main.transform.position = roomPos + new Vector3(0, 0, -10);
                collision.transform.position = roomPos + new Vector3(0, -2);
            }
            else if (dir < 0)
            {
                Vector3 roomPos = generator.exitPositions[generator.floorIndex + dir];
                generator.floorIndex += dir;
                Camera.main.transform.position = roomPos + new Vector3(0, 0, -10);
                collision.transform.position = roomPos + new Vector3(0, -2);
            }
            if (toBossRoom && generator.floorIndex < 15)
            {
                Debug.Log(generator.floorIndex);
                Camera.main.transform.position = new Vector3(0, -211, -10);
                collision.transform.position = new Vector3(0, -211, 0);
                toBossRoom = false;
            }
        }
    }
}
