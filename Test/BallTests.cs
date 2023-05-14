using Logic;

namespace Tests
{
    internal class BallTests
    {
        InterfaceBall testBall;
        
        [SetUp]
        public void Setup()
        {
            testBall = InterfaceBall.CreateBall(10,10,3,3,5, 5, 100, 100);
        }

        [Test]
        public void TestCoordX() {
            testBall.CoordX = 8;
            Assert.IsTrue(testBall.CoordX == 8);
        }

        [Test] 
        public void TestCoordY()
        {
            testBall.CoordY = 8;
            Assert.IsTrue(testBall.CoordY == 8);
        }

        [Test]
        public void TestVelX()
        {
            Assert.IsTrue(testBall.VelX == 3);
            testBall.VelX = 8;
            Assert.IsTrue(testBall.VelX == 8);
        }

        [Test]
        public void TestVelY()
        {
            Assert.IsTrue(testBall.VelY == 3);
            testBall.VelY = 8;
            Assert.IsTrue(testBall.VelY == 8);
        }

        [Test]
        public void moveInXPositiveTest()
        {
            testBall = InterfaceBall.CreateBall(5, 5, 3, 3, 1, 1, 100, 100);
            testBall.Update(10, 10);
            Assert.True(testBall.CoordX == 8);
        }

        [Test]
        public void moveInXNegativeTest()
        {
            testBall = InterfaceBall.CreateBall(6, 6, -2, -2, 1, 1, 100, 100);
            Assert.True(testBall.CoordX == 6);
        }

        [Test]
        public void moveInYPositiveTest()
        {
            testBall = InterfaceBall.CreateBall(6, 6, 2, 2, 1, 1, 100, 100);
            testBall.Update(10, 10);
            Assert.True(testBall.CoordY == 8);
        }

        [Test]
        public void moveInYNegativeTest()
        {
            testBall = InterfaceBall.CreateBall(6, 6, -2, -2, 1, 1, 100, 100);
            testBall.Update(10, 10);
            Assert.True(testBall.CoordY == 4);
        }

    }
}
