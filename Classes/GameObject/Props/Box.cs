using SFML.Graphics;
using SFML.System;

internal class Box : Prop
{
    public Box(int Index, int FloorHeight) : base(Index, FloorHeight)
    {
        //Setup Sprite
        sprite = new Sprite(Game.TextureAtlas, new IntRect(0, 224, 32, 32));
        sprite.Origin = new Vector2f(16, 16);
    }
}
