using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public int price;
    public int damage;

    public Item(string _name, int _price, int _damage)
    {
        itemName = _name;
        price = _price;
        damage = _damage;
    }
}
