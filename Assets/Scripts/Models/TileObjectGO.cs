using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObjectGO : MonoBehaviour {

    public TileType tileType;
    private SpriteRenderer spriteRenderer;

    private bool isTransparent;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        PolygonCollider2D collider = GetComponent<PolygonCollider2D>();

        spriteRenderer.sprite = tileType.sprite;
        spriteRenderer.sortingOrder = 1000 - Mathf.RoundToInt(transform.position.y) - 1;
        collider.points = tileType.collisionZone.CalculatePoints();

        PolygonCollider2D childCollider = gameObject.transform.GetChild(0).GetComponent<PolygonCollider2D>();
        childCollider.points = tileType.clippingZone.CalculatePoints();
    }

    public void LateUpdate()
    {
        if (!isTransparent)
        {
            if (spriteRenderer.color.a != 1f)
            {
                spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            }
        } else
        {
            isTransparent = false;
        }
    }

    public void PlayerInClippingZone()
    {
        isTransparent = true;
        spriteRenderer.color = new Color(1f, 1f, 1f, .7f);
    }

}
