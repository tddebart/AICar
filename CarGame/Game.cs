
using System.Text.Json;
using UtilsN;

public class Game
{
    public Car car;
    
    public static List<Line> lines = new List<Line>();
    public static List<Line> fitnessLines = new List<Line>();

    public Game()
    {
        // Load lines
        if(File.Exists("lines.json"))
        {
            string json = File.ReadAllText("lines.json");
            lines = JsonSerializer.Deserialize<List<Line>>(json) ?? new List<Line>();
        }
        // Load fitness points
        if(File.Exists("fitnessLines.json"))
        {
            string json = File.ReadAllText("fitnessLines.json");
            fitnessLines = JsonSerializer.Deserialize<List<Line>>(json) ?? new List<Line>();
        }
        
        car = new Car(new Vector2(125, 500), 30,50,6, Color.Gray, true);
        Update();
    }

    public void Update()
    {
        car.Update();
    }
}
