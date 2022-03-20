
using SFML.System;

public static class IsoMath
{
    /// <summary>
    /// Calculate Index position from Grid Position.
    /// </summary>
    /// <param name="positionOnGrid"> The position on the grid</param>
    /// <returns> Index position to use with level array</returns>
    public static int IndexFromGridPosition(Vector2f positionOnGrid)
    {
        int x = (int)positionOnGrid.X;
        int y = (int)positionOnGrid.Y;
        return y * Game.GridSize.X + x;
    }
    /// <summary>
    /// Convert List index To Grid Position
    /// </summary>
    /// <param name="index"> Index from Level layer list</param>
    /// <returns> A Vector2f with the grid position</returns>
    public static Vector2f GridPositionFromIndex(int index)
    {
        int gridCoordY = index / Game.GridSize.X;
        int gridCoordX = index - gridCoordY * Game.GridSize.X;
        return new Vector2f(gridCoordX, gridCoordY);
    }
    /// <summary>
    /// Converts Grid Position to Pixel Position 
    /// </summary>
    /// <param name="position"> Input position as a Vector2f</param>
    /// <returns> A Vector2f with the grid position</returns>
    public static Vector2f PixelPositionFromGridPosition(Vector2f position)
    {
        int gridX = (int)position.X;
        int gridY = (int)position.Y;
        int x = (gridX * Game.GridCellWidth / 2 + Game.GridOffset.X) - (gridY * Game.GridCellWidth / 2);
        int y = (gridY * Game.GridCellHeight / 2) + (gridX * Game.GridCellHeight / 2) + Game.GridOffset.Y;
        return new Vector2f(x, y);
    }

    /// <summary>
    /// Converts Pixel Position to matching GridPosition
    /// </summary>
    /// <param name="position"> Input position as a Vector2f</param>
    /// <returns>The Correct position in thw world</returns>
    public static Vector2f GridPositionFromPixelPosition(Vector2f position)
    {
        float screenX = position.X - Game.GridOffset.X;
        float screenY = position.Y - Game.GridOffset.Y;
        //Calulate Grid Position
        int x = (int)Math.Floor((screenX / Game.GridCellWidth + screenY / Game.GridCellHeight));
        int y = (int)Math.Floor((screenY / Game.GridCellHeight - screenX / Game.GridCellWidth));
        return new Vector2f(x, y);
    }


    public static GameObject[] RotateRightLevelRight(GameObject[] InputArray)
    {
        GameObject[] outputArray = new GameObject[InputArray.Length];
        int count = 0;
        for (int x = 0; x < Game.GridSize.X; x++)
        {
            for (int y = Game.GridSize.Y - 1; y >= 0; y--)
            {
                int i = IsoMath.IndexFromGridPosition(new Vector2f(x, y));
                outputArray[count] = InputArray[i];
                if (outputArray[count] != null)
                {
                    outputArray[count].gridIndex = count;
                    outputArray[count].gridPosition = IsoMath.GridPositionFromIndex(count);
                    outputArray[count].pixelPosition = IsoMath.PixelPositionFromGridPosition(outputArray[count].gridPosition);
                }
                count++;
            }
        }
        return outputArray;
    }

    public static GameObject[] RotateRightLevelLeft(GameObject[] InputArray)
    {
        GameObject[] outputArray = new GameObject[InputArray.Length];
        int count = 0;
        for (int x = Game.GridSize.X - 1; x >= 0; x--)
        {
            for (int y = 0; y < Game.GridSize.Y; y++)
            {
                int i = IsoMath.IndexFromGridPosition(new Vector2f(x, y));
                outputArray[count] = InputArray[i];
                if (outputArray[count] != null)
                {
                    outputArray[count].gridIndex = count;
                    outputArray[count].gridPosition = IsoMath.GridPositionFromIndex(count);
                    outputArray[count].pixelPosition = IsoMath.PixelPositionFromGridPosition(outputArray[count].gridPosition);
                }
                count++;
            }
        }
        return outputArray;
    }

    /// <summary>
    /// Calculate the distance between to positions
    /// </summary>
    /// <param name="a"> first vector</param>
    /// <param name="b"> second vector</param>
    /// <returns> Distance the distance as an int</returns>
    public static float Pythagoras(Vector2f a, Vector2f b)
    {
        Vector2f c = a - b;
        return (float)Math.Round(Math.Sqrt(c.X * c.X + c.Y * c.Y));
    }
}

