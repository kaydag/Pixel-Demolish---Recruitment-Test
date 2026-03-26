using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelSpawner : MonoBehaviour
{
    public Texture2D texture;
    public GameObject pixelPrefab;
    public PixelGroup pixelGroup;

    private Pixel[,] grid;
    public float pixelSize = 0.1f;

    void Start()
    {
        int width = texture.width;
        int height = texture.height;
        grid = new Pixel[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = texture.GetPixel(x, y);
                if (color.a < 0.1f) continue;

                Vector2 pos = new Vector2(x * pixelSize, y * pixelSize);

                GameObject obj = Instantiate(pixelPrefab, pos, Quaternion.identity, pixelGroup.transform);

                Pixel pixel = obj.GetComponent<Pixel>();
                pixel.Init(color);

                pixelGroup.RegisterPixel(pixel);
                grid[x, y] = pixel;
            }
        }
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Pixel p = grid[x, y];
                if (p == null) continue;

                if (x > 0) p.SetNeighbor(0, grid[x - 1, y]);
                if (x < width - 1) p.SetNeighbor(1, grid[x + 1, y]);
                if (y > 0) p.SetNeighbor(2, grid[x, y - 1]);
                if (y < height - 1) p.SetNeighbor(3, grid[x, y + 1]);
            }
        }
        pixelGroup.FitColliderToPixels();
    }
}
