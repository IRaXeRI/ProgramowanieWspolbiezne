using Project;

namespace TPW_E1.Models;

using NUnit.Framework;

public class TestBoardData
{
    private BoardData testBoard = new BoardLogic(10,10);
    
    [Test]
    public void lengthTest() {
        Assert.True(testBoard.Length==9);
    }
    
    [Test]
    public void widthTest() {
        Assert.True(testBoard.Width==9);
    }

    [Test]
    public void pointsTest() {
        Assert.True(testBoard.points.Count==0);
    }
}