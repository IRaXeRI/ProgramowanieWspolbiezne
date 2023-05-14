using Logic.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class Ball : InterfaceBall, INotifyPropertyChanged
    {
        private InterfaceBallData data;

        public override int CoordX { get { return data.CoordX; } set { data.CoordX = value; RaisePropertyChanged(); } }
        public override int CoordY { get { return data.CoordY; } set { data.CoordY = value; RaisePropertyChanged(); } }
        public override int VelX { get { return data.VelocityX; } set { data.VelocityX = value; RaisePropertyChanged(); } }
        public override int VelY { get { return data.VelocityY; } set { data.VelocityY = value; RaisePropertyChanged(); } }
        public override int Radius { get { return data.Radius; } set { data.Radius = value; } }
        public override int Weight { get { return data.Weight; } set { data.Weight = value; } }
        public override bool Enabled { get => data.Enabled; set => data.Enabled = value; }

        public Ball(int initCoordX, int initCoordY, int initVelX, int initVelY, int initRadius, int initWeight, int initBoardLength, int initBoardWidth)
        {
            data = InterfaceBallData.CreateBallData(initCoordX, initCoordY, initVelX, initVelY, initRadius, initWeight, initBoardLength, initBoardWidth);
            Thread ballThread = new Thread(StartMovement);
            ballThread.IsBackground = true;
            ballThread.Start();
        }

        public override void StartMovement()
        {
            while (Enabled)
            {
                Update(data.BoardLength,data.BoardWidth);
                Thread.Sleep(8);
            }
        }

        public override event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override void Update(int boardLength, int boardWidth)
        {
            //change X
            CoordX += VelX;
            //change Y
            CoordY += VelY;
        }
    }
}
