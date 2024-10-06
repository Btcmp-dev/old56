using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuingEnemyBullet : MonoBehaviour, IBullet
{ 
    public GameObject player;
    public float bulletSpeed = 5f;
    public Vector2 direction;
    public float damage = 10f;
    public float timeOfPursuing = 5f;

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
        direction = (player.transform.position - transform.position).normalized; // Направление к игроку

        transform.Translate(direction * bulletSpeed * Time.deltaTime); // Перемещаем пулю в направлении игрока

        Destroy(gameObject, timeOfPursuing); // Уничтожаем пулю через время
    }
}
