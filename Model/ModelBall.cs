using System.ComponentModel;
using System.Runtime.CompilerServices;
using Logic;

namespace Presentation.Model;

internal class ModelBall : InterfaceModelBall, INotifyPropertyChanged
{
    private int coordX;
    private int coordY;
    private double radius;

    public override int CoordX
    {
        get => coordX;
        set
        {
            coordX = value;
            RaisePropertyChanged(nameof(CoordX));
        }
    }

    public override int CoordY
    {
        get => coordY;
        set
        {
            coordY = value;
            RaisePropertyChanged(nameof(CoordY));
        }
    }

    public override double Radius
    {
        get => radius;
    }

    public override event PropertyChangedEventHandler? PropertyChanged;

    public ModelBall(int initX, int initY, int initRadius)
    {
        CoordX = initX;
        CoordY = initY;
        radius = (double) initRadius;
    }

    public override void UpdateBall(Object s, PropertyChangedEventArgs e)
    {
        InterfaceBall ball = (InterfaceBall) s;
        if (e.PropertyName == nameof(CoordX))
        {
            CoordX = ball.CoordX;
        }
        else if (e.PropertyName == nameof(CoordY))
        {
            CoordY = ball.CoordY;
        }
    }

    private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}