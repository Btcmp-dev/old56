using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ForestGenerator : MonoBehaviour
{
    public GameObject treePrefab;
    public GameObject stumpPrefab;
    private Tilemap tilemap;
    //private Vector3Int tilePosition;

    public void Generate(float randomValue, float neededValue, Tilemap tilemap, Vector3Int tilePosition1)
    {
        if (randomValue < neededValue)
        {
            this.tilemap = tilemap;
            //tilePosition = tilemap.WorldToCell(transform.position); // неверно!!!!!
            //tilePosition = tilePosition1;
            SpawnObjectAtTile(tilePosition1);
        }
    }
    void SpawnObjectAtTile(Vector3Int tilePosition)
    {
        // Преобразуем координаты тайла в мировые координаты
        Vector3 worldPosition = tilemap.CellToWorld(tilePosition);

        // Опционально, можно подкорректировать позицию (например, поднять объект на уровень выше)
        //worldPosition += (tilemap.cellBounds.size / 2f);  // Это сместит объект в центр клетки тайла

        // Инстанциируем объект на этой позиции
        Instantiate(treePrefab, worldPosition, Quaternion.identity);
    }
}
