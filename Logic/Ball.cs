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
        private int coordX;
        private int coordY;
        private int velocityX;
        private int velocityY;
        private int radius;
        public override event PropertyChangedEventHandler? PropertyChanged;

        public override int CoordX {
            get { return coordX; }
            set {
                if (coordX == value)
                    return;
                coordX = value;
                RaisePropertyChanged();
            }
        }

        public override int CoordY {
            get { return coordY; }
            set {
                if (coordY == value)
                    return;
                coordY = value;
                RaisePropertyChanged();
            }
        }

        public override int VelX {
            get { return velocityX; }
            set {
                if (velocityX == value)
                    return;
                velocityX = value;
                RaisePropertyChanged();
            }
        }

        public override int VelY {
            get { return velocityY; }
            set {
                if (velocityY == value)
                    return;
                velocityY = value;
                RaisePropertyChanged();
            }
        }

        public override int Radius {
            get { return radius; }
        }

        public Ball(int initCoordX, int initCoordY, int initVelX, int initVelY, int initRadius)
        {
            CoordX = initCoordX;
            CoordY = initCoordY;
            VelX = initVelX;
            VelY = initVelY;
            radius = initRadius;
        }

        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override void Update(int boardLength, int boardWidth)
        {
            //change X
            if (CoordX + VelX + radius >= boardLength) {
                int temp = boardLength - CoordX - radius;
                CoordX = boardLength - radius;
                temp = VelX - temp;
                CoordX -= temp;
                VelX *= (-1);
            }
            else if (CoordX + VelX <= radius) {
                int temp = CoordX - radius;
                CoordX = radius;
                temp = VelX * (-1) - temp;
                CoordX += temp;
                VelX *= (-1);
            }
            else {
                CoordX += VelX;
            }

            //change Y
            if (CoordY + VelY + radius >= boardWidth) {
                int temp = boardWidth - CoordY - radius;
                CoordY = boardWidth - radius;
                temp = VelY - temp;
                CoordY -= temp;
                VelY *= (-1);
            }
            else if (CoordY + VelY <= radius) {
                int temp = CoordY - radius;
                CoordY = radius;
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
