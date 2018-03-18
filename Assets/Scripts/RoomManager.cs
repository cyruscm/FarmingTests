using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

    SpriteController spriteController;
    public GameObject tileObjectPrefab;
    public Room currentRoom;

    // Use this for initialization
	void Start () {
        TileTypeRegistry.BuildRegistry();
        spriteController = new SpriteController(tileObjectPrefab);
        Room room = new Room(40, 40);
        this.currentRoom = room;
        RenderRoom(room);
	}

    private void RenderRoom(Room room)
    {
        foreach (TileObject tileObject in room.objects)
        {
            if (tileObject != null)
            {
                spriteController.AddTileObject(tileObject);
            }
        }
    }

    private void DerenderRoom(Room room)
    {

    }
	
}
