public enum Rotation
{
    North, East, West, South, Length
}

public class Controller
{
    public GridMouse gridMouse = new();
    public Input input = new();

    public GameObject[] staticArray;
    public GameObject[] objectArray;
    public bool[] collisionArray;
    public Rotation rotation = Rotation.North;

    public Controller()
    {
        staticArray = new GameObject[Game.CurrentLevel.BaseLayer.Count];
        objectArray = new GameObject[Game.CurrentLevel.BaseLayer.Count];
        collisionArray = new bool[Game.CurrentLevel.BaseLayer.Count];

        //Create a Array of Gameobjects from TerrainData
        List<int> baseLayer = Game.CurrentLevel.BaseLayer;
        List<int> objectLayer = Game.CurrentLevel.ObjectLayer;
        for (int i = 0; i < baseLayer.Count; i++)
        {
            switch (baseLayer[i])
            {
                case 1:
                    staticArray[i] = new Wall(i);
                    collisionArray[i] = true;
                    break;
                case 9:
                    staticArray[i] = new Floor1(i);
                    collisionArray[i] = false;
                    break;
                case 10:
                    staticArray[i] = new Floor2(i);
                    collisionArray[i] = false;
                    break;
                case 11:
                    staticArray[i] = new Floor3(i);
                    collisionArray[i] = false;
                    break;
                case 12:
                    staticArray[i] = new Floor4(i);
                    collisionArray[i] = false;
                    break;
                case 13:
                    staticArray[i] = new Floor5(i);
                    collisionArray[i] = false;
                    break;
                case 14:
                    staticArray[i] = new Floor6(i);
                    collisionArray[i] = false;
                    break;
                case 15:
                    staticArray[i] = new Floor7(i);
                    objectArray[i] = new DoorRight(i);
                    collisionArray[i] = true;
                    break;
                case 16:
                    staticArray[i] = new Floor8(i);
                    objectArray[i] = new DoorLeft(i);
                    collisionArray[i] = true;
                    break;
                default:
                    break;
            }
            switch (objectLayer[i])
            {
                case 17:
                    objectArray[i] = new Player(i, staticArray[i].floorheight);
                    collisionArray[i] = true;
                    break;
                case 25:
                    objectArray[i] = new Box(i, staticArray[i].floorheight);
                    collisionArray[i] = true;
                    break;
                default:
                    break;
            }
        }
    }


    internal void Update()
    {
        foreach (GameObject obj in staticArray)
        {
            if (obj != null) { obj.Update(); }
        }

        gridMouse.Update();
    }
}