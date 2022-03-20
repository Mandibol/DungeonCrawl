using SFML.Graphics;
using SFML.System;
public abstract class GameObject
{
    public Sprite sprite = new();
    public int gridIndex;
    public Vector2f gridPosition;
    public Vector2f pixelPosition;
    public int floorheight;
    public abstract void Update();
    public abstract void Draw();

    public GameObject(int Index)
    {
        //Get Index And Position
        gridIndex = Index;
        gridPosition = IsoMath.GridPositionFromIndex(gridIndex);
        pixelPosition = IsoMath.PixelPositionFromGridPosition(gridPosition);
    }
    public GameObject(int Index, int FloorHeight)
    {
        //Get Index And Position
        gridIndex = Index;
        floorheight = FloorHeight;
        gridPosition = IsoMath.GridPositionFromIndex(gridIndex);
        pixelPosition = IsoMath.PixelPositionFromGridPosition(gridPosition);
    }
    public GameObject()
    {

    }

}

