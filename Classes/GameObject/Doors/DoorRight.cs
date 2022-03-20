using SFML.Graphics;
using SFML.System;

internal class DoorRight : Door
{

    public DoorRight(int Index) : base(Index)
    {
        //Setup Sprite
        sprite = new Sprite(Game.TextureAtlas, new IntRect(32, 176, 32, 48));
        sprite.Origin = new Vector2f(16, 32);
        sprite2 = new Sprite(Game.TextureAtlas, new IntRect(0, 176, 32, 48));
        sprite2.Origin = new Vector2f(16, 32);
    }
}