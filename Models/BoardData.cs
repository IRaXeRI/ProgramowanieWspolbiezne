using System;
using System.Collections.Generic;
using System.Linq;
using TPW_E1.Models;

namespace Project;

public abstract class BoardData {
    private List<BallData> pointList = new List<BallData>();
    private readonly int length;
    private readonly int width;
    
    public int Length { get { return length; } }
    public int Width { get { return width; } }
    public List<BallData> points { get { return pointList; } }

    public BoardData(int initLenght, int initWidth) {
        length = initLenght - 1;
        width = initWidth - 1;
    }

    public abstract void addBall();
    public abstract void addBall(BallData ball);
    public abstract bool[,] update();

}