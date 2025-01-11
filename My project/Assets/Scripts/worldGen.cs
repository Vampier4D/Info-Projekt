using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    [SerializeField] private int width, height, diffrenceUp, diffrenceDown, plusX, plusY, plusMinus;
    [SerializeField] private GameObject grass, dirt;
    // Start is called before the first frame update
    void Start()
    {
       GenerateWorld(); 
    }

    // Update is called once per frame
    void GenerateWorld()
    {

       if (plusMinus == 1) {
         for (int x = 0; x < width; x ++)
         {
             int minHeight = height - diffrenceDown; 
             int maxHeight = height + diffrenceUp;
             height = Random.Range(minHeight, maxHeight);  
             for (int y = 0; y < height; y++)
             {
                 spawnObject(dirt, x + plusX, y + plusY);
             }
             spawnObject(grass, x + plusX, height + plusY);
         
        }
       }else if (plusMinus == -1) {
         for (int x = 0; x > width; x --)
         {
             int minHeight = height - diffrenceDown; 
             int maxHeight = height + diffrenceUp;
             height = Random.Range(minHeight, maxHeight);  
             for (int y = 0; y < height; y++)
             {
                 spawnObject(dirt, x + plusX, y + plusY);
             }
             spawnObject(grass, x + plusX, height + plusY);
         
        }
    }
    }
    private void spawnObject(GameObject obj, int width, int height)
    {
        obj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
        obj.transform.parent = this.transform;
    }
}