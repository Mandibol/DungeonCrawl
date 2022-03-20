using SFML.Graphics;
using SFML.System;

public class Floor8 : Floor
{
    public Floor8(int Index) : base(Index)
    {
        //Setup Sprite
        sprite = new Sprite(Game.TextureAtlas, new IntRect(224, 80, 32, 32));
        sprite.Origin = new Vector2f(16, 0);
    }
}