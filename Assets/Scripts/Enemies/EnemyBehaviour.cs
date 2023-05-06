using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    Transform player;
    public Animator animator;
    Vector3 offset;
    public RoomBehaviour room;
    public Slider healthBar;

    public EnemyFloorValue[] enemyFloorValues;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        offset = Random.Range(0, 2) == 1 ? new Vector3(-0.8f, 0, 0) : new Vector3(0.8f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (player.transform.position + offset - transform.position).normalized;
        transform.position += dir * 2 * Time.deltaTime;
        dir = (player.transform.position - transform.position).normalized;
        transform.localScale = dir.x < 0 ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
        transform.GetChild(1).transform.localScale = new Vector3(dir.x < 0 ? -0.01560062f : 0.01560062f, 0.01560062f, 0.01560062f);

        float x = Mathf.Clamp(transform.position.x, room.transform.position.x - 4.65f, room.transform.position.x + 4.65f);
        float y = Mathf.Clamp(transform.position.y, room.transform.position.y- 3.65f, room.transform.position.y + 3.15f);
        transform.position = new Vector3(x, y);

        if (dir != Vector3.zero)
        {
            animator.SetBool("isWalking", true);
            animator.speed = 2 / 3f;
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.speed = 1;
        }
    }

    public void TakeDamage(int damage)
    {
        healthBar.value -= damage;
        if (healthBar.value == 0)
        {
            room.enemiesInRoom--;
            for (int i = 0; i <enemyFloorValues[room.floorIndex].drops.Length; i++)
            {
                Instantiate(enemyFloorValues[room.floorIndex].drops[i].@object, transform.position, Quaternion.identity).GetComponent<EnemyDropBehaviour>().amount =
                    new System.Random().Next(enemyFloorValues[room.floorIndex].drops[i].dropsMinAmount, enemyFloorValues[room.floorIndex].drops[i].dropsMaxAmount);
            }
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    public struct EnemyFloorValue
    {
        public int hp;
        public int damage;
        public Drop[] drops;
    }
    [System.Serializable]
    public struct Drop
    {

        public GameObject @object;
        public int dropsMinAmount;
        public int dropsMaxAmount;
    }
}
