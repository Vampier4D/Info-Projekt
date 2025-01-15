

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Unity.Mathematics;

public class WorldGeneratorPerlin : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private bool generateLeft;
    [SerializeField] private int plusY;
    [SerializeField] private int plusX;
    [SerializeField] private Tilemap dirtTilemap, grassTilemap, stoneTilemap;
    [SerializeField] private TileBase dirtTile;
    [SerializeField] private TileBase grassTile;
    [SerializeField] private TileBase stoneTile;
    [Range(0, 100)]
    [SerializeField] private float heightValue, smoothness;
    void Start()
    {
        GenerateWorld();
    }

    private void GenerateWorld()
    {
        if (generateLeft == true)
        {

            for (int x = 0; x < width; x++)
            {
                generator(x);
            }
        }
        else
        {
            for (int x = 0; x > width; x--)
            {
                generator(x);
            }
        }
    }
    private void generator(int x)
    {
        float perlinValue = Mathf.PerlinNoise(x / smoothness, 0);
        int height = Mathf.RoundToInt(heightValue * perlinValue);
        for (int y = 0; y < height; y++)
        {
            stoneTilemap.SetTile(new Vector3Int(x + plusX, y + plusY, 0), stoneTile);
        }
        grassTilemap.SetTile(new Vector3Int(x + plusX, height + plusY, 0), grassTile);
        dirtTilemap.SetTile(new Vector3Int(x + plusX, height + plusY - 1, 0), dirtTile);
    }
}


