using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Aboba", menuName = "Tiles/Aboba")]
public class GigaTile : Tile
{
    public string surfaceType;

    public string pathToSound;

    public float speedLimit;
}
