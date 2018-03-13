using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject {

    public TileType tileType;
    public Vector2 position;

    public TileObject(Vector2 position, TileType tileType)
    {
        this.position = position;
        this.tileType = tileType;
    }

}
