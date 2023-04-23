
using System.ComponentModel;

namespace Logic;

    public abstract class InterfaceBall
    {
        public static InterfaceBall CreateBall(int initCoordX, int initCoordY, int initVelX, int initVelY, int initRadius) {
            return new Ball(initCoordX, initCoordY, initVelX, initVelY, initRadius);
        }
        public abstract int CoordX {get; set;}
        public abstract int CoordY { get; set;}
        public abstract int VelX { get; set; }
        public abstract int VelY { get; set; }
        public abstract int Radius { get;}
        public abstract void Update(int boardLength, int boardWidth);
        public abstract event PropertyChangedEventHandler? PropertyChanged;
    }