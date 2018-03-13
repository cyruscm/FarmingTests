using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class TileTypeRegistry {
    private static Dictionary<string, TileType> tileTypeRegister;

    public static void BuildRegistry()
    {
        tileTypeRegister = new Dictionary<string, TileType>();

        Sprite treeSprite = Resources.Load<Sprite>("Sprites/Objects/mediumtree2");
        Bounds2D clippingZone = new Bounds2D(0, 1, 3, 3);
        Bounds2D collisionZone = new Bounds2D(1, 0, 1, 1);
        Bounds2D interactionZone = new Bounds2D(1, 0, 1, 1);
        Bounds2D blockingZone = new Bounds2D(0, 0, 3, 2);
        TileType tree = new TileType(treeSprite, clippingZone, collisionZone, interactionZone, blockingZone);

        tileTypeRegister.Add("core.tree", tree);
    }

    public static TileType GetTileType(string name)
    {
        TileType value = null;
        tileTypeRegister.TryGetValue(name, out value);
        return value;
    }

    public static string[] GetNames()
    {
        return tileTypeRegister.Keys.ToArray<string>();
    }

    public static IEnumerator GetEnumerator()
    {
        return tileTypeRegister.GetEnumerator();
    }
}
