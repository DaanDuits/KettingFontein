using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int minDamage, maxDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyBehaviour>().TakeDamage(new System.Random().Next(minDamage, maxDamage + 1));
        }
    }

    public void RemoveObject()
    {
        Destroy(gameObject);
    }
}
