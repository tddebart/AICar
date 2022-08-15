
namespace UtilsN
{
    public struct Line
    {
        public Vector2 start { get; set; }
        public Vector2 end { get; set; }
        
        public Line(PointF start, PointF end)
        {
            this.start = start;
            this.end = end;
        }

        public PointF[] ToArray()
        {
            return new PointF[] { start, end };
        }
        
        public Vector2 Center()
        {
            return (start + end) / 2;
        }
    }

    public static class Utils
    {
        public struct Intersection
        {
            public Vector2 point;
            public bool intersect;
            public float offset;
        }

        public static bool GetIntersection(Vector2 rayStart, Vector2 rayEnd, Vector2 lineStart, Vector2 lineEnd, out Intersection intersection)
        {
            var x1 = rayStart.x;
            var y1 = rayStart.y;
            var x2 = rayEnd.x;
            var y2 = rayEnd.y;
            var x3 = lineStart.x;
            var y3 = lineStart.y;
            var x4 = lineEnd.x;
            var y4 = lineEnd.y;
            intersection = new Intersection();
    
            var denom = ((y4-y3)*(x2-x1) - (x4-x3)*(y2-y1));
            if (denom == 0)
            {
                return false;
            }
            var ua = ((x4-x3)*(y1-y3) - (y4-y3)*(x1-x3)) / denom;
            var ub = ((x2-x1)*(y1-y3) - (y2-y1)*(x1-x3)) / denom;
            if (ua < 0 || ua > 1 || ub < 0 || ub > 1) {
                return false;
            }
            
            intersection.intersect = true;
            intersection.point = new Vector2(x1 + ua * (x2 - x1), y1 + ua * (y2 - y1));
            intersection.offset = ua;
            
            return true;
        }

        public static bool PolygonIntersects(PointF[] poly1, PointF[] poly2)
        {
            for (var i = 0; i < poly1.Length; i++)
            {
                for (var j = 0; j < poly2.Length; j++)
                {
                    if(GetIntersection(poly1[i], poly1[(i + 1) % poly1.Length], poly2[j], poly2[(j + 1) % poly2.Length], out _))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public static PointF[] ToPointArray(this Vector2[] v)
        {
            PointF[] points = new PointF[v.Length];
            for (int i = 0; i < v.Length; i++)
            {
                points[i] = v[i];
            }
            return points;
        }

        public static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * t;
        }
    }
    
    [Serializable]
    public struct Vector2
    {
        public float x { get; set; }
        public float y { get; set; }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static float Distance(Vector2 v1, Vector2 v2)
        {
            return MathF.Sqrt((v1.x - v2.x) * (v1.x - v2.x) + (v1.y - v2.y) * (v1.y - v2.y));
        }

        public static implicit operator Vector2(PointF p)
        {
            return new Vector2(p.X, p.Y);
        }

        public static implicit operator PointF(Vector2 v)
        {
            return new PointF(v.x, v.y);
        }

        public static implicit operator Vector2(Point p)
        {
            return new Vector2(p.X, p.Y);
        }

        public static implicit operator Point(Vector2 v)
        {
            return new Point((int)v.x, (int)v.y);
        }
        
        // ==
        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            return v1.x == v2.x && v1.y == v2.y;
        }

        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return !(v1 == v2);
        }

        // Math
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }
        
        public static Vector2 operator *(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x * v2.x, v1.y * v2.y);
        }
        
        public static Vector2 operator /(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x / v2.x, v1.y / v2.y);
        }

        public static Vector2 operator *(Vector2 v, float f)
        {
            return new Vector2(v.x * f, v.y * f);
        }

        public static Vector2 operator /(Vector2 v, float f)
        {
            return new Vector2(v.x / f, v.y / f);
        }
    }
    
}

