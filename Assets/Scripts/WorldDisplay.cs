using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldDisplay : MonoBehaviour {

    Grid screen;
    Tilemap floorLayer;
    Tilemap wallLayer;
    Tilemap wallTopLayer;
    MapGenerator mapGen;

    private int IsometricRangePerYUnit;
    public enum TypeOfBlock { None, Floor, Wall };

    public int chunksWide;
    public int chunksHigh;
    public int chunkSize;
    Chunk[,] world;
    private int worldWidth;
    private int worldHeight;


    private void Start()
    {
        screen = transform.gameObject.GetComponent<Grid>();
        floorLayer = screen.transform.Find("Floor").GetComponent<Tilemap>();
        wallLayer = screen.transform.Find("Wall").GetComponent<Tilemap>();
        wallTopLayer = screen.transform.Find("WallTops").GetComponent<Tilemap>();
        IsometricRangePerYUnit = 16;


        PrepareWorld();
        

    }

    void PrepareWorld()
    {
        world = new Chunk[chunksWide, chunksHigh];
        for (int x = 0; x < chunksWide; x++)
        {
            for (int y = 0; y < chunksWide; y++)
            {
                Vector2Int newChunkPos = new Vector2Int(x, y);
                world[x, y] = new Chunk(chunkSize, newChunkPos);
            }
        }
    }

    Vector2Int IntsToV2(int x, int y)
    {
        return new Vector2Int(x, y);
    }

    Vector2Int WorldPosToGridCoord()
    {

    }

    void DrawElbow(TypeOfBlock blockType, Vector2Int startPoint, Vector2Int vector)
    {
        for (int x = 0; x < Mathf.Abs(vector.x); x++)
        {
            SetGirdValueTo(blockType, IntsToV2(startPoint.x + x * (int)Mathf.Sign(vector.x), startPoint.y));
        }

        for (int y = 0; y < Mathf.Abs(vector.y); y++)
        {
            SetGirdValueTo(blockType, IntsToV2(startPoint.x, startPoint.y + y * (int)Mathf.Sign(vector.y)));
        }
    }

    void DrawBasicRoom()
    {
        DrawElbow(TypeOfBlock.Wall, IntsToV2(2, 5), IntsToV2(-3, -4));
        DrawElbow(TypeOfBlock.Wall, IntsToV2(5, 2), IntsToV2(-4, -3));

        DrawElbow(TypeOfBlock.Wall, IntsToV2(2, 10), IntsToV2(-3, 4));
        DrawElbow(TypeOfBlock.Wall, IntsToV2(5, 13), IntsToV2(-4, 3));

        DrawElbow(TypeOfBlock.Wall, IntsToV2(10, 2), IntsToV2(4, -3));
        DrawElbow(TypeOfBlock.Wall, IntsToV2(13, 5), IntsToV2(3, -4));

        DrawElbow(TypeOfBlock.Wall, IntsToV2(10, 13), IntsToV2(4, 3));
        DrawElbow(TypeOfBlock.Wall, IntsToV2(13, 10), IntsToV2(3, 4));
    }

    void floodFill()
    {

    }
}
