using SharpNeat.Experiments;
using SharpNeat.Neat;
using SharpNeat.Neat.Genome.IO;

namespace AICar;

static class Program
{
    public static int CarsDone = 0;
    public static int CarsToDo = 50;
    
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        bool train = true;

        if (!train)
        {
            Application.Run(new GameViewer());
        }
        else
        {
            var experimentFactory = new GameExperimentFactory();
            using FileStream fs = File.OpenRead("F:\\Software_developer\\C#\\AICar\\aiCar.config.json");
            INeatExperiment<double> experiment = experimentFactory.CreateExperiment(fs);
            var ea = NeatUtils.CreateNeatEvolutionAlgorithm(experiment);

            ea.Initialise();
            
            
            Console.CancelKeyPress += delegate {
                Console.WriteLine("Cancelling...");
                NeatGenomeSaver.Save(ea.Population.BestGenome, $"F:\\Software_developer\\C#\\AICar\\Genomes\\bestGenome.net");
            };


            // CarsToDo = ea.Population.GenomeList.Count;
            for (var i = 0; i < 100000; i++)
            {
                ea.PerformOneGeneration();
                Console.WriteLine($"Generation {ea.Stats.Generation} | Best Fitness {ea.Population.BestGenome.FitnessInfo.PrimaryFitness} | Avg Fitness {ea.Population.Stats.MeanFitness}");

                // NeatGenomeSaver.Save(ea.Population.BestGenome, $"F:\\Software_developer\\C#\\AICar\\Genomes\\bestGenome.net");

                CarsDone = 0;
            }
        }
        
    }
}