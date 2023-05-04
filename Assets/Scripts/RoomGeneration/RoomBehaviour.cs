using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    public GameObject freeChest, commonChest, rareChest, epicChest, legendaryChest, workbench;
    public GameObject[] gates;
    public GameObject[] enemies;
    public bool spawnEnemies;
    public static float spawnRate = 1.5f;
    public static int maxEnemies = 20, minEnemies = 4;
    public int enemiesInRoom;
    int spawnedEnemies, maxEnemiesInRoom;
    bool canSpawn;
    float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        bool hasChest = Random.Range(0, 101) <= 30;
        bool hasWorkbench = Random.Range(0, 101) <= 10;
        spawnEnemies = Random.Range(0, 101) <= 15 || hasChest;
        if (hasChest)
        {
            int value = Random.Range(0, 101);
            if (value <= 15)
                Instantiate(freeChest, transform.position - new Vector3(0, 0.5f), Quaternion.identity, transform);
            else if (value > 15 && value <= 25)
                Instantiate(legendaryChest, transform.position - new Vector3(0, 0.5f), Quaternion.identity, transform);
            else if (value > 25 && value <= 60)
                Instantiate(commonChest, transform.position - new Vector3(0, 0.5f), Quaternion.identity, transform);
            else if (value > 60 && value <= 75)
                Instantiate(epicChest, transform.position - new Vector3(0, 0.5f), Quaternion.identity, transform);
            else if (value > 75 && value <= 100)
                Instantiate(rareChest, transform.position - new Vector3(0, 0.5f), Quaternion.identity, transform);
        }
        else if (hasWorkbench)
            Instantiate(workbench, transform.position - new Vector3(0, 0.5f), Quaternion.identity, transform);
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate && canSpawn && spawnedEnemies < maxEnemiesInRoom)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], RandomPositionInRoom(), Quaternion.identity).GetComponent<EnemyBehaviour>().room = this;
            spawnedEnemies++;
            enemiesInRoom++;
            spawnTimer = 0;
        }
        if (enemiesInRoom == 0 && spawnedEnemies == maxEnemiesInRoom && canSpawn)
        {
            OpenGates();
        }
    }
    Vector3 RandomPositionInRoom()
    {
        float x = Random.Range(0, 2) == 1 ? Random.Range(-5f, -1f) : Random.Range(5f, 1f);
        float y = Random.Range(0, 2) == 1 ? Random.Range(-3f, -1f) : Random.Range(3f, 1f);
        return new Vector3(x, y) + transform.position;
    }


    public void CloseGates()
    {
        foreach(GameObject gate in gates)
        {
            gate.SetActive(true);
        }
        maxEnemiesInRoom = Random.Range(minEnemies, maxEnemies + 1);
        canSpawn = true;
    }
    public void OpenGates()
    {
        foreach (GameObject gate in gates)
        {
            gate.SetActive(false);
        }
        spawnEnemies = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && spawnEnemies)
        {
            CloseGates();
        }
    }
}
