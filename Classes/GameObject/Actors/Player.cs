using SFML.Graphics;
using SFML.System;
using SFML.Window;

public class Player : GameObject
{
    public Player(int i, int FloorHeight) : base(i, FloorHeight)
    {
        sprite = new Sprite(Game.TextureAtlas, new IntRect(64, 176, 32, 48));
        sprite.Origin = new Vector2f(16, 32);
        floorheight = FloorHeight;
        Game.Window.KeyPressed += Window_KeyPressed; ;
        gridPosition = IsoMath.GridPositionFromIndex(gridIndex);
    }

    private void Window_KeyPressed(object? sender, SFML.Window.KeyEventArgs e)
    {
        switch (e.Code)
        {
            case Keyboard.Key.Left:
                Move(-1, 0);
                break;
            case Keyboard.Key.Right:
                Move(1, 0);
                break;
            case Keyboard.Key.Up:
                Move(0, -1);
                break;
            case Keyboard.Key.Down:
                Move(0, 1);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Check if target grid is empty and moves player there
    /// </summary>
    /// <param name="x"> number of gridposition to move relative to player in X</param>
    /// <param name="y"> number of gridposition to move relative to player in Y</param>
    public void Move(int x, int y)
    {
        int xx = (int)Math.Clamp(gridPosition.X + x, 0, Game.GridSize.X - 1);
        int yy = (int)Math.Clamp(gridPosition.Y + y, 0, Game.GridSize.Y - 1);
        Vector2f targetGridPosition = new Vector2f(xx, yy);
        int targetIndex = IsoMath.IndexFromGridPosition(targetGridPosition);
        //Get Arrays
        GameObject[] objectArray = Game.Controller.objectArray;
        //Check for collision
        if (objectArray[targetIndex] == null || objectArray[targetIndex] is Door)
        {
            //Remove player old positions from arrays 
            objectArray[gridIndex] = null;
            //Update Arrays with player new position
            objectArray[targetIndex] = this;
            //Update Player position
            gridIndex = targetIndex;
            gridPosition = targetGridPosition;
            pixelPosition = IsoMath.PixelPositionFromGridPosition(gridPosition);
            floorheight = Game.Controller.staticArray[gridIndex].floorheight;
        }
    }

    public override void Draw()
    {
        sprite.Position = new Vector2f(pixelPosition.X, pixelPosition.Y + 4 - floorheight);
        Game.Window.Draw(sprite);
    }

    public override void Update()
    {
        Wall.playerPosition = gridPosition;
    }
}

