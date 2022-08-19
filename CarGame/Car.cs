using AICar;
using UtilsN;

public class Car
{
    public Vector2 position;
    public int width;
    public int height;
    public Color color;

    public float speed;
    public float acceleration = 0.2f;
    public float maxSpeed;
    public float friction = 0.02f;
    public float angle;

    public bool damaged;
    private readonly bool playerControlled;
    
    public Controls controls;
    public Sensors sensors;

    public List<Line> lines => Game.lines;
    public List<Line> fitnessLines => Game.fitnessLines;

    public long ticksPassedSinceLastCheckpoint;

    public PointF[] polygon = new PointF[4];


    public float fitness = 0;
    private int fitnessIndex = 0;
    private int laps = 0;

    public Car(Vector2 position, int width, int height, float maxSpeed, Color color, bool playerControlled = false)
    {
        this.position = position;
        this.width = width;
        this.height = height;
        this.maxSpeed = maxSpeed;
        this.color = color;
        this.playerControlled = playerControlled;
        
        controls = new Controls();
        sensors = new Sensors(this);
    }

    public void Update()
    {
        ticksPassedSinceLastCheckpoint++;

        if (!damaged)
        {
            if (brain != null)
            {
                brain.Reset();
                var inputs = brain.Inputs.Span;
                inputs[0] = 1;
                for (var i = 1; i < sensors.readings.Length+1; i++)
                {
                    inputs[i] = sensors.readings[i-1];
                }
                
                brain.Activate();
                
                var outputs = brain.Outputs.Span;
                controls.forward = outputs[0] < 0.5;
                controls.left = outputs[1] > 0.5;
                controls.right = outputs[2] > 0.5;
                controls.backward = outputs[3] > 0.5;
            }
            
            CreatePolygon();
            damaged = AssesDamage();
            Move();
        }


        UpdateFitness();
        
        
        sensors.Update();
    }

    private bool AssesDamage()
    {
        foreach (var line in lines)
        {
            if (Utils.PolygonIntersects(polygon, line.ToArray()))
            {
                fitness -= 10;
                return true;
            }
        }
        
        if(ticksPassedSinceLastCheckpoint > 100)
        {
            fitness -= 50;
            return true;
        }
        
        if(fitness < 0) fitness = 0;
        
        return false;
    }

    private void UpdateFitness()
    {
        fitness = GetFitness();
    }

    public float GetFitness()
    {
        float fitness;
        
        if(Utils.PolygonIntersects(polygon, fitnessLines[fitnessIndex].ToArray()))
        {
            fitnessIndex++;
            ticksPassedSinceLastCheckpoint = 0;
        }
        
        if(fitnessIndex == fitnessLines.Count)
        {
            fitnessIndex = 0;
            laps++;
        }
        
        var maxDistance = Vector2.Distance(fitnessLines[fitnessIndex-1 < 0 ? fitnessLines.Count-1 : fitnessIndex-1].Center(), fitnessLines[fitnessIndex].Center());
        var extraInbetween = Vector2.Distance(position, fitnessLines[fitnessIndex].Center());

        fitness = fitnessIndex * 10 + laps * fitnessLines.Count * 10 + laps * 20 + (1-extraInbetween / maxDistance) * 10 - 4.550809383392334f;
        if(fitness < 0) fitness = 0;

        return fitness;
    }

    private void Move()
    {
        if (controls.forward)
        {
            speed += acceleration;
        }
        
        if (controls.backward)
        {
            speed -= acceleration;
        }

        if (speed != 0)
        {
            if (controls.left)
            {
                angle -= 0.06f;
            }
            
            if (controls.right)
            {
                angle += 0.06f;
            }
        }
        
        position.x += speed * MathF.Sin(angle);
        position.y -= speed * MathF.Cos(angle);

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        
        if (speed < -maxSpeed)
        {
            speed = -maxSpeed;
        }
        
        speed *= (1 - friction);
        
        if (MathF.Abs(speed) < 0.1) {
            speed = 0;
        }
    }
    
    public void KeyDown(Keys key)
    {
        if (!playerControlled) return;
        
        controls.KeyDown(key); 
    }
    
    public void KeyUp(Keys key)
    {
        if (!playerControlled) return;
        
        controls.KeyUp(key);    
    }
    
    
    private void CreatePolygon()
    {
        var rad = MathF.Sqrt(width * width + height * height) / 2;
        var alpha = MathF.Atan2(height, width);
        
        polygon[0] = new PointF(
            position.x - MathF.Cos(angle-alpha)*rad,
            position.y - MathF.Sin(angle-alpha)*rad
        );
        polygon[1] = new PointF(
            position.x - MathF.Cos(angle+alpha)*rad,
            position.y - MathF.Sin(angle+alpha)*rad
        );
        
        polygon[2] = new PointF(
            position.x - MathF.Cos(MathF.PI+angle-alpha)*rad,
            position.y - MathF.Sin(MathF.PI+angle-alpha)*rad
        );
        
        polygon[3] = new PointF(
            position.x - MathF.Cos(MathF.PI+angle+alpha)*rad,
            position.y - MathF.Sin(MathF.PI+angle+alpha)*rad
        );
    }

    public void Draw(Graphics g)
    {
        var brush = Brushes.Blue;
        if (damaged)
        {
            brush = Brushes.Gray;
        }
        
        g.FillPolygon(brush, polygon);

        
        sensors.Draw(g);
    }
}
