using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject chestGameObject;
    public Item chestItem;
    public List<Item> chestItems = new List<Item>() {
        new Item("Scythe", 100, 10), new Item("Sword", 100, 11), new Item("Axe", 100, 12), 
        new Item("Holy Gun",100, 13), new Item("Long Ranged Gun",100, 14), 
        new Item("Short Ranged Gun",100, 15), new Item("Normal Ranged Gun",100, 16),
        new Item("Holy Bullets",100, 17), new Item("Bullets",100, 18) };
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
