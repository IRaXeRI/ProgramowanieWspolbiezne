using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class Repository : APIData
    {
        private List<InterfaceBall> balls = new();

        public List<InterfaceBall> Balls { get => balls; }

        public override void addBall(InterfaceBall b)
        {
            Balls.Add(b);
        }

        public override void Connect()
        {
            throw new NotImplementedException();
        }

        public override int getAmountOfBalls()
        {
            return balls.Count;
        }

        public override void removeAllBalls()
        {
            Balls.Clear();
        }

        public override void removeBall(InterfaceBall b)
        {
            Balls.Remove(b);
        }
    }
}
