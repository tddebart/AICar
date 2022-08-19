
using System.Text.Json;
using SharpNeat;
using SharpNeat.Neat.Genome;
using SharpNeat.Neat.Genome.IO;
using SharpNeat.NeuralNets.Double.ActivationFunctions;
using SharpNeat.NeuralNets.IO;
using UtilsN;

public class Game
{
    public Car car;
    
    public static List<Line> lines = new List<Line>();
    public static List<Line> fitnessLines = new List<Line>();

    public NeatGenome<double>? genome;
    public IBlackBox<double> brain = null;

    public Game(bool showingBest = false, int loadIndex = 1)
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
        
        var filePath = "F:\\Software_developer\\C#\\AICar\\Genomes\\bestGenome.net";
        
        if (showingBest && File.Exists(filePath))
        {
            var metaNeatGenome = MetaNeatGenome<double>.CreateCyclic(Sensors.rayCount+1, 4,1, new LeakyReLU());
            genome = NeatGenomeLoader.Load(filePath, metaNeatGenome, loadIndex);
        
            

            var netFile = NeatGenomeConverter.ToNetFileModel(genome);
            brain = NeuralNetConverter.ToCyclicNeuralNet(netFile);
        }
        
        car = new Car(new Vector2(125, 500), 30,50,6, Color.Gray, false,brain);

        
        Update();
    }

    public void Update()
    {
        car.Update();
    }
}
