using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public int worldWidth;
    public int worldHeight;
    public int chunkSize;
    public Chunk[,] world;
    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateWorld(int _worldWidth, int _worldHeight, int _chunkSize)
    {
        worldWidth = _worldWidth;
        worldHeight = _worldHeight;
        chunkSize = _chunkSize;
        world = new Chunk[worldWidth, worldHeight];

        for( int x = 0; x < worldWidth; x++)
        {
            for( int y = 0; y < worldHeight; y++)
            {
                world[x, y] = new Chunk(16, new Vector2Int(x,y));
            }
        }
    }

    public Chunk GetChunk(int x, int y)
    {
        Chunk chunkToReturn = world[x, y];
        if (!chunkToReturn.isActive)
        {
            chunkToReturn.DrawChunk();
        }
        return chunkToReturn;
    }
}
