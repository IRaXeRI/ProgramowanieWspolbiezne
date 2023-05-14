using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Data;
using Logic;

namespace Logic.Data
{
    public class BallData : InterfaceBallData
    {
        private int coordX;
        private int coordY;
        private int velocityX;
        private int velocityY;
        private int radius;
        private int weight;
        private int boardLength;
        private int boardWidth;
        private bool enabled;


        public BallData(int coordX, int coordY, int velocityX, int velocityY, int radius, int weight, int boardLength, int boardWidth)
        {
            this.CoordX = coordX;
            this.CoordY = coordY;
            this.VelocityX = velocityX;
            this.VelocityY = velocityY;
            this.Radius = radius;
            this.Weight = weight;
            this.BoardLength = boardLength;
            this.BoardWidth = boardWidth;
            this.Enabled = true;
        }

        public override int CoordX { get => coordX; set => coordX = value; }
        public override int CoordY { get => coordY; set => coordY = value; }
        public override int VelocityX { get => velocityX; set => velocityX = value; }
        public override int VelocityY { get => velocityY; set => velocityY = value; }
        public override int Radius { get => radius; set => radius = value; }
        public override int Weight { get => weight; set => weight = value; }
        public override int BoardLength { get => boardLength; set => boardLength = value; }
        public override int BoardWidth { get => boardWidth; set => boardWidth = value; }
        public override bool Enabled { get => enabled; set => enabled = value; }
    }
}
