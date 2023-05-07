using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Placeholder : MonoBehaviour
{
    public GameObject chest;
    public bool clearedRoom;
    public int currency = 1000;
    public TMP_Text itemNameTMP;
    public Chest c;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;
    // Update is called once per frame
    void Update()
    {
        Walk();
        if (clearedRoom)
        {
            int tier = Random.Range(0, 100);
            c = new Chest(chest, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0), tier);
            itemNameTMP = c.chestGameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>();
            itemNameTMP.text = c.chestItem.itemName;
            switch (tier)
            {
                case < 10:
                    c.chestGameObject.GetComponent<SpriteRenderer>().sprite = s1;
                    c.tier = 3;
                    break;
                case < 25: //e
                    c.chestGameObject.GetComponent<SpriteRenderer>().sprite = s2;
                    c.tier = 2;
                    break;
                case < 50: //r
                    c.chestGameObject.GetComponent<SpriteRenderer>().sprite = s3;
                    c.tier = 1;
                    break;
                case < 100: //c
                    c.chestGameObject.GetComponent<SpriteRenderer>().sprite = s4;
                    c.tier = 0;
                    break;
            }
            clearedRoom = false;
        }
        if (Vector3.Distance(transform.position, chest.transform.position) <  2f)
        {
            chest.transform.GetChild(0).gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                currency -= c.chestItem.price;
                GetComponent<PlayerAttack>().maxDamage = c.chestItem.damage;
                Destroy(GameObject.Find("Chest(Clone)"));
            }
        }            
        else if(Vector3.Distance(transform.position, chest.transform.position) >= 2f)
            chest.transform.GetChild(0).gameObject.SetActive(false);
    }
    void Walk()
    {
        int speed = 5;
        if (Input.GetKey(KeyCode.W))
            gameObject.transform.position += new Vector3(0, speed) * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            gameObject.transform.position += new Vector3(-speed, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            gameObject.transform.position += new Vector3(0, -speed) * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            gameObject.transform.position += new Vector3(speed, 0) * Time.deltaTime;
    }
}
