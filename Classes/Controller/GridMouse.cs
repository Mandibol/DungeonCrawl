using SFML.Graphics;
using SFML.System;
using SFML.Window;

public class GridMouse
{
    public Sprite sprite = new();
    public static int gridIndex;
    public static Vector2f gridPosition;
    public static Vector2f pixelPosition;
    public static Vector2f gridPositionPrevious;
    public static int radie = 3;
    public static List<Vector2f> gridPositions = new List<Vector2f>();
    public static List<int> gridIndexes = new List<int>();

    public GridMouse()
    {
        sprite = new Sprite(Game.TextureAtlas, new IntRect(0, 64, 32, 16));
        sprite.Origin = new Vector2f(16, 0);
    }

    public void Update()
    {
        gridPosition = IsoMath.GridPositionFromPixelPosition(Game.Window.MapPixelToCoords(Mouse.GetPosition(Game.Window)));
        gridIndex = IsoMath.IndexFromGridPosition(gridPosition);

        if (gridPosition != gridPositionPrevious)
        {
            gridPositionPrevious = gridPosition;
            gridIndex = IsoMath.IndexFromGridPosition(gridPosition);

            gridPositions.Clear();
            gridIndexes.Clear();

            for (int y = 0; y < radie * 2 + 1; y++)
            {
                for (int x = 0; x < radie * 2 + 1; x++)
                {
                    float mx = gridPosition.X - radie + x;
                    float my = gridPosition.Y - radie + y;
                    Vector2f mv = new Vector2f(mx, my);
                    float distance = IsoMath.Pythagoras(gridPosition, mv);
                    if (mx >= 0 && mx < Game.GridSize.X && my >= 0 && my < Game.GridSize.Y && distance <= radie)
                    {
                        gridPositions.Add(mv);
                        gridIndexes.Add(IsoMath.IndexFromGridPosition(mv));
                    }

                }
            }
        }
    }

    public void Draw()
    {

        //MouseMarker
        Vector2f mp = Game.Window.MapPixelToCoords(Mouse.GetPosition(Game.Window));
        foreach (var item in gridPositions)
        {
            sprite.Position = IsoMath.PixelPositionFromGridPosition(item);
            Game.Window.Draw(sprite);
        }
    }
}