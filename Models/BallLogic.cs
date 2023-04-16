using System;
using TPW_E1.Models;

namespace Project
{
    public class BallLogic : BallData {
        public BallLogic(int initX, int initY, int initVelX, int initVelY) {
            CoordX = initX;
            CoordY = initY;
            VelX = initVelX;
            VelY = initVelY;
        }

        public override void update(int boardLength, int boardWidth) {
            //change X
            if (CoordX + VelX >= boardLength) {
                int temp = boardLength - CoordX;
                CoordX = boardLength;
                temp = VelX - temp;
                CoordX -= temp;
                VelX *= (-1);
            }
            else if (CoordX + VelX <= 0) {
                int temp = CoordX;
                CoordX = 0;
                temp = VelX * (-1) - temp;
                CoordX += temp;
                VelX *= (-1);
            }
            else {
                CoordX += VelX;
            }

            //change Y
            if (CoordY + VelY >= boardWidth) {
                int temp = boardWidth - CoordY;
                CoordY = boardWidth;
                temp = VelY - temp;
                CoordY -= temp;
                VelY *= (-1);
            }
            else if (CoordY + VelY <= 0) {
                int temp = CoordY;
                CoordY = 0;
                temp =  VelY * (-1) - temp;
                CoordY += temp;
                VelY *= (-1);
            }
            else
            {
                CoordY += VelY;
            }
        }
    }
}