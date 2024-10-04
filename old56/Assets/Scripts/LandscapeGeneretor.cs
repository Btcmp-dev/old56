using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LandscapeGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public ForestGenerator forestGenerator;
    // ������ ����� ��� �����
    public TileBase lightGroundTile;  
    public TileBase mediumGroundTile; 
    public TileBase darkGroundTile;   

    public int mapWidth = 1000;
    public int mapHeight = 1000;

    public float perlinScaleX = 30f;
    public float perlinScaleY = 30f;

    public float genEdge1 = 0.4f;
    public float genEdge2 = 0.52f;

    void Start()
    {
        GenerateLandscape();
    }

    void GenerateLandscape()
    {
        int seed = Random.Range(1, 999) ; //�������� ������� �������
        //print(seed);

        int seedSecondary = seed * 400;


        for (int x = 0; x < mapWidth; x++) //seed ����� - ����� �������. ������ PerlinNoise ������ ���� ���� ����������� ��������
        {
            for (int y = 0; y < mapHeight; y++)
            {
                float randomSeed = Random.Range(0.00f, 1.00f);
                //float randomValue = Random.value;
                float randomValue = Mathf.PerlinNoise((x + seed) / perlinScaleX, (y + seed) / perlinScaleY);
                float randomValueSecondary = Mathf.PerlinNoise((x + seedSecondary) / perlinScaleX, (y + seedSecondary) / perlinScaleY);

                if (randomValue > genEdge1 && randomValue < genEdge2)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), mediumGroundTile); // ��������
                }

                else // ��� �������� ������ ������� �������
                {
                    if (randomValueSecondary < 0.6f)
                    {
                        tilemap.SetTile(new Vector3Int(x, y, 0), lightGroundTile);  // ������ ������
                        forestGenerator.Generate(randomSeed, 0.04f, tilemap, new Vector3Int(x, y, 0)); // ����� �������, �� ��������, ������ �������� - ������� ��������
                    }
                    else
                        tilemap.SetTile(new Vector3Int(x, y, 0), darkGroundTile);
                }
            }
        }
    }
}

