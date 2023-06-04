
using Logic.Data;
using System.ComponentModel;

namespace Logic;

    public abstract class InterfaceBall
    {
        public static InterfaceBall CreateBall(int initCoordX, int initCoordY, int initVelX, int initVelY, int initRadius, int initWeight, int initBoardLength, int initBoardWidth) {
            return new Ball(initCoordX, initCoordY, initVelX, initVelY, initRadius, initWeight, initBoardLength, initBoardWidth);
        }
        public abstract int CoordX {get; set;}
        public abstract int CoordY { get; set;}
        public abstract int VelX { get; set; }
        public abstract int VelY { get; set; }
        public abstract int Radius { get; set; }
        public abstract int Weight { get; set; }
        public abstract bool Enabled { get; set; }
        public abstract void Update(int boardLength, int boardWidth);
        public abstract InterfaceBallData Data { get; }
        public abstract void StartMovement();
        public abstract event PropertyChangedEventHandler? PropertyChanged;
    }