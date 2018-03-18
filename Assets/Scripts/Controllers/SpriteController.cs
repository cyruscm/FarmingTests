using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController {

    public GameObject objectParent;
    private Dictionary<TileObject, GameObject> gameObjectMap;
    public GameObject tileObjectPrefab;

    public SpriteController(GameObject tileObjectPrefab)
    {
        this.objectParent = new GameObject("TileObjects");
        this.gameObjectMap = new Dictionary<TileObject, GameObject>();
        this.tileObjectPrefab = tileObjectPrefab;

    }

    public void AddTileObject(TileObject tileObject)
    {
        GameObject go = SimplePool.Spawn(tileObjectPrefab, new Vector3(tileObject.posX, tileObject.posY, 0), Quaternion.identity);
        go.transform.SetParent(objectParent.transform, true);
        gameObjectMap[tileObject] = go;
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
        sr.sprite = tileObject.tileType.sprite;
        sr.sortingOrder = 1000 - tileObject.posY - 1;
        go.GetComponent<PolygonCollider2D>().points = tileObject.tileType.collisionZone.CalculatePoints();



        tileObject.Destroyed += OnTileDestroyed;
    }

    private void OnTileDestroyed(TileObject to)
    {
        SimplePool.Despawn(gameObjectMap[to]);
        to.Destroyed -= OnTileDestroyed;
    }

}
