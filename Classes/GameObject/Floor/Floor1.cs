using SFML.Graphics;
using SFML.System;

public class Floor1 : Floor
{
    public Floor1(int Index) : base(Index)
    {
        //Setup Sprite
        sprite = new Sprite(Game.TextureAtlas, new IntRect(0, 80, 32, 32));
        sprite.Origin = new Vector2f(16, 0);
    }
}