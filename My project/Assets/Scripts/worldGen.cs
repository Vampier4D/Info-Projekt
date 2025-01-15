


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    [SerializeField] private int width, height, differenceUp, differenceDown, plusX, plusY;
    [SerializeField] private bool generateLeft;
    [SerializeField] private GameObject grass, dirt, stone;
    
    void Start()
    {
        GenerateWorld();
    }


    void GenerateWorld()
    {

        if (generateLeft == false)
        {
            for (int x = 0; x < width; x++)
            {
                generate(x);

            }
        }
        else
        {
            for (int x = 0; x > width; x--)
            {
                generate(x);

            }
        }
    }
    private void spawnObject(GameObject obj, int x, int y)
    {
        obj = Instantiate(obj, new Vector2(x, y), Quaternion.identity);
        obj.transform.parent = this.transform;
    }
    private void generate(int x)
    {
        int minHeight = height - differenceDown;
        int maxHeight = height + differenceUp;
        height = Random.Range(minHeight, maxHeight);
        for (int y = 0; y < height; y++)
        {
            spawnObject(stone, x + plusX, y - 1 + plusY);
        }
        spawnObject(grass, x + plusX, height + plusY);
        spawnObject(dirt, x + plusX, height + plusY - 1);
    }
}