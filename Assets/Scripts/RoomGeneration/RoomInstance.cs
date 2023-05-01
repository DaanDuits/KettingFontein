using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInstance : MonoBehaviour
{
    public int type;
    public bool top, bottom, left, right;
    public SpriteRenderer floor, walls;
    private void Awake()
    {
        floor = transform.GetChild(0).GetComponent<SpriteRenderer>();
        floor.enabled = false;
        walls = transform.GetChild(1).GetComponent<SpriteRenderer>();
        walls.enabled = false;
    }
}
