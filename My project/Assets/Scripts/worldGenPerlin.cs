using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Unity.Mathematics;

public class WorldGenPerlin : MonoBehaviour
{
    [SerializeField] private int width, plusX, plusY;
    [SerializeField] private bool left;
    [SerializeField] private Tilemap dirtTilemap, grassTilemap, stoneTilemap;
    [SerializeField] private TileBase dirtTile, grassTile, stoneTile;
    [Range(0,100)]
    [SerializeField] private float heightValue,smoothness;
void Start()
{
    GenerateWorld();
}

private void GenerateWorld()
{

    if (left == true)
    {
        for (int x = 0; x < width; x++)
        {
            
            int height = Mathf.RoundToInt(heightValue* Mathf.PerlinNoise(x/smoothness, 0));
            for (int y = 0; y < height; y++)
            {

                stoneTilemap.SetTile(new Vector3Int(x + plusX, y + plusY, 0), stoneTile);
            }
            grassTilemap.SetTile(new Vector3Int(x + plusX, height + plusY, 0), grassTile);
            dirtTilemap.SetTile(new Vector3Int(x + plusX, height + plusY - 1, 0), dirtTile);

        }
    }
    else if (left == true)
    {
        for (int x = 0; x > width; x--)
        {
       int height = Mathf.RoundToInt(heightValue* Mathf.PerlinNoise(x/smoothness, 0));
            for (int y = 0; y < height; y++)
            {
                stoneTilemap.SetTile(new Vector3Int(x + plusX, y + plusY, 0), stoneTile);
            }
            grassTilemap.SetTile(new Vector3Int(x + plusX, height + plusY, 0), grassTile);
            dirtTilemap.SetTile(new Vector3Int(x + plusX, height + plusY - 1, 0), dirtTile);
        }
    }
}
}
