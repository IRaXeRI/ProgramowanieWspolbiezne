using Logic;

namespace Data
{
    public abstract class APIData
    {
        public static APIData PrepareRepository()
        {
            return new Repository();
        }
        public abstract List<InterfaceBall>? Balls { get; }
        public abstract void Connect();
        public abstract void addBall(InterfaceBall b);
        public abstract void removeBall(InterfaceBall b);
        public abstract void removeAllBalls();
        public abstract int getAmountOfBalls();
    }
}