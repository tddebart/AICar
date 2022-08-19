

using System.Drawing.Drawing2D;
using System.Text.Json;
using System.Xml;
using DebugTools.Tools;
using Microsoft.VisualBasic.Devices;
using SharpNeat.IO;
using SharpNeat.Neat.Genome;
using SharpNeat.Neat.Genome.IO;
using SharpNeat.NeuralNets.Double.ActivationFunctions;
using SharpNeat.Windows;
using SharpNeat.Windows.App.Forms;
using SharpNeat.Windows.Neat;
using UtilsN;

namespace AICar;

public partial class GameViewer : Form
{
    public Game game;

    public bool creatingLine;

    public Vector2 startPoint;

    public GameViewer()
    {
        InitializeComponent();
        
        var inspector = new Inspector();
        
        game = new Game();

        // "F:\\Software_developer\\C#\\AICar\\train.xml"

    }
    
    private void Update(object sender, EventArgs e) 
    {
        game.Update();
        
        if (ActiveForm is GameViewer viewer) viewer.fitnessLabel.Text = $"Fitness: {game.car.fitness}";

        pictureBox.Invalidate();
    }

    private void Draw(object sender, PaintEventArgs e)
    {
        // Enable anti-aliasing.
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        
        // Draw the fitness checkpoint lines
        if (fitnessCheckBox.Checked)
        {
            foreach (Line line in Game.fitnessLines)
            {
                e.Graphics.DrawLines(new Pen(Color.Green, 5), new [] { (PointF)line.start, (PointF)line.end });
            }
        }
        
        // Draw the game car.
        game.car.Draw(e.Graphics);
        
        // Draw the walls
        foreach (Line line in Game.lines)
        {
            e.Graphics.DrawLines(new Pen(Color.Black, 5), new [] { (PointF)line.start, (PointF)line.end });
        }
        
        // Draw the NearalNetwork Inputs

        for (var i = 0; i < game.car.sensors.readings.Length; i++)
        {
            var input = game.car.sensors.readings[i];
            var color = Color.FromArgb((int)(input * 255), 0, 255, 0);
            e.Graphics.FillEllipse(new SolidBrush(color) , 1600 + i * 50, 50, 50, 50);
        }
        
        for (var i = 0; i < game.car.sensors.readings.Length; i++)
        {
            var input = i switch
            {
                1 => game.car.controls.forward ? 1 : 0.25f,
                2 => game.car.controls.left ? 1 : 0.25f,
                3 => game.car.controls.right ? 1 : 0.25f,
                4 => game.car.controls.backward ? 1 : 0.25f,
                _ => 0
            };

            var color = Color.FromArgb((int)(input * 255), 0, 255, 0);
            e.Graphics.FillEllipse(new SolidBrush(color) , 1600 + i * 50, 100, 50, 50);
        }
        
        

        // Draw the drawing line
        if (creatingLine)
        {
            e.Graphics.DrawLine(new Pen(Color.Black, 5), startPoint, pictureBox.PointToClient(Cursor.Position));
        }
    }

    public void KeysDown(object? sender, KeyEventArgs keyEventArgs)
    {
        game.car.KeyDown(keyEventArgs.KeyCode);
    }

    private void KeysUp(object? sender, KeyEventArgs e)
    {
        game.car.KeyUp(e.KeyCode);
    }

    private void pictureBox_Click(object? sender, MouseEventArgs eventArgs)
    {
        if (eventArgs.Button == MouseButtons.Left)
        {
            if (!creatingLine)
            {
                startPoint = eventArgs.Location;
                creatingLine = true;
            } else
            {
                Game.fitnessLines.Add(new Line(startPoint, eventArgs.Location));
                creatingLine = false;
            }
        }
        else
        {
            creatingLine = false;
        }
    }

    private void button1_Click(object sender, EventArgs e) 
    {
        // Save the lines to json
        string json = JsonSerializer.Serialize(Game.fitnessLines);
        File.WriteAllText("fitnessLines.json", json);
    }

    private void indexForw_Click(object sender, EventArgs e) 
    {
        genomeIndex++;
        genomeIndexControl.Text = genomeIndex.ToString();
        game = new Game(true, genomeIndex);
    }

    private void indexBack_Click(object sender, EventArgs e) 
    {
        genomeIndex--;
        genomeIndexControl.Text = genomeIndex.ToString();
        game = new Game(true, genomeIndex);
    }
}