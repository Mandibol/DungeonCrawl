using SFML.Graphics;
using SFML.System;

public class Floor7 : Floor
{
    public Floor7(int Index) : base(Index)
    {
        //Setup Sprite
        sprite = new Sprite(Game.TextureAtlas, new IntRect(192, 80, 32, 32));
        sprite.Origin = new Vector2f(16, 0);
    }
}