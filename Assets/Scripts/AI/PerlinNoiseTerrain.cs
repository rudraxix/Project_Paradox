using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoiseTerrain : MonoBehaviour
{
    public int width = 256; //terrain width
    public int height = 50; //terrain height
    public int depth = 256; //terrain depth
    public float scale = 20f;  //PerlinNoise density-detail controller

    void Start()
    {
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        Terrain terr = GetComponent<Terrain>();
        terr.terrainData = GenerateTerrainData(terr.terrainData);
    }

    TerrainData GenerateTerrainData(TerrainData terrData)
    {
        terrData.heightmapResolution = width + 1;
        terrData.size = new Vector3(width, height, depth);
        terrData.SetHeights(0, 0, GenerateHeights());
        return terrData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, depth];

        for (int x = 0; x < width; x++) 
        {
            for (int z = 0; z < depth; z++) 
            {
                float xpoint = (float)x / width * scale; 
                float zpoint = (float)z / depth * scale;
                heights[x, z] = Mathf.PerlinNoise(xpoint, zpoint);
            }
        }
        return heights;
    }
}
