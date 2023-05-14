using Data;
using Logic;

namespace Tests
{
    public class DataTests
    {
        APIData testData;
        InterfaceBall testBall1 = InterfaceBall.CreateBall(10, 10, 3, 3, 5, 5, 100, 100);
        [SetUp]
        public void Setup()
        {
            testData = APIData.PrepareRepository();
        }

        [Test]
        public void TestGetList()
        {
            List<InterfaceBall> temp = testData.Balls;
            Assert.IsTrue(temp.Count == 0);
        }


        [Test]
        public void TestAddBall()
        {
            testData.addBall(testBall1);
            Assert.IsTrue(testData.getAmountOfBalls() == 1);
        }

        [Test]
        public void TestRemoveBall() {
            testData.removeBall(testBall1);
            List<InterfaceBall> temp = testData.Balls;
            Assert.IsTrue(temp.Count == 0);
        }

        [Test]
        public void TestGetAmountOfBalls() { 
            testData.addBall(testBall1);
            testData.addBall(testBall1);
            testData.addBall(testBall1);
            Assert.IsTrue(testData.getAmountOfBalls() == 3);
        }

        public void TestRemoveAllBalls() {
            testData.removeAllBalls();
            List<InterfaceBall> temp = testData.Balls;
            Assert.IsTrue(temp.Count == 0);
            Assert.IsTrue(testData.getAmountOfBalls() == 0);
        }
    }
}