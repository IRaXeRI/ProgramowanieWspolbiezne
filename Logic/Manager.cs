using static Data.APIData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    internal class Manager : APILogic {
        private readonly int width;
        private readonly int length;
        private readonly int radius;
        private readonly Data.APIData data;
        private Timer? timer;

        public Manager(int initWidth, int initLength, int initRadius) {
            width = initWidth;
            length = initLength;
            radius = initRadius;
            data = Data.APIData.PrepareRepository();
        }


        public override void CreateBall() {
            Random rand = new Random();
            int cX = rand.Next(radius, length - radius);
            int cY = rand.Next(radius, width - radius);
            int vX = rand.Next(-5, 5);
            int vY = rand.Next(-5, 5);
            Ball newBall = new Ball(cX, cY, vX, vY, radius);
            data.addBall(newBall);
        }

        public override List<InterfaceBall> GetRepositoryList()
        {
            return data.Balls;
        }

        public override void Start() {
            timer = new Timer(Update, null, 0, 10);
        }

        public override void Stop() {
            timer.Dispose();
        }

        public override void Update(Object? stateInfo) {
            foreach (InterfaceBall b in GetRepositoryList())
            {
                b.Update(length, width);
            }
        }

        public override void clearRepository()
        {
            data.removeAllBalls();
        }

        public override List<InterfaceBall> GetAllBalls()
        {
            return data.Balls;
        }

        public override void CreateControledBall(int x, int y, int vX, int vY, int rad)
        {
            Ball newBall = new Ball(x, y, vX, vY, rad);
            data.addBall(newBall);
        }
    }
}
