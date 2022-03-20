using SFML.Graphics;
using SFML.System;

public class Floor2 : Floor
{
    public Floor2(int Index) : base(Index)
    {
        //Setup Sprite
        sprite = new Sprite(Game.TextureAtlas, new IntRect(32, 80, 32, 32));
        sprite.Origin = new Vector2f(16, 0);
    }
}