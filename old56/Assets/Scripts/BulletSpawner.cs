using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject player; // ����� - ����
    public GameObject bulletPrefab; // ������ ����
    public float shootInterval = 1f; // �������� ��������
    public int bulletsPerWave = 10; // ���������� ���� �� ���� �������
    public float bulletSpeed = 5f; // �������� ����
    public float shootingDistance = 15f; // ��������� ��������

    public bool canShoot = true;
    private float distance;
    private bool isPursuing;

    private void Start()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        isPursuing =bulletPrefab.GetComponent<PursuingEnemyBullet>() != null;
        print(isPursuing);
    }

    private void Update()
    {
        if (canShoot && distance < shootingDistance)
        {
            StartCoroutine(Shoot(isPursuing));
        }
        distance = Vector3.Distance(player.transform.position, transform.position);
    }
    IEnumerator Shoot(bool isPursing)
    {
        Debug.Log("Shooting...");
        canShoot = false;
        float angleStep = 360f / bulletsPerWave; // ��� ����� ������ � ��������
        float angle = 0f;

        for (int i = 0; i < bulletsPerWave; i++)
        {
            Vector2 bulletDir = (player.transform.position - transform.position).normalized;
            //Vector3 bulletDirQ = new Vector3(bulletDir.x, bulletDir.y, 0);

            // ������ ���� � ����� �� �����������
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle));

            if (isPursing)
            {
                bullet.GetComponent<PursuingEnemyBullet>().player = player;
                bullet.GetComponent<PursuingEnemyBullet>().bulletSpeed = bulletSpeed;
            }
            else
            {
                bullet.GetComponent<EnemyBullet>().direction = bulletDir;
                bullet.GetComponent<EnemyBullet>().bulletSpeed = bulletSpeed;
            }

            // ����������� ���� ��� ��������� ����
            angle += angleStep;
        }

        yield return new WaitForSeconds(shootInterval);

        canShoot = true;
    }
}
