using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyDropBehaviour : MonoBehaviour
{
    public int amount;
    public string displayName;
    TMP_Text display;
    Transform player;

    private void Start()
    {
        display = GameObject.Find(displayName).GetComponent<TMP_Text>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * 4 * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            display.text = $"{int.Parse(display.text) + amount}";
            Destroy(gameObject);
        }
    }
}
