namespace TPW_E1.Models;

public abstract class BallData
{
    private int coordX;
    private int coordY;
    private int velocityX;
    private int velocityY;

    public int CoordX {
        get { return coordX; }
        set {
            if (coordX == value)
                return;
            coordX = value;
        }
    }
    
    public int CoordY {
        get { return coordY; }
        set {
            if (coordY == value)
                return;
            coordY = value;
        }
    }
    
    public int VelX {
        get { return velocityX; }
        set {
            if (velocityX == value)
                return;
            velocityX = value;
        }
    }
    
    public int VelY {
        get { return velocityY; }
        set {
            if (velocityY == value)
                return;
            velocityY = value;
        }
    }

    public abstract void update(int boardLength, int boardWidth);

}