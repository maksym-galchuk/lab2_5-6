using System.Numerics;

namespace Task1;

public class Point<T> where T : ISignedNumber<T> {
    private T x;
    private T y;
    
    public Point() {
        x = (T)Convert.ChangeType(0, typeof(T));
        y = (T)Convert.ChangeType(0, typeof(T));
    }
    
    public Point(T x, T y) {
        this.x = x;
        this.y = y;
    }
    
    public T X {
        get { return x; }
        set { x = value; }
    }
    
    public T Y {
        get { return y; }
        set { y = value; }
    }
    
    public double DistanceTo(Point<T> other) {
        double x1 = Convert.ToDouble(x);
        double y1 = Convert.ToDouble(y);
        double x2 = Convert.ToDouble(other.x);
        double y2 = Convert.ToDouble(other.y);
        
        double dx = x2 - x1;
        double dy = y2 - y1;
        double distance = Math.Sqrt(dx * dx + dy * dy);

        return distance;
    }
    
    public static bool operator ==(Point<T> p1, Point<T> p2) {
        if (object.ReferenceEquals(p1, null) && object.ReferenceEquals(p2, null))
            return true;
        
        if (object.ReferenceEquals(p1, null) || object.ReferenceEquals(p2, null))
            return false;
        
        return p1.X.Equals(p2.X) && p1.Y.Equals(p2.Y);
    }
    
    public static bool operator !=(Point<T> p1, Point<T> p2) {
        return !(p1 == p2);
    }
    
    public override string ToString() {
        return $"({x}, {y})";
    }

}