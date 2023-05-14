using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Data
{
    public abstract class InterfaceBallData
    {

        public static InterfaceBallData CreateBallData(int coordX, int coordY, int velocityX, int velocityY, int radius, int weight, int boardLength, int boardWidth)
        {
            return new BallData(coordX, coordY, velocityX, velocityY, radius, weight, boardLength, boardWidth);
        }

        public abstract int CoordX { get; set; }
        public abstract int CoordY { get; set; }
        public abstract int VelocityX { get; set; }
        public abstract int VelocityY { get; set; }
        public abstract int Radius { get; set; }
        public abstract int Weight { get; set; }

        public abstract int BoardLength { get; set; }
        public abstract int BoardWidth { get; set; }
        public abstract bool Enabled { get; set; }


    }
}
