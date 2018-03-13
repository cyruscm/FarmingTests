using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController {

    public GameObject objectParent;
    private Room room;
    private Dictionary<TileObject, GameObject> gameObjectMap;

    public SpriteController(Room room)
    {
        this.room = room;
        this.objectParent = new GameObject("TileObjects");
        this.gameObjectMap = new Dictionary<TileObject, GameObject>();
    }
}
