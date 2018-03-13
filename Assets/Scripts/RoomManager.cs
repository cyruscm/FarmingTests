using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

    public GameObject TileObjectPrefab;

    // Use this for initialization
	void Start () {
        TileTypeRegistry.BuildRegistry();

        GameObject go;

        for (int i = 0; i < 20; i++)
        {
            for (int y = 0; y < 2; y++) {
                go = SimplePool.Spawn(TileObjectPrefab, new Vector3(2*i, 3+2*y, 0), Quaternion.identity);
                go.GetComponent<TileObject>().tileType = TileTypeRegistry.GetTileType("core.tree");
            }
        }
	}
	
}
