using Logic;

namespace Data
{
    internal class Repository : APIData
    {
        private Logic.Data.Logger.Logger logger = new Logic.Data.Logger.Logger();

        private List<InterfaceBall> balls = new();

        public override List<InterfaceBall> Balls { get => balls; }


        public override void addBall(InterfaceBall b) {
            balls.Add(b);
            b.Data.LoggerPropertyChanged += logger.LogCreateMessage;
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
