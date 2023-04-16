using Project;

namespace TPW_E1.Models;

using NUnit.Framework;

public class TestBoardLogic
{
    private BoardData testBoard = new BoardLogic(15,15);
    [Test]
    public void addBallTest()
    {
        Assert.True(testBoard.points.Count==0);
        testBoard.addBall();
        Assert.True(testBoard.points.Count==1);
        Assert.True(testBoard.points[0].CoordX>=1);
        Assert.True(testBoard.points[0].CoordX<=testBoard.Length);
        Assert.True(testBoard.points[0].CoordY>=1);
        Assert.True(testBoard.points[0].CoordY<=testBoard.Width);
        Assert.True(testBoard.points[0].VelX>=1);
        Assert.True(testBoard.points[0].VelX<=10);
        Assert.True(testBoard.points[0].VelY>=1);
        Assert.True(testBoard.points[0].VelY<=10);
    }

    [Test]
    public void updateTest() {
        testBoard = new BoardLogic(10,10);
        testBoard.addBall(new BallLogic(5,5,3,-3));
        bool[,] answer = testBoard.update();
        Assert.True(testBoard.points[0].CoordX==8);
        Assert.True(testBoard.points[0].CoordY==2);
        Assert.True(answer[8,2]);
    }
}