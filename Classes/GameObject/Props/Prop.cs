using SFML.System;

abstract class Prop : GameObject
{
    public Prop(int Index, int FloorHeight) : base(Index, FloorHeight)
    {

    }

    public override void Update()
    {

    }

    /// <summary>
    /// Brap
    /// </summary>
    public override void Draw()
    {
        sprite.Position = pixelPosition;
        sprite.Position = new Vector2f(pixelPosition.X, pixelPosition.Y + 4 - floorheight);
        Game.Window.Draw(sprite);
    }
}