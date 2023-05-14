using System.Collections.ObjectModel;
using Data;
using Logic;

namespace Presentation.Model;

internal class ModelType : APIModel
{
    private readonly APILogic logic;
    private ObservableCollection<InterfaceModelBall> Balls = new();

    public ModelType() : this(APILogic.Prepare(500, 500, 20))
    {
    }

    public ModelType(APILogic initLogic)
    {
        logic = initLogic;
    }

    public override ObservableCollection<InterfaceModelBall> GetObservableCollection()
    {
        Balls.Clear();
        foreach (InterfaceBall ball in logic.GetAllBalls())
        {
            InterfaceModelBall newBall = InterfaceModelBall.CreateBall(ball.CoordX, ball.CoordY, ball.Radius);
            Balls.Add(newBall);
            ball.PropertyChanged += newBall.UpdateBall!;
        }

        return Balls;
    }

    public override void CreateBall()
    {
        logic.CreateBalls(1);
    }

    public override void CreateNBalls(int n)
    {
        logic.CreateBalls(n);
    }

    public override void ClearBalls()
    {
        logic.clearRepository();
    }
}