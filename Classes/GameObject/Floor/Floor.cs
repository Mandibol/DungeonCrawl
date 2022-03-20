using SFML.System;

public abstract class Floor : GameObject
{

    public Floor(int Index) : base(Index)
    {
        Random rn = new Random();
        floorheight = (rn.Next(5) + rn.Next(5)) / 2;
    }

    public override void Update()
    {

    }

    public override void Draw()
    {
        sprite.Position = new Vector2f(pixelPosition.X, pixelPosition.Y + 4 - floorheight);
        Game.Window.Draw(sprite);
    }
}

