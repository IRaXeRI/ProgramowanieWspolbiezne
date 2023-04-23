using Logic;

namespace Tests
{
    internal class BallTests
    {
        InterfaceBall testBall;
        
        [SetUp]
        public void Setup()
        {
            testBall = InterfaceBall.CreateBall(10,10,3,3,5);
        }

        [Test]
        public void TestCoordX() {
            Assert.IsTrue(testBall.CoordX == 10);
            testBall.CoordX = 8;
            Assert.IsTrue(testBall.CoordX == 8);
        }

        [Test] 
        public void TestCoordY()
        {
            Assert.IsTrue(testBall.CoordY == 10);
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
            testBall = InterfaceBall.CreateBall(5, 5, 3, 3, 1);
            testBall.Update(10, 10);
            Assert.True(testBall.CoordX == 8);
        }

        [Test]
        public void moveInXNegativeTest()
        {
            testBall = InterfaceBall.CreateBall(6, 6, -2, -2, 1);
            testBall.Update(10, 10);
            Assert.True(testBall.CoordX == 4);
        }

        [Test]
        public void moveInYPositiveTest()
        {
            testBall = InterfaceBall.CreateBall(6, 6, 2, 2, 1);
            testBall.Update(10, 10);
            Assert.True(testBall.CoordY == 8);
        }

        [Test]
        public void moveInYNegativeTest()
        {
            testBall = InterfaceBall.CreateBall(6, 6, -2, -2, 1);
            testBall.Update(10, 10);
            Assert.True(testBall.CoordY == 4);
        }

        [Test]
        public void upBorderTest()
        {
            testBall = InterfaceBall.CreateBall(3, 3, -4, -4, 1);
            testBall.Update(10, 10);
            Assert.True(testBall.CoordY == 3);
        }

        [Test]
        public void downBorderTest()
        {
            testBall = InterfaceBall.CreateBall(7, 7, 3, 3, 1);
            testBall.Update(10, 10);
            Assert.True(testBall.CoordY == 8);
        }

        [Test]
        public void leftBorderTest()
        {
            testBall = InterfaceBall.CreateBall(3, 3, -4, -4, 1);
            testBall.Update(10, 10);
            Assert.True(testBall.CoordX == 3);
        }

        [Test]
        public void rightBorderTest()
        {
            testBall = InterfaceBall.CreateBall(7, 7, 3, 3, 1);
            testBall.Update(10, 10);
            Assert.True(testBall.CoordY == 8);
        }
    }
}
