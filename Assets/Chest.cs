using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject chestGameObject;
    public Item chestItem;
    public List<Item> chestItems = new List<Item>() {
        new Item("Scythe"), new Item("Sword"), new Item("Axe"), 
        new Item("Holy Gun"), new Item("Long Ranged Gun"), 
        new Item("Short Ranged Gun"), new Item("Normal Ranged Gun"),
        new Item("Holy Bullets"), new Item("Bullets") };
    public int tier;
    public bool open = false;
    public Chest(GameObject prefab, Vector3 position, int _tier)
    {
        chestItem = chestItems[Random.Range(0, chestItems.Count)];
        Debug.Log(chestItem.itemName);
        tier = _tier;
        chestGameObject = Object.Instantiate(prefab, position, Quaternion.identity);
    }
}
