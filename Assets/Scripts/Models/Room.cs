using UnityEngine;
using System;
using UnityEngine.Tilemaps;

public class Room {

    private ITilemap groundTileMap;
    private ITilemap collisionTileMap;
    public TileObject[,] objects;
    public readonly int width;
    public readonly int height;

    public event Action<TileObject> OnTileObjectChanged;

    public Room(int width, int height)
    {
        this.width = width;
        this.height = height;
        this.objects= new TileObject[width, height];
        buildTempMap();
    }

    public TileObject GetTileAt(int x, int y)
    {
        return objects[x, y];
    }

    private void buildTempMap()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int y = 0; y < 2; y++) {
                TileObject to = new TileObject(2 * i, 3 + 2 * y, TileTypeRegistry.GetTileType("core.tree"));
                objects[2 * i, 3 + 2 * y] = to;
                to.Destroyed += OnTileDestroyed;
            }
        }
    }

    private void OnTileDestroyed(TileObject to)
    {
        objects[to.posX, to.posY] = null;
        to.Destroyed -= OnTileDestroyed;
    }
}
