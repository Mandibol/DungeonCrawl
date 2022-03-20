using SFML.Graphics;
using SFML.System;
using SFML.Window;

public class Renderer
{
    private RenderWindow window;
    private View view;
    private Font fnt = new Font("Art/dogica.ttf");

    public Renderer()
    {
        window = Game.Window;
        view = Game.WinView;
    }

    /// <summary>
    /// Method to responsible for rendering graphics
    /// </summary>
    public void Render()
    {
        if (!window.IsOpen)
        {
            return;
        }
        window.Clear();
        window.DispatchEvents();

        //TODO Draw art to image one display 

        //Render All objects in Statics and Object list
        var statics = Game.Controller.staticArray;
        var objects = Game.Controller.objectArray;
        for (int i = 0; i < statics.Length; i++)
        {
            if (statics[i] != null) { statics[i].Draw(); }
            if (objects[i] != null) { objects[i].Draw(); }
        }


        //MouseMarker
        Game.Controller.gridMouse.Draw();


        //Text
        Text text = new Text("", fnt, 8);
        text.FillColor = Color.White;
        text.DisplayedString = Game.Controller.rotation.ToString();
        text.Position = new Vector2f(0f,0f);
        window.Draw(text);

        //Display All
        window.Display();
    }
}

