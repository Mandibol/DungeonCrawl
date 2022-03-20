using SFML.Graphics;
using SFML.System;
using SFML.Window;

/// <summary>
/// A class setting up the game and managing the game loop
/// </summary>
public class Game
{
    //USED for GAME Mechanics and Rendering
    private static Time deltaTime;
    private static Time time;

    //USED for calcultaing position on grid
    private static Vector2i gridSize = new Vector2i(32, 32);
    private static int gridCellWidth = 32;
    private static int gridCellHeight = 16;
    private static Vector2i gridOffset = new Vector2i(512, 64);

    //Window Settings
    private static int frameRateLimit = 60;
    private static Vector2u resolution = new Vector2u(1024, 576);
    private static Vector2u pixelArtResolution = new Vector2u(1024, 576);
    private static VideoMode videoMode = new VideoMode(resolution.X, resolution.Y);
    private static RenderWindow window = new RenderWindow(videoMode, "Dungeon Crawl", Styles.Default);
    private static View view = new View((Vector2f)pixelArtResolution / 2, (Vector2f)pixelArtResolution);

    //Classes that make up the base of the GameApp
    private static Texture textureAtlas = new Texture("Art/TileMap.png");
    private static Level currentLevel = new Level("Art/TileMap.tmx");
    private static List<Level> levelList = new();
    private static Renderer renderer = new();
    private static Controller controller = new();

    //Properties
    public static Vector2i GridSize { get { return gridSize; } set { gridSize = value; } }
    public static int GridCellWidth { get { return gridCellWidth; } }
    public static int GridCellHeight { get { return gridCellHeight; } }
    public static Vector2i GridOffset { get { return gridOffset; } }
    public static Renderer Renderer { get { return renderer; } }
    public static Controller Controller { get { return controller; } }
    public static List<Level> LevelList { get { return levelList; } }
    public static Level CurrentLevel { get { return currentLevel; } set { currentLevel = value; } }
    public static Time DeltaTime { get { return deltaTime; } }
    public static Texture TextureAtlas { get { return textureAtlas; } }
    public static int FrameRateLimit { get { return frameRateLimit; } }
    public static RenderWindow Window { get { return window; } }
    public static View WinView { get { return view; } }

    /// <summary>
    /// Main method in wich the Game Runs
    /// </summary>
    public void Run()
    {
        //Setup GameClock 
        Clock clock = new Clock();
        //time = clock.ElapsedTime;
        Time previousTime = time;

        //Setup GameWindow
        window.SetView(view);
        window.SetFramerateLimit(60);
        window.Closed += Window_Closed;

        //Game Loop
        while (window.IsOpen)
        {
            previousTime = time;
            time = clock.ElapsedTime;
            deltaTime = time - previousTime;

            //End Game
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                window.Close();
            }

            //Do Game Actions
            controller.Update();
            //Draw Art
            renderer.Render();
        }
    }

    /// <summary>
    /// Enable the WindowCloseButton to Close the GameWindow
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    static void Window_Closed(object? sender, EventArgs e)
    {
        window.Close();
    }
}

