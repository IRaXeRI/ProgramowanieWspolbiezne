using Project;

namespace TPW_E1.Models;

using NUnit.Framework;

public class TestBallData : BallData {
    private BallData testBall = new BallLogic(6,6, 6, 6);
    
    [Test]
    public void TestCoordX() {
        CoordX = 2;
        Assert.True(CoordX==2);
    }
    
    [Test]
    public void TestCoordY() {
        CoordY = 3;
        Assert.True(CoordY==3);
    }
    
    [Test]
    public void TestVelocityX() {
        VelX = 4;
        Assert.True(VelX==4);
    }
    
    [Test]
    public void TestVelocityY() {
        VelY = 1;
        Assert.True(VelY==1);
    }

    public override void update(int boardLength, int boardWidth)
    {
    }
}