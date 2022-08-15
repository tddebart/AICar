
using System.Diagnostics;
using UtilsN;

public class Sensors
{
    public Car car;
    public const int rayCount = 5;
    public const int rayLength = 350;
    public const float raySpread = MathF.PI / 5;
    
    public List<Line> rays = new ();
    public Vector2[] pointReadings = new Vector2[rayCount];
    public float[] readings = new float[rayCount];
    
    public Sensors(Car car)
    {
        this.car = car;
    }

    public void Update()
    {
        CastRays();

        for (var i = 0; i < rays.Count; i++)
        {
            pointReadings[i] = GetReading(rays[i], out readings[i]);
        }
        
        Debug.WriteLine(readings[0]);
    }

    public void CastRays()
    {
        rays.Clear();
        
        for (float i = 0; i < rayCount; i++)
        {
            float angle = Utils.Lerp(raySpread / 2, -raySpread / 2, rayCount == 1 ? 0.5f : i / (rayCount - 1)) - car.angle;
            Vector2 rayOrigin = car.position;
            Vector2 rayEnd = new Vector2(rayOrigin.x - rayLength * MathF.Sin(angle), rayOrigin.y - rayLength * MathF.Cos(angle));
            rays.Add(new Line(rayOrigin, rayEnd));
        }
    }

    public Vector2 GetReading(Line ray, out float distanceReading)
    {
        Vector2 reading = new Vector2(ray.end.x, ray.end.y);
        distanceReading = 1;

        foreach (var line in car.lines)
        {
            if (Utils.GetIntersection(ray.start, ray.end, line.start, line.end, out var intersection))
            {
                if (intersection.offset < distanceReading)
                {
                    reading = intersection.point;
                    distanceReading = intersection.offset;   
                }
            }
        }
        
        return reading;
    }

    public void Draw(Graphics g)
    {
        for (var i = 0; i < rays.Count; i++)
        {
            var ray = rays[i];
            g.DrawLine(new Pen(Color.Black, 4.5f), ray.start, ray.end);
            
            g.DrawLine(new Pen(Color.Yellow, 5) , ray.start, pointReadings[i]);
        }
    }
}
