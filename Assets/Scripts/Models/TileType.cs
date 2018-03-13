using UnityEngine;

public class TileType {

    public readonly Bounds2D clippingZone;
    public readonly Bounds2D collisionZone;
    public readonly Bounds2D spriteZone;
    public readonly Bounds2D interactionZone;
    public readonly Bounds2D blockingZone;
    public readonly Sprite sprite;


    public TileType(Sprite sprite, Bounds2D clippingZone, Bounds2D collisionZone, Bounds2D interactionZone, Bounds2D blockingZone)
    {
        this.sprite = sprite;
        this.clippingZone = clippingZone;
        this.collisionZone = collisionZone;
        this.interactionZone = interactionZone;
        this.blockingZone = blockingZone;
        this.spriteZone = new Bounds2D(new Vector2(0, 0), new Vector2(sprite.bounds.max.x, sprite.bounds.max.y));
    }

}
