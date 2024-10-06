using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour, IBullet
{
    public float bulletSpeed = 5f;
    public Vector2 direction;
    public float damage = 10f;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3) // 3 - Player
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Shooting();

    }

    public void Shooting()
    {
        transform.Translate(direction * bulletSpeed * Time.deltaTime);

        Destroy(gameObject, 4f);
    }
}
