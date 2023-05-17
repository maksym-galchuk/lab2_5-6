using System.Numerics;

namespace Task1; 

public class Line<T> where T : ISignedNumber<T> {
    private Point<T> p1;
    private Point<T> p2;
    private Point<double> mid;

    private double length; 
    
    public Line(Point<T> p1, Point<T> p2) {
        if (p1 == p2) throw new ArgumentException("The points must be different");
        
        this.p1 = p1;
        this.p2 = p2;
        
        mid = CalculateMidpoint();
        length = CalculateLength();
                
    }
    
    public Point<T> P1 => p1;
    public Point<T> P2 => p2;
    public Point<double> Mid => mid;
    public double Length => length;

    private double CalculateLength() => p1.DistanceTo(p2);

    private Point<double> CalculateMidpoint() {
        double x1 = Convert.ToDouble(p1.X);
        double y1 = Convert.ToDouble(p1.Y);
        double x2 = Convert.ToDouble(p2.X);
        double y2 = Convert.ToDouble(p2.Y);
        
        double mx = (x1 + x2) / 2;
        double my = (y1 + y2) / 2;    
        
        return new Point<double>(mx, my);
    }
    
    public void ChangeP1(Point<T> newP1) {
        if (p2 == newP1) throw new ArgumentException("The points must be different");
        
        p1 = newP1;
        
        mid = CalculateMidpoint();
        length = CalculateLength();
    }
    
    public void ChangeP2(Point<T> newP2) {
        if (p1 == newP2) throw new ArgumentException("The points must be different");
        
        p2 = newP2;
        
        mid = CalculateMidpoint();
        length = CalculateLength();
    }
    
    public override string ToString() {
        return $"Line: P1 = {p1}, P2 = {p2}, Mid = {mid}, Length = {Math.Round(length, 2)}";
    }
}