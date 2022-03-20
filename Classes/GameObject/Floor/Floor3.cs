using SFML.Graphics;
using SFML.System;

public class Floor3 : Floor
{
    public Floor3(int Index) : base(Index)
    {
        //Setup Sprite
        sprite = new Sprite(Game.TextureAtlas, new IntRect(64, 80, 32, 32));
        sprite.Origin = new Vector2f(16, 0);
    }
}