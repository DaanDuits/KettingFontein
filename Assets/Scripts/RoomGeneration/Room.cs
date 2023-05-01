using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Room
{
    public Vector2 gridPos;
    public int type;
    public bool doorTop, doorBottom, doorLeft, doorRight;

    public Room(Vector2 _gridPos, int _type)
    {
        gridPos = _gridPos;
        type = _type;
    }
}
