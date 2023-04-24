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
    internal class Ball : BallData, INotifyPropertyChanged
    {
        public override int CoordX
        {
            get { return coordX; }
            set
            {
                if (coordX == value)
                    return;
                coordX = value;
                RaisePropertyChanged();
            }
        }

        public override int CoordY
        {
            get { return coordY; }
            set
            {
                if (coordY == value)
                    return;
                coordY = value;
                RaisePropertyChanged();
            }
        }

        public override int VelX
        {
            get { return velocityX; }
            set
            {
                if (velocityX == value)
                    return;
                velocityX = value;
                RaisePropertyChanged();
            }
        }

        public override int VelY
        {
            get { return velocityY; }
            set
            {
                if (velocityY == value)
                    return;
                velocityY = value;
                RaisePropertyChanged();
            }
        }

        public override int Radius
        {
            get { return radius; }
            set { radius = value; RaisePropertyChanged(); }
        }

        public Ball(int initCoordX, int initCoordY, int initVelX, int initVelY, int initRadius)
        {
            CoordX = initCoordX;
            CoordY = initCoordY;
            VelX = initVelX;
            VelY = initVelY;
            Radius = initRadius;
        }

        public override event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override void Update(int boardLength, int boardWidth)
        {
            //change X
            if (CoordX + VelX + Radius >= boardLength) {
                int temp = boardLength - CoordX - Radius;
                CoordX = boardLength - Radius;
                temp = VelX - temp;
                CoordX -= temp;
                VelX *= (-1);
            }
            else if (CoordX + VelX <= Radius) {
                int temp = CoordX - Radius;
                CoordX = Radius;
                temp = VelX * (-1) - temp;
                CoordX += temp;
                VelX *= (-1);
            }
            else {
                CoordX += VelX;
            }

            //change Y
            if (CoordY + VelY + Radius >= boardWidth) {
                int temp = boardWidth - CoordY - Radius;
                CoordY = boardWidth - Radius;
                temp = VelY - temp;
                CoordY -= temp;
                VelY *= (-1);
            }
            else if (CoordY + VelY <= Radius) {
                int temp = CoordY - Radius;
                CoordY = Radius;
                temp = VelY * (-1) - temp;
                CoordY += temp;
                VelY *= (-1);
            }
            else {
                CoordY += VelY;
            }
        }
    }
}
