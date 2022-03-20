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
    public Rotation rotation = Rotation.North;

    public Controller()
    {
        staticArray = new GameObject[Game.CurrentLevel.BaseLayer.Count];
        objectArray = new GameObject[Game.CurrentLevel.BaseLayer.Count];

        //Create a Array of Gameobjects from TerrainData
        List<int> baseLayer = Game.CurrentLevel.BaseLayer;
        List<int> objectLayer = Game.CurrentLevel.ObjectLayer;
        for (int i = 0; i < baseLayer.Count; i++)
        {
            switch (baseLayer[i])
            {
                case 1:
                    objectArray[i] = new Wall(i);
                    break;
                case 9:
                    staticArray[i] = new Floor1(i);
                    break;
                case 10:
                    staticArray[i] = new Floor2(i);
                    break;
                case 11:
                    staticArray[i] = new Floor3(i);
                    break;
                case 12:
                    staticArray[i] = new Floor4(i);
                    break;
                case 13:
                    staticArray[i] = new Floor5(i);
                    break;
                case 14:
                    staticArray[i] = new Floor6(i);
                    break;
                case 15:
                    staticArray[i] = new Floor7(i);
                    objectArray[i] = new DoorRight(i);
                    break;
                case 16:
                    staticArray[i] = new Floor8(i);
                    objectArray[i] = new DoorLeft(i);
                    break;
                default:
                    break;
            }
            switch (objectLayer[i])
            {
                case 17:
                    objectArray[i] = new Player(i, staticArray[i].floorheight);
                    break;
                case 25:
                    objectArray[i] = new Box(i, staticArray[i].floorheight);
                    break;
                default:
                    break;
            }
        }
    }


    internal void Update()
    {
        //manage turn order

        //state 
        for (int i = 0; i < staticArray.Length; i++)
        {
            if (staticArray[i] != null) { staticArray[i].Update(); }
            if (objectArray[i] != null) { objectArray[i].Update(); }
        }

        gridMouse.Update();
    }
}