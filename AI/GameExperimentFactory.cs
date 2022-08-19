using SharpNeat.Experiments;
using SharpNeat.Experiments.ConfigModels;
using SharpNeat.IO;
using SharpNeat.NeuralNets;
using SharpNeat.NeuralNets.Double.ActivationFunctions;
using SharpNeat.Tasks.CartPole.SinglePole;

/// <summary>
/// A factory for creating instances of <see cref="INeatExperiment{T}"/> for the game.
/// </summary>
public sealed class GameExperimentFactory : INeatExperimentFactory
{
    /// <inheritdoc/>
    public string Id => "car-game";

    /// <inheritdoc/>
    public INeatExperiment<double> CreateExperiment(Stream jsonConfigStream)
    {
        // Load experiment JSON config.
        ExperimentConfig experimentConfig = JsonUtils.Deserialize<ExperimentConfig>(jsonConfigStream);

        // Create an evaluation scheme object for the Single Pole Balancing task.
        var evalScheme = new GameEvaluationScheme();

        // Create a NeatExperiment object with the evaluation scheme,
        // and assign some default settings (these can be overridden by config).
        var experiment = new NeatExperiment<double>(evalScheme, Id);

        // Apply configuration to the experiment instance.
        experiment.Configure(experimentConfig);
        return experiment;
    }

    /// <inheritdoc/>
    public INeatExperiment<float> CreateExperimentSinglePrecision(Stream jsonConfigStream)
    {
        throw new NotImplementedException();
    }
}