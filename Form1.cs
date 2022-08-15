

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
    
    public Car car;
    
    public static List<Line> lines = new List<Line>();
    public static List<Line> fitnessLines = new List<Line>();

    public Form1()
    {
        InitializeComponent();
        
        var inspector = new Inspector();
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
    
    private void Update(object sender, EventArgs e) {
        car.Update();

        // Focus();

        pictureBox.Invalidate();
    }

    private void Draw(object sender, PaintEventArgs e)
    {
        if (fitnessCheckBox.Checked)
        {
            foreach (Line line in fitnessLines)
            {
                e.Graphics.DrawLines(new Pen(Color.Green, 5), new [] { (PointF)line.start, (PointF)line.end });
            }
        }
        
        car.Draw(e.Graphics);
        
        foreach (Line line in lines)
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
        car.KeyDown(keyEventArgs.KeyCode);
    }

    private void KeysUp(object? sender, KeyEventArgs e)
    {
        car.KeyUp(e.KeyCode);
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
                fitnessLines.Add(new Line(startPoint, eventArgs.Location));
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
        string json = JsonSerializer.Serialize(fitnessLines);
        File.WriteAllText("fitnessLines.json", json);
    }
}