using UnityEngine;

public class Bounds2D {

    public Vector2 origin;
    public Vector2 size;

    public Bounds2D(Vector2 origin, Vector2 size)
    {
        this.origin = origin;
        this.size = size;
    }

    public Bounds2D(int originX, int originY, int sizeX, int sizeY)
    {
        origin = new Vector2(originX, originY);
        size = new Vector2(sizeX, sizeY);
    }

    public bool ContainsPoint(Vector2 point)
    {
        float x = (point.x - origin.x);
        float y = (point.y - origin.y);
        Debug.Log(x + ", " + y);
        bool test =(x >= 0 && x <= size.x) && (y >= 0 && y <= size.y);
        Debug.Log(test);
        return test;
    }


    public Vector2 GetCenter()
    {
        return new Vector2(size.x / 2 + origin.x, size.y / 2 + origin.y);
    }

    public Vector2[] CalculatePoints()
    {
        Vector2[] points =
        {
            new Vector2(origin.x, origin.y),
            new Vector2(origin.x + size.x, origin.y),
            new Vector2(origin.x + size.x, origin.y + size.y),
            new Vector2(origin.x, origin.y + size.y)
        };
        return points;
    }
}
