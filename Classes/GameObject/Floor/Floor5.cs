using SFML.Graphics;
using SFML.System;

public class Floor5 : Floor
{
    public Floor5(int Index) : base(Index)
    {
        //Setup Sprite
        sprite = new Sprite(Game.TextureAtlas, new IntRect(128, 80, 32, 32));
        sprite.Origin = new Vector2f(16, 0);
    }
}