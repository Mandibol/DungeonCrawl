using SFML.Graphics;
using SFML.System;

public class Floor4 : Floor
{
    public Floor4(int Index) : base(Index)
    {
        //Setup Sprite
        sprite = new Sprite(Game.TextureAtlas, new IntRect(96, 80, 32, 32));
        sprite.Origin = new Vector2f(16, 0);
    }
}