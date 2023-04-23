using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class APILogic
    {
        public static APILogic Prepare(int initWidth, int initLength, int initRadius)
        {
            return new Manager(initWidth, initLength, initRadius);
        }

        public abstract List<InterfaceBall> GetRepositoryList();
        public abstract void Start();
        public abstract void Stop();
        public abstract void clearRepository();
        public abstract List<InterfaceBall> GetAllBalls();
        public abstract void CreateBall();
        public abstract void CreateControledBall(int x, int y, int vX, int vY, int rad);
        public abstract void Update(Object? stateInfo);

    }
}
