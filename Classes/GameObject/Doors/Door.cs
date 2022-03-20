using SFML.Graphics;
using SFML.System;

abstract class Door : GameObject
{
    public Sprite sprite2 = new(); 
    public Door(int Index) : base(Index)
    {

    }

    public override void Update()
    {

    }

    public override void Draw()
    {
        Rotation rotation = Game.Controller.rotation;
        Sprite spr = new();
        if (rotation == Rotation.North || rotation == Rotation.West) { spr = sprite; }
        else if (rotation == Rotation.East || rotation == Rotation.South){ spr = sprite2; }
        spr.Position = new Vector2f(pixelPosition.X, pixelPosition.Y + 4 - floorheight);
        Game.Window.Draw(spr);
    }
}