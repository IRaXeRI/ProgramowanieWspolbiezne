using System.ComponentModel;

namespace Presentation.Model;

public abstract class InterfaceModelBall
{
    public static InterfaceModelBall CreateBall(int xPosition, int yPosition, int radius)
    {
        return new ModelBall(xPosition, yPosition, radius);
    }

    public abstract event PropertyChangedEventHandler? PropertyChanged;
    public abstract int CoordX { get; set; }

    public abstract int CoordY { get; set; }

    public abstract double Radius { get;}

    public abstract void UpdateBall(Object s, PropertyChangedEventArgs e);
}