using System;
using System.Linq;
using Project;

namespace TPW_E1.Models;

public class BoardLogic : BoardData
{
    public BoardLogic(int initLenght, int initWidth) : base(initLenght, initWidth)
    {
    }
    
    public override void addBall() {
        Random rand = new Random();
        int cX = rand.Next(0, Length);
        int cY = rand.Next(0, Width);
        int vX = rand.Next(1, 10);
        int vY = rand.Next(1, 10);
        BallData newBall = new BallLogic(cX, cY, vX, vY);
        points.Add(newBall);
    }
    
    public override void addBall(BallData ball) {
        points.Add(ball);
    }
    
    public override bool[,] update() {
        bool[,] answer = new bool[Length + 1,Width + 1];
        for (int i = 0; i < points.Count; i++) {
            points.ElementAt(i).update(Length, Width);
            int x = points.ElementAt(i).CoordX;
            int y = points.ElementAt(i).CoordY;
            answer[x, y] = true;
        }
        return answer;
    }
}