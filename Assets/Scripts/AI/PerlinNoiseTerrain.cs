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

                //Adding multiple layers of PerlinNoise
                float noise1 = Mathf.PerlinNoise(xpoint, zpoint);
                float noise2 = Mathf.PerlinNoise(xpoint * 1.5f, zpoint * 1.3f) * 0.5f;
                float noise3 = Mathf.PerlinNoise(xpoint * 2f, zpoint * 2f) * 0.25f;

                float finalheight = (noise1 + noise2 + noise3) / 1f;
                heights[x, z] = finalheight;
            }
        }
        return heights;
    }
}
