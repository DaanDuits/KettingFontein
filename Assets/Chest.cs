using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject chestInstantiated;
    public Item chestItem;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public List<Item> chestItems = new List<Item>() {
        new Item("Scythe"), new Item("Sword"), new Item("Axe"), 
        new Item("Holy Gun"), new Item("Long Ranged Gun"), 
        new Item("Short Ranged Gun"), new Item("Normal Ranged Gun"),
        new Item("Holy Bullets"), new Item("Bullets") };
    public int tier;
    public Chest(GameObject prefab, Vector3 position, int _tier)
    {
        chestItem = chestItems[Random.Range(0, chestItems.Count)];
        Debug.Log(chestItem.itemName);
        tier = _tier;
        chestInstantiated = Object.Instantiate(prefab, position, Quaternion.identity);
        //sprite ontzichtbaar
        switch (tier)
        {
            case 0:
                chestInstantiated.GetComponent<SpriteRenderer>().sprite = s1;
                break;
            case 1:
                chestInstantiated.GetComponent<SpriteRenderer>().sprite = s2;
                break;
            case 2:
                chestInstantiated.GetComponent<SpriteRenderer>().sprite = s3;
                break;
        }
    }
}
