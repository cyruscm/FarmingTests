using UnityEngine;
using System;
using UnityEngine.Tilemaps;

public class Room {

    private ITilemap groundTileMap;
    private ITilemap collisionTileMap;
    private TileObject[,] objects;

    public event Action<TileObject> OnTileObjectChanged;

    public Room(int width, int height)
    {
        this.objects= new TileObject[width, height];
        buildTempMap();
    }

    private void buildTempMap()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int y = 0; y < 2; y++) {
                objects[2 * i, 3 + 2 * y] = new TileObject(new Vector2(2 * i, 3 + 2 * y), TileTypeRegistry.GetTileType("core.tree"));
            }
        }
    }

    private void OnTileObjectChangedCallback(TileObject t)
    {
        if (OnTileChangedCallback == null)
        {
            return;
        }

        OnTileChanged(t)
    }


}
