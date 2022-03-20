using System.Xml;

public class Level
{
    public int Width = 0;
    public int Height = 0;
    public List<int> BaseLayer = new List<int>();
    public List<int> ObjectLayer = new List<int>();

    /// <summary>
    /// Load External Data from file to Construct a Level.
    /// </summary>
    /// <param name="filename"> Filepath for level filed to load data from</param>
    public Level(string filename)
    {
        LoadLevelData(filename);
    }
    /// <summary>
    /// Parse the tmx(xml) file from tiled to Generate Data used to construct a level
    /// </summary>
    /// <param name="filename"></param>
    void LoadLevelData(string filename)
    {
        //Create the Level
        try
        {
            //Load Level File
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            //Get Level Size
            XmlNode xmlNode = doc["map"]!;
            Width = int.Parse(xmlNode.Attributes!["width"]!.Value);
            Height = int.Parse(xmlNode.Attributes!["height"]!.Value);
            //Get BaseLayer Data
            xmlNode = doc["map"]!["layer"]!;
            string data = xmlNode["data"]!.InnerXml;
            BaseLayer = data.Split('\u002C').Select(int.Parse).ToList();
            //Get ObjectLayer Data
            xmlNode = xmlNode.NextSibling!;
            data = xmlNode["data"]!.InnerXml;
            ObjectLayer = data.Split('\u002C').Select(int.Parse).ToList();
        }
        catch (Exception)
        {
            Console.WriteLine("Could Not Load Level Data");
            throw;
        }
    }
}

