using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeholder : MonoBehaviour
{
    public GameObject chest;
    public bool clearedRoom;
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
            if (!c.open)
            {
                c.chestGameObject.transform.GetChild(0).gameObject.SetActive(false);
                Debug.Log("setfalse");
            }
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
        if (Input.GetKey(KeyCode.E)) //set active gebeurt niet
        {
            chest.transform.GetChild(0).gameObject.SetActive(true);
        }
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
