using Project;
using TPW_E1.Models;

namespace HelloWorld;
using NUnit.Framework;

public class TestBallLogic
{
    [Test]
    public void moveInXPositiveTest()
    {
        BallData testBall = new BallLogic(6,6,2,2);
        testBall.update(10, 10);
        Assert.True(testBall.CoordX==8);
    }

    [Test]
    public void moveInXNegativeTest()
    {
        BallData testBall = new BallLogic(6,6,-2,-2);
        testBall.update(10, 10);
        Assert.True(testBall.CoordX==4);
    }

    [Test]
    public void moveInYPositiveTest() {
        BallData testBall = new BallLogic(6,6,2,2);
        testBall.update(10, 10);
        Assert.True(testBall.CoordY==8);
    }

    [Test]
    public void moveInYNegativeTest()
    {
        BallData testBall = new BallLogic(6,6,-2,-2);
        testBall.update(10, 10);
        Assert.True(testBall.CoordY==4);
    }

    [Test]
    public void upBorderTest()
    {
        BallData testBall = new BallLogic(3,3,-4,-4);
        testBall.update(10,10);
        Assert.True(testBall.CoordY==1);
    }
    
    [Test]
    public void downBorderTest() {
        BallData testBall = new BallLogic(7,7,4,4);
        testBall.update(10,10);
        Assert.True(testBall.CoordY==9);
    }
    
    [Test]
    public void leftBorderTest() {
        BallData testBall = new BallLogic(3,3,-4,-4);
        testBall.update(10,10);
        Assert.True(testBall.CoordX==1);
    }

    [Test]
    public void rightBorderTest() {
        BallData testBall = new BallLogic(7,7,4,4);
        testBall.update(10,10);
        Assert.True(testBall.CoordY==9);
    }

} 