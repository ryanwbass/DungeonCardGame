using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Chunk {

    public int chunkSize;
    public Vector2Int bottomRightWorldPoint;
    public int[,] chunkdata;


    public bool isActive;
    public bool isDrawn;

    public Chunk(int _chunkSize, Vector2Int _bottomRightWorldPoint)
    {
        bottomRightWorldPoint = _bottomRightWorldPoint;
        chunkSize = _chunkSize;
        isActive = false;
        isDrawn = false;
    }

    public void DrawChunk()
    {
        if (!isActive)
        {
            chunkdata = new int[chunkSize, chunkSize];
            isActive = true;
            clearChunk();
        }
        
    }

    void clearChunk()
    {
        for (int x = 0; x < chunkSize; x++)
        {
            for (int y = 0; y < chunkSize; y++)
            {
                chunkdata[x, y] = 0;
            }
        }
    }

    

    void SetGirdValueTo(int blockType, Vector2Int position)
    {
        if(position.x >= 0 && position.x < chunkSize && position.y >= 0 && position.y < chunkSize - 1)
        {
            chunkdata[position.x, position.y] = blockType;
        }
    }
}
