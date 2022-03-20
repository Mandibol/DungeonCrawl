using SFML.Graphics;
using SFML.Window;

public class Input
{
    private RenderWindow window = Game.Window;
    
    public Input()
    {
        //Subscribe Methods to input events
        window.MouseWheelScrolled += Window_MouseWheelScrolled;
        window.KeyPressed += Window_KeyPressed;
    }
    private void Window_KeyPressed(object? sender, KeyEventArgs e)
    {
        switch (e.Code)
        {
            case Keyboard.Key.Add:
                break;
            case Keyboard.Key.Subtract:
                break;
            case Keyboard.Key.Left:
                //Change direction and Rotate Arrays 90 degrees to the left
                Game.Controller.rotation -= 1;
                if (Game.Controller.rotation < 0) Game.Controller.rotation += (int)Rotation.Length;
                Game.Controller.rotation = (Rotation)((int)(Game.Controller.rotation) % (int)Rotation.Length);
                Game.Controller.staticArray = IsoMath.RotateRightLevelLeft(Game.Controller.staticArray);
                Game.Controller.objectArray = IsoMath.RotateRightLevelLeft(Game.Controller.objectArray);
                break;
            case Keyboard.Key.Right:
                //Change direction and Rotate Arrays 90 degrees to the right
                Game.Controller.rotation = (Rotation)((int)(Game.Controller.rotation + 1) % (int)Rotation.Length);
                Game.Controller.staticArray = IsoMath.RotateRightLevelRight(Game.Controller.staticArray);
                Game.Controller.objectArray = IsoMath.RotateRightLevelRight(Game.Controller.objectArray);
                break;
            case Keyboard.Key.Up:
                break;
            case Keyboard.Key.Down:
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Use the MouseScrollWheel to adjust the Height of the Walls
    /// </summary>
    private void Window_MouseWheelScrolled(object? sender, MouseWheelScrollEventArgs e)
    {
        if (e.Delta > 0) { Wall.height++; }
        if (e.Delta < 0) { Wall.height--; }
        Wall.height = Math.Clamp(Wall.height, 1, 4);
    }
}