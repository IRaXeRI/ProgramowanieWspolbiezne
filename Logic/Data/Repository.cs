using Logic;

namespace Data
{
    internal class Repository : APIData
    {
        private List<InterfaceBall> balls = new();

        public override List<InterfaceBall> Balls { get => balls; }


        public override void addBall(InterfaceBall b) {
            balls.Add(b);
        }

        public override void Connect() {
            throw new NotImplementedException();
        }

        public override int getAmountOfBalls() {
            return balls.Count;
        }

        public override void removeAllBalls() {
            balls.Clear();
        }

        public override void removeBall(InterfaceBall b) {
            balls.Remove(b);
        }
    }
}
