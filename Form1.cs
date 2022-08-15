

using System.Drawing.Drawing2D;
using System.Text.Json;
using DebugTools.Tools;
using Microsoft.VisualBasic.Devices;
using UtilsN;

namespace AICar;

public partial class Form1 : Form
{
    public Game game;

    public bool creatingLine;

    public Vector2 startPoint;

    public Form1()
    {
        InitializeComponent();
        
        var inspector = new Inspector();
        
        game = new Game();
    }
    
    private void Update(object sender, EventArgs e) 
    {
        game.Update();

        pictureBox.Invalidate();
    }

    private void Draw(object sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        
        if (fitnessCheckBox.Checked)
        {
            foreach (Line line in Game.fitnessLines)
            {
                e.Graphics.DrawLines(new Pen(Color.Green, 5), new [] { (PointF)line.start, (PointF)line.end });
            }
        }
        
        game.car.Draw(e.Graphics);
        
        foreach (Line line in Game.lines)
        {
            e.Graphics.DrawLines(new Pen(Color.Black, 5), new [] { (PointF)line.start, (PointF)line.end });
        }

        
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
}