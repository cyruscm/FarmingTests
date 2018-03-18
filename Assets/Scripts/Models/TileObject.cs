using System;
using UnityEngine;

public class TileObject {

    public TileType tileType;
    public int posX;
    public int posY;
    public TileEntity tileEntity;

    public event Action<TileObject> Destroyed;

    public TileObject(int posX, int posY, TileType tileType)
    {
        this.posX = posX;
        this.posY = posY;
        this.tileType = tileType;
        if (this.tileType.tileEntityType != null )
        {
            object tileEntity = Activator.CreateInstance(this.tileType.tileEntityType);
            if (tileEntity is TileEntity)
            {
                this.tileEntity = (TileEntity) tileEntity;
                this.tileEntity.tileObject = this;
            } else
            {
                Debug.LogError("TileEntity " + this.tileType.tileEntityType + " is not a TileEntity");
            }
        }
    }

    public void Destroy()
    {
        if (Destroyed == null)
        {
            Debug.LogError("TileObject is being destroyed but no listeners for this event?");
            return;
        }
        Destroyed(this);
        this.tileEntity = null;
        this.tileType = null;
        Debug.Log("Destroyed!");
    }

}
