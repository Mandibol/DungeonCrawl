using SFML.Graphics;
using SFML.System;
public class Wall : GameObject
{
    public List<Sprite> sprites = new();
    public static int height = 4;
    public bool hidden = false;

    public Wall(int Index) : base(Index)
    {
        //Setup Sprite
        sprites.Add(new Sprite(Game.TextureAtlas, new IntRect(64, 112, 32, 32)));//Black bottom
        sprites.Add(new Sprite(Game.TextureAtlas, new IntRect(0, 112, 32, 32)));// Middle piece
        sprites.Add(new Sprite(Game.TextureAtlas, new IntRect(0, 112, 32, 32)));// Middle piece
        sprites.Add(new Sprite(Game.TextureAtlas, new IntRect(32, 112, 32, 32)));//Topper
        for (int i = 0; i < sprites.Count; i++)
        {
            sprites[i].Origin = new Vector2f(16, 0);
            sprites[i].Position = new Vector2f(gridPosition.X, gridPosition.Y - (i * 16));
        }
    }

    public override void Update()
    {
        //get mouse grid position
        Vector2f mp = Game.Controller.gridMouse.gridPosition;

        hidden = false;
        foreach (var item in GridMouse.gridIndexes)
        {
            if (item == gridIndex && gridPosition.X >= mp.X && gridPosition.Y >= mp.Y) { hidden = true; }
        }
    }

    public override void Draw()
    {
        int drawHeight = height;
        if (hidden) drawHeight = 1;
        for (int i = 0; i < drawHeight; i++)
        {
            sprites[i].Position = new Vector2f(pixelPosition.X, pixelPosition.Y - (i * 16));
            Game.Window.Draw(sprites[i]);
        }
    }
}

