/*
 * author : Kirakosyan Nikita
 * e-mail : noomank.games@gmail.com
 */
using UnityEngine;

[ExecuteAlways]
public class TerrainGenerator : Singleton<TerrainGenerator>
{
    public Terrain terrain = null;
    public Texture2D heightMap = null;
    public bool autoUpdate = false;

    public int terrainHeight = 8;

    private void Update()
    {
        if (autoUpdate == true) Generate();
    }

    public void Generate()
    {
        terrain.terrainData.size = new Vector3(heightMap.width, terrainHeight, heightMap.height);

        float[,] heights = new float[heightMap.width, heightMap.height];
        for (int x = 0; x < heightMap.width; x++)
        {
            for (int y = 0; y < heightMap.height; y++)
            {
                heights[x, y] = heightMap.GetPixel(x, y).grayscale;
            }
        }

        terrain.terrainData.heightmapResolution = heightMap.width;
        terrain.terrainData.SetHeights(0, 0, heights);
    }

    public void Clear()
    {
        
    }
}
