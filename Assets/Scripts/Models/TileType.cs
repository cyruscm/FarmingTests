using System;
using UnityEngine;

public class TileType {

    public readonly Bounds2D clippingZone;
    public readonly Bounds2D collisionZone;
    public readonly Bounds2D spriteZone;
    public readonly Sprite sprite;
    public readonly Type tileEntityType;


    public TileType(Sprite sprite, Bounds2D clippingZone = null, Bounds2D collisionZone = null, Type tileEntityType = null)
    {
        this.sprite = sprite;
        this.clippingZone = clippingZone;
        this.collisionZone = collisionZone;
        this.tileEntityType = tileEntityType;
        this.spriteZone = new Bounds2D(new Vector2(0, 0), new Vector2(sprite.bounds.max.x, sprite.bounds.max.y));
    }

}
