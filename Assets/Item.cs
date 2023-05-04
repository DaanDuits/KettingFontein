using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;

    public Item(string _name)
    {
        itemName = _name;
    }
}
