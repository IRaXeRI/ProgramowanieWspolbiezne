using static Data.APIData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.ComponentModel;

namespace Logic
{
    internal class Manager : APILogic {
        private readonly int width;
        private readonly int length;
        private readonly int radius;
        private readonly APIData data;
        private readonly object blockade = new object();
        private Dictionary<InterfaceBall, InterfaceBall> lastCollision = new();

        public Manager(int initWidth, int initLength, int initRadius) {
            width = initWidth;
            length = initLength;
            radius = initRadius;
            data = APIData.PrepareRepository();
        }


        public override void CreateBalls(int n) {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                int cX = rand.Next(radius, length - radius);
                int cY = rand.Next(radius, width - radius);
                while (data.Balls.Any(ball => Math.Abs(ball.CoordX - cX) <= radius && Math.Abs(ball.CoordY - cY) <= radius)) {
                    cX = rand.Next(radius, length - radius);
                    cX = rand.Next(radius, width - radius);
                }
                int vX = rand.Next(-5, 5);
                int vY = rand.Next(-5, 5);
                int we = rand.Next(1,10);
                Ball newBall = new Ball(cX, cY, vX, vY, radius, we, length, width);
                newBall.PropertyChanged += checkCollison;
                data.addBall(newBall);
            }
        }

        public override List<InterfaceBall> GetRepositoryList()
        {
            return data.Balls;
        }

        private void checkCollison(Object s, PropertyChangedEventArgs e) {

            InterfaceBall ball = (InterfaceBall) s;
            if (e.PropertyName == "CoordX" || e.PropertyName == "CoordY") {
                BallCollision(ball);
                WallCollision(ball);
            }
        }

        private void BallCollision(InterfaceBall Mainball) {
            lock (blockade) {
                foreach (InterfaceBall ball in data.Balls.ToArray()) {
                    InterfaceBall lastBallMain, lastBallCaseTested;
                    if (Mainball.Equals(ball) || (lastCollision.TryGetValue(Mainball, out lastBallMain!) &&
                        lastCollision.TryGetValue(ball, out lastBallCaseTested!) &&
                        lastBallMain == ball && lastBallCaseTested == Mainball)) {
                        continue;
                    }

                    //before movement
                    int a = Mainball.CoordX - ball.CoordX;                                                //   |\ x
                    int b = Mainball.CoordY - ball.CoordY;                                                // b | \
                    float xpow2 = (a * a + b * b);                                                        //   |__\
                    float x = (float) Math.Sqrt(xpow2);                                                   //    a

                    if (x <= radius * 2.0 ) {
                        int tempX = Mainball.VelX;
                        int tempY = Mainball.VelY;
                        Mainball.VelX = ball.VelX;
                        Mainball.VelY = ball.VelY;
                        ball.VelX = tempX;
                        ball.VelY = tempY;
                        lastCollision.Remove(Mainball);
                        lastCollision.Remove(ball);
                        lastCollision.Add(Mainball, ball);
                        lastCollision.Add(ball, Mainball);
                    }
                }
            }
        }


        private void WallCollision(InterfaceBall ball) {
            //change X
            if (ball.CoordX + ball.VelX + ball.Radius >= length)
            {
                ball.VelX *= (-1);
                lastCollision.Remove(ball);
            }
            else if (ball.CoordX + ball.VelX <= ball.Radius)
            {
                ball.VelX *= (-1);
                lastCollision.Remove(ball);
            }

            //change Y
            if (ball.CoordY + ball.VelY + ball.Radius >= width)
            {
                ball.VelY *= (-1);
                lastCollision.Remove(ball);
            }
            else if (ball.CoordY + ball.VelY <= ball.Radius)
            {
                ball.VelY *= (-1);
                lastCollision.Remove(ball);
            }
        }


        public override void Update(Object? stateInfo) {
            foreach (InterfaceBall b in GetRepositoryList())
            {
                b.Update(length, width);
            }
        }

        public override void clearRepository()
        {
            foreach (InterfaceBall ball in GetRepositoryList()) { 
                ball.Enabled = false;
            }
            data.removeAllBalls();
        }

        public override List<InterfaceBall> GetAllBalls()
        {
            return data.Balls;
        }

        public override void CreateControledBall(int x, int y, int vX, int vY, int rad, int wei)
        {
            Ball newBall = new Ball(x, y, vX, vY, rad, wei, length, width);
            data.addBall(newBall);
        }
    }
}
