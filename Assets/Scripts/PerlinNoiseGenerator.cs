/*
 * author : Kirakosyan Nikita
 * e-mail : noomank.games@gmail.com
 */
using UnityEngine;

[ExecuteAlways]
public class PerlinNoiseGenerator : Singleton<PerlinNoiseGenerator>
{
    public Texture2D heightMap = null;
    public bool autoUpdate = false;

    public int mapWidth = 32;
    public int mapHeight = 32;

    public float noiseScale = 32.0f;

    public float offsetX = 0.0f;
    public float offsetY = 0.0f;

    private void Update()
    {
        if (autoUpdate == true) Generate();
    }

    public void Generate()
    {
        GenerateNoise(mapWidth, mapHeight, noiseScale, offsetX, offsetY);
    }

    public void GenerateNoise(int width, int height, float scale, float offsetX, float offsetY)
    {
        heightMap.Resize(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(width, height, x, y, scale, offsetX, offsetY);
                heightMap.SetPixel(x, y, color);
            }
        }

        heightMap.Apply();
    }

    private Color CalculateColor(int width, int height, int x, int y, float scale, float offsetX, float offsetY)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}