// This file is part of SharpNEAT; Copyright Colin D. Green.
// See LICENSE.txt for details.

using AICar;
using SharpNeat.Evaluation;

namespace SharpNeat.Tasks.CartPole.SinglePole;

/// <summary>
/// Evaluator for the cart and single pole balancing task.
/// </summary>
public sealed class GameEvaluator : IPhenomeEvaluator<IBlackBox<double>>
{
    public FitnessInfo Evaluate(IBlackBox<double> phenome)
    {
        double fitness = 0;
        
        for (var j = 0; j < 5; j++)
        {
            var game = new Game();
            while (!game.car.damaged)
            {
                // Reset the brain state.
                phenome.Reset();

                var inputs = phenome.Inputs.Span;

                // Biases are always 1.0.
                inputs[0] = 1;
                // Give the brain the inputs
                for (var i = 1; i < game.car.sensors.readings.Length+1; i++)
                {
                    inputs[i] = game.car.sensors.readings[i-1];
                }

                phenome.Activate();
                
                var outputs = phenome.Outputs.Span;

                game.car.controls.forward = outputs[0] > 0;
                game.car.controls.left = outputs[1] > 0;
                game.car.controls.right = outputs[2] > 0;
                game.car.controls.backward = outputs[0] > 0;
                
                game.Update();
            }

            fitness += game.car.GetFitness();
        }

        Program.CarsDone++;
        // Console.WriteLine($"{Program.CarsDone}/{Program.CarsToDo}");
        
        return new FitnessInfo(fitness/5);
    }
}
