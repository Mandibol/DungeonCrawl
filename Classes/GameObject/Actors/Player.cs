using SFML.Graphics;
using SFML.System;

internal class Player : GameObject
{
    public Player(int i, int FloorHeight) : base(i, FloorHeight)
    {
        sprite = new Sprite(Game.TextureAtlas, new IntRect(64, 176, 32, 48));
        sprite.Origin = new Vector2f(16, 32);
        floorheight = FloorHeight;
    }
    public override void Draw()
    {
        sprite.Position = new Vector2f(pixelPosition.X, pixelPosition.Y + 4 - floorheight);
        Game.Window.Draw(sprite);
    }

    public override void Update()
    {

    }
}

