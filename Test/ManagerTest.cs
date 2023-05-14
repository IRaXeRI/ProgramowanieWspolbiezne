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
            testManager.CreateBalls(1);
            Assert.True(testManager.GetAllBalls().Count == 1);
        }

        [Test]
        public void deleteBallsTest()
        {
            testManager.clearRepository();
            Assert.True(testManager.GetAllBalls().Count == 0);
        }
    }
}
