using SFML.Graphics;
using SFML.System;

public class Floor6 : Floor
{
    public Floor6(int Index) : base(Index)
    {
        //Setup Sprite
        sprite = new Sprite(Game.TextureAtlas, new IntRect(160, 80, 32, 32));
        sprite.Origin = new Vector2f(16, 0);
    }
}