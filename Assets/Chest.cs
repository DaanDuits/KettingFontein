using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject chestInstantiated;
    public Item chestItem;
    public List<Item> chestItems = new List<Item>() { new Item(), new Item(), new Item(), new Item(), new Item() };
    public int tier;
    public Chest(GameObject prefab, Vector3 position, Item _chestItem, int _tier)
    {
        _chestItem = chestItems[Random.Range(0, chestItems.Count)];
        chestItem = _chestItem;
        tier = _tier;
        chestInstantiated = Object.Instantiate(prefab, position, Quaternion.identity);
    }
}
