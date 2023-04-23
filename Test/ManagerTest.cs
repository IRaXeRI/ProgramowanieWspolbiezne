using Logic;

namespace Tests
{
    public class ManagerTest
    {
        APILogic testManager;

        [SetUp]
        public void Setup()
        {
            testManager = APILogic.Prepare(10,10,1);
        }


        [Test]
        public void addBallTest()
        {
            Assert.True(testManager.GetAllBalls().Count == 0);
            testManager.CreateBall();
            Assert.True(testManager.GetAllBalls().Count == 1);
            Assert.True(testManager.GetAllBalls()[0].CoordX >= 1);
            Assert.True(testManager.GetAllBalls()[0].CoordX <= 10);
            Assert.True(testManager.GetAllBalls()[0].CoordY >= 1);
            Assert.True(testManager.GetAllBalls()[0].CoordY <= 10);
            Assert.True(testManager.GetAllBalls()[0].VelX >= -5);
            Assert.True(testManager.GetAllBalls()[0].VelX <= 5);
            Assert.True(testManager.GetAllBalls()[0].VelY >= -5);
            Assert.True(testManager.GetAllBalls()[0].VelY <= 5);
        }

        [Test]
        public void updateTest()
        {
            testManager.clearRepository();
            testManager.CreateControledBall(5,5,1,-1,1);
            testManager.Update(null);
            Assert.True(testManager.GetAllBalls()[0].CoordX == 6);
            Assert.True(testManager.GetAllBalls()[0].CoordY == 4);
        }
    }
}
